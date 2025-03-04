using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;

namespace ACT_Dashboard
{
    public partial class FFXIVSettingsControl : UserControl
    {
        private readonly FFXIVDPSWidgetInstance _widgetInstance;

        public FFXIVSettingsControl(FFXIVDPSWidgetInstance widgetInstance)
        {
            InitializeComponent();
            _widgetInstance = widgetInstance;
            LoadSettings();
        }

        private void LoadSettings()
        {
            useGlobalThemeChk.IsChecked = _widgetInstance.UseGlobalTheme;
            showDpsTableChk.IsChecked = _widgetInstance.ShowDPSTable;
            showHpsTableChk.IsChecked = _widgetInstance.ShowHPSTable;
            actEndpointTxt.Text = _widgetInstance.ACTEndpoint;

            bgColorBtn.Content = ColorToHex(_widgetInstance.UserBackColor);
            accentColorBtn.Content = ColorToHex(_widgetInstance.UserAccentColor);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _widgetInstance.UseGlobalTheme = useGlobalThemeChk.IsChecked ?? true;
                _widgetInstance.ShowDPSTable = showDpsTableChk.IsChecked ?? true;
                _widgetInstance.ShowHPSTable = showHpsTableChk.IsChecked ?? true;
                _widgetInstance.ACTEndpoint = actEndpointTxt.Text;

                _widgetInstance.UserBackColor = HexToDrawingColor(bgColorBtn.Content.ToString());
                _widgetInstance.UserAccentColor = HexToDrawingColor(accentColorBtn.Content.ToString());

                _widgetInstance.RequestUpdate();

                MessageBox.Show("Settings saved successfully!", "FFXIV DPS Widget", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message, "FFXIV DPS Widget", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BgColorBtn_Click(object sender, RoutedEventArgs e)
        {
            bgColorBtn.Content = "#000000"; // Simplified placeholder
        }

        private void AccentColorBtn_Click(object sender, RoutedEventArgs e)
        {
            accentColorBtn.Content = "#FFFFFF"; // Simplified example
        }

        // Explicitly missing handler added:
        private void UseGlobalThemeChk_Click(object sender, RoutedEventArgs e)
        {
            _widgetInstance.UseGlobalTheme = useGlobalThemeChk.IsChecked ?? true;
            _widgetInstance.RequestUpdate();
        }

        private string ColorToHex(System.Drawing.Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private System.Drawing.Color HexToDrawingColor(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            byte r = Convert.ToByte(hex.Substring(0, 2), 16);
            byte g = Convert.ToByte(hex.Substring(2, 2), 16);
            byte b = Convert.ToByte(hex.Substring(4, 2), 16);

            return System.Drawing.Color.FromArgb(r, g, b);
        }
    }
}
