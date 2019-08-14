using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MASngFE.Properties;

namespace MASngFE.Application
{
    public static class AppVersionManager
    {
        public static string GetAppVersion()
        {
            return Settings.Default.AppVersion;
        }

        public static void SetAppVersion(string newAppVersion)
        {
            Settings.Default.AppVersion = newAppVersion;
            Settings.Default.Save();
        }
    }
}
