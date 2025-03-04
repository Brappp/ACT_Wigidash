using System;
using System.Collections.Generic;
using System.Drawing;
using WigiDashWidgetFramework;
using WigiDashWidgetFramework.WidgetUtility;

namespace ACT_Dashboard
{
    public class FFXIVDPSWidgetServer : IWidgetObject
    {
        public IWidgetManager WidgetManager { get; set; }

        public string LastErrorMessage { get; set; }

        public Guid Guid => new Guid("66E2CAFC-4BAB-4601-BD40-0D365C1C435C");

        public string Name => "FFXIV DPS Widget";

        public string Description => "Displays real-time DPS from Advanced Combat Tracker.";

        public string Author => "Your Name";

        public string Website => "https://yourwebsite.com";

        public Version Version => new Version(1, 0, 0, 0);

        public SdkVersion TargetSdk => WidgetUtility.CurrentSdkVersion;

        public List<WidgetSize> SupportedSizes => new List<WidgetSize>()
        {
            new WidgetSize(1, 1),
            new WidgetSize(2, 1),
            new WidgetSize(2, 2),
            new WidgetSize(3, 2),
            new WidgetSize(4, 2)
        };

        public WidgetError Load(string resourcePath)
        {
            return WidgetError.NO_ERROR;
        }

        public WidgetError Unload()
        {
            return WidgetError.NO_ERROR;
        }

        public Bitmap WidgetThumbnail => GetWidgetPreview(new WidgetSize(2, 1));

        public Bitmap PreviewImage => GetWidgetPreview(new WidgetSize(2, 1));

        public Bitmap GetWidgetPreview(WidgetSize widgetSize)
        {
            Bitmap bmp = new Bitmap(widgetSize.ToSize().Width, widgetSize.ToSize().Height);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.Black);
                gfx.DrawString("FFXIV DPS Widget", new Font("Arial", 14), Brushes.White, new PointF(10, 10));
            }
            return bmp;
        }

        public IWidgetInstance CreateWidgetInstance(WidgetSize widgetSize, Guid instanceGuid)
        {
            return new FFXIVDPSWidgetInstance(this, widgetSize, instanceGuid);
        }

        public bool RemoveWidgetInstance(Guid instanceGuid)
        {
            return true;
        }
    }
}
