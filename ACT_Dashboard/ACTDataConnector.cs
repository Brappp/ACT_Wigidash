using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ACT_Dashboard
{
    public class ACTDataConnector : IDisposable
    {
        private ClientWebSocket _webSocket;
        private string _endpoint = "ws://127.0.0.1:10501/ws";
        private CancellationTokenSource _cancellationTokenSource;
        private readonly object _encounterLock = new object();
        private EncounterData _currentEncounterData;

        public event EventHandler<EncounterData> DataUpdated;

        public ACTDataConnector(string endpoint = null)
        {
            if (!string.IsNullOrEmpty(endpoint))
                _endpoint = endpoint;
        }

        public void SetEndpoint(string endpoint)
        {
            if (_endpoint != endpoint)
            {
                _endpoint = endpoint;
                DisconnectFromACT();
                ConnectToACT();
            }
        }

        public async void ConnectToACT()
        {
            _webSocket = new ClientWebSocket();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await _webSocket.ConnectAsync(new Uri(_endpoint), _cancellationTokenSource.Token);
                await ReceiveLoop();
            }
            catch
            {
                DisconnectFromACT();
            }
        }

        private async Task ReceiveLoop()
        {
            byte[] buffer = new byte[8192];

            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationTokenSource.Token);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string jsonData = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    ParseACTData(jsonData);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    DisconnectFromACT();
                }
            }
        }

        private void ParseACTData(string jsonData)
        {
            try
            {
                var actData = JsonSerializer.Deserialize<ACTOverlayData>(jsonData);

                if (actData?.Encounter == null) return;

                EncounterData encounter = new EncounterData
                {
                    Title = actData.Encounter.Title,
                    Duration = TimeSpan.FromSeconds(actData.Encounter.Duration),
                    RDPS = double.TryParse(actData.Encounter.EncDPS, out var rdps) ? rdps : 0,
                    TotalDamage = long.TryParse(actData.Encounter.Damage, out var dmg) ? dmg : 0,
                    Combatants = actData.Combatants.Select(c => new CombatantData
                    {
                        Job = c.Job,
                        Name = c.Name,
                        DPS = double.TryParse(c.EncDPS, out var dps) ? dps : 0,
                        DamagePercent = double.TryParse(c.DamagePercent, out var dp) ? dp : 0,
                        CritHitPercent = c.CritHitPercent,
                        DirectHitPercent = c.DirectHitPercent,
                        Deaths = c.Deaths
                    }).ToList()
                };

                lock (_encounterLock)
                {
                    _currentEncounterData = encounter;
                }

                DataUpdated?.Invoke(this, encounter);
            }
            catch { /* Handle or log error explicitly as needed */ }
        }

        private void DisconnectFromACT()
        {
            _cancellationTokenSource?.Cancel();
            _webSocket?.Dispose();
        }

        public EncounterData GetCurrentEncounter()
        {
            lock (_encounterLock)
                return _currentEncounterData;
        }

        public void Dispose()
        {
            DisconnectFromACT();
        }
    }

    public class EncounterData
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public double RDPS { get; set; }
        public long TotalDamage { get; set; }
        public List<CombatantData> Combatants { get; set; } = new List<CombatantData>();
    }

    public class CombatantData
    {
        public string Job { get; set; }
        public string Name { get; set; }
        public double DPS { get; set; }
        public double DamagePercent { get; set; }
        public string CritHitPercent { get; set; }
        public string DirectHitPercent { get; set; }
        public string Deaths { get; set; }
    }

    // Classes matching the JSON data from ACT OverlayPlugin explicitly
    public class ACTOverlayData
    {
        public Encounter Encounter { get; set; }
        public List<Combatant> Combatants { get; set; }
    }

    public class Encounter
    {
        public string Title { get; set; }
        public double Duration { get; set; }
        public string EncDPS { get; set; }
        public string Damage { get; set; }
    }

    public class Combatant
    {
        public string Job { get; set; }
        public string Name { get; set; }
        public string EncDPS { get; set; }
        public string DamagePercent { get; set; }
        public string CritHitPercent { get; set; }
        public string DirectHitPercent { get; set; }
        public string Deaths { get; set; }
    }
}
