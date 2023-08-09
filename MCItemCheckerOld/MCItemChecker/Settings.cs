using MCItemChecker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCItemChecker
{
    public sealed class Settings
    {
        private const string filename = "settings.json";
        private static readonly Settings m_instance = new Settings();

        static Settings()
        {
            AppDataSettings.LoadSettings(ref m_instance, filename);
        }

        private Settings()
        { }

        public static Settings Properties
            => m_instance;

        public static void Save()
        {
            AppDataSettings.SaveSettings(m_instance, filename);
        }

        public const int MaxRecursionCount = 32;

        public string FilePath
        { get; set; } = string.Empty;
    }
}
