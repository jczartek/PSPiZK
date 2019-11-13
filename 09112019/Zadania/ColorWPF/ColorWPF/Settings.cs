using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorWPF
{
    public static class Settings
    {
        public static Color ReadColorSettings()
        {
            Properties.Settings settings = Properties.Settings.Default;

            return new Color() { A = 255, R = settings.R, B = settings.B, G = settings.G };
        }

        public static void SaveColorSettings(Color color)
        {
            Properties.Settings settings = Properties.Settings.Default;

            settings.R = color.R;
            settings.G = color.G;
            settings.B = color.B;
            settings.Save();
        }

        public static void ReadWindowState(MainWindow window)
        {
            var settings = Properties.Settings.Default;
            window.Left = settings.Left;
            window.Top = settings.Top;
            window.Width = settings.Width;
            window.Height = settings.Height;
        }

        public static void SaveWindowState(MainWindow window)
        {
            var settings = Properties.Settings.Default;
            settings.Left = window.Left;
            settings.Top = window.Top;
            settings.Width = window.Width;
            settings.Height = window.Height;
            settings.Save();
        }
    }
}
