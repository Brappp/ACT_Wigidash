using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Controls;
using WigiDashWidgetFramework;
using WigiDashWidgetFramework.WidgetUtility;

namespace ACT_Dashboard
{
    public class FFXIVDPSWidgetInstance : IWidgetInstance
    {
        public IWidgetObject WidgetObject { get; private set; }
        public Guid Guid { get; private set; }
        public WidgetSize WidgetSize { get; private set; }

        public bool UseGlobalTheme { get; set; } = true;
        public bool ShowDPSTable { get; set; } = true;
        public bool ShowHPSTable { get; set; } = true;
        public string ACTEndpoint { get; set; } = "ws://127.0.0.1:10501/ws";
        public Color UserBackColor { get; set; } = Color.Black;
        public Color UserAccentColor { get; set; } = Color.White;

        private readonly object _bitmapLock = new object();
        private Bitmap _currentBitmap;
        private bool _running;

        public event WidgetUpdatedEventHandler WidgetUpdated;

        public FFXIVDPSWidgetInstance(IWidgetObject widgetObject, WidgetSize widgetSize, Guid instanceGuid)
        {
            WidgetObject = widgetObject;
            WidgetSize = widgetSize;
            Guid = instanceGuid;
            _running = true;

            StartUpdateLoop();
        }

        private void StartUpdateLoop()
        {
            Task.Run(async () =>
            {
                while (_running)
                {
                    RequestUpdate();
                    await Task.Delay(1000);
                }
            });
        }

        public void RequestUpdate()
        {
            Bitmap updatedBitmap = DrawWidget();

            if (updatedBitmap == null) // Explicit safeguard
            {
                updatedBitmap = new Bitmap(WidgetSize.ToSize().Width, WidgetSize.ToSize().Height);
                using (Graphics gfx = Graphics.FromImage(updatedBitmap))
                {
                    gfx.Clear(UserBackColor);
                    gfx.DrawString("No Data", new Font("Arial", 12), Brushes.Red, new PointF(10, 10));
                }
            }

            WidgetUpdated?.Invoke(this, new WidgetUpdatedEventArgs { WidgetBitmap = updatedBitmap });

            lock (_bitmapLock)
            {
                _currentBitmap?.Dispose();
                _currentBitmap = updatedBitmap;
            }
        }

        private Bitmap DrawWidget()
        {
            Size size = WidgetSize.ToSize();
            if (size.Width <= 0 || size.Height <= 0)
                size = new Size(200, 100); // Explicit fallback size

            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(UserBackColor);
                gfx.DrawString("DPS: Fetching...", new Font("Arial", 16), Brushes.White, new PointF(10, 10));
                gfx.DrawString("DPS: 0", new Font("Arial", 20, FontStyle.Bold), Brushes.Lime, new PointF(10, 45));
            }
            return bmp;
        }

        public void ClickEvent(ClickType click_type, int x, int y) { }

        public UserControl GetSettingsControl()
        {
            return new FFXIVSettingsControl(this);
        }

        public void EnterSleep() => _running = false;

        public void ExitSleep()
        {
            if (!_running)
            {
                _running = true;
                StartUpdateLoop();
            }
        }

        public void Dispose()
        {
            _running = false;
            lock (_bitmapLock)
                _currentBitmap?.Dispose();
        }
    }
}
