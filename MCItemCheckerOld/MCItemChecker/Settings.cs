using MCItemChecker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCItemChecker
{
    public sealed class MySettings
    {
        private const string filename = "settings.json";
        private static readonly MySettings m_instance = new MySettings();

        static MySettings()
        {
            AppDataSettings.LoadSettings(ref m_instance, filename);
        }

        private MySettings()
        { }

        public static MySettings Properties
            => m_instance;

        public static void Save()
        {
            AppDataSettings.SaveSettings(m_instance, filename);
        }

        public string FilePath
        { get; set; } = string.Empty;
    }
}
