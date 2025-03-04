using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FFXIVDPSWidget
{
    // Event args for ACT data updates
    public class ACTDataEventArgs : EventArgs
    {
        public EncounterData Encounter { get; }

        public ACTDataEventArgs(EncounterData encounter)
        {
            Encounter = encounter;
        }
    }

    // Data models for encounter data
    public class EncounterData
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public double RDPS { get; set; }
        public long TotalDamage { get; set; }
        public List<CombatantData> Combatants { get; set; } = new List<CombatantData>();
        public List<HealerData> Healers { get; set; } = new List<HealerData>();
    }

    public class CombatantData
    {
        public string Job { get; set; }
        public string Name { get; set; }
        public double DPS { get; set; }
        public double DamagePercent { get; set; }
        public double CritHitPercent { get; set; }
        public double DirectHitPercent { get; set; }
        public int Deaths { get; set; }
    }

    public class HealerData
    {
        public string Job { get; set; }
        public string Name { get; set; }
        public double HPS { get; set; }
        public double HealingPercent { get; set; }
        public double OverhealPercent { get; set; }
        public long ShieldAmount { get; set; }
        public int Deaths { get; set; }
    }

    // Data models for ACT OverlayPlugin WebSocket data
    public class ACTOverlayData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("encounter")]
        public ACTEncounterData Encounter { get; set; }

        [JsonPropertyName("combatants")]
        public List<ACTCombatantData> Combatants { get; set; }
    }

    public class ACTEncounterData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        [JsonPropertyName("ENCDPS")]
        public double ENCDPS { get; set; }

        [JsonPropertyName("damage")]
        public long Damage { get; set; }

        [JsonPropertyName("healed")]
        public long Healed { get; set; }
    }

    public class ACTCombatantData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("Job")]
        public string Job { get; set; }

        [JsonPropertyName("ENCDPS")]
        public double ENCDPS { get; set; }

        [JsonPropertyName("ENCHPS")]
        public double ENCHPS { get; set; }

        [JsonPropertyName("damage")]
        public long Damage { get; set; }

        [JsonPropertyName("damage%")]
        public double DamagePercent { get; set; }

        [JsonPropertyName("healed")]
        public long Healed { get; set; }

        [JsonPropertyName("healed%")]
        public double HealingPercent { get; set; }

        [JsonPropertyName("crithit%")]
        public double CritHitPercent { get; set; }

        [JsonPropertyName("DirectHit%")]
        public double DirectHitPercent { get; set; }

        [JsonPropertyName("OverHealPct")]
        public double OverHealPercent { get; set; }

        [JsonPropertyName("damageShield")]
        public double DamageShield { get; set; }

        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
    }
}