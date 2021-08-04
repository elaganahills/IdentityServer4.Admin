using Hills.IdentityServer4.Deployment.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hills.IdentityServer4.Deployment
{
    public class Helper
    {
        public static string GetExecutableDirectory() => System.AppContext.BaseDirectory;// Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string GetExecutablePath()
        {
            var dll = Assembly.GetEntryAssembly().GetName().CodeBase;
            var p = new Uri(dll.Replace(".dll", ".exe")).AbsolutePath;
            return p.Replace("%20", " ").Replace("/", "\\");
        }

        public static string GetProjectFilePath(string file) => Path.GetFullPath(file);// Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string GetIdentityServer4AdminExecutablePath()
        {
#if DEBUG
            return Resources.Test_IdentityServer4AdminPath;
#else
            return Path.GetFullPath("..//Hills.IdentityServer4.Admin//Hills.IdentityServer4.Admin.exe");
#endif
        }

        public static string GetIdentityServer4ExecutablePath()
        {
#if DEBUG
            return Resources.Test_IdentityServer4Path;
#else
            return Path.GetFullPath("..//Hills.IdentityServer4//Hills.IdentityServer4.STS.Identity.exe");
#endif
        }

        public static string GetIdentityServer4AdminFolderPath()
        {
            return Path.GetDirectoryName(GetIdentityServer4AdminExecutablePath());
        }

        public static string GetIdentityServer4FolderPath()
        {
            return Path.GetDirectoryName(GetIdentityServer4ExecutablePath());
        }

        public static string GetIdentityServer4AdminDataFilePath()
        {
            return GetIdentityServer4AdminFolderPath() + "\\deploy.identityserverdata.json";
        }

        public static string GetIdentityServer4AdminAppSettingsFilePath()
        {
            return GetIdentityServer4AdminFolderPath() + "\\deploy.appsettings.json";
        }

        public static string GetIdentityServer4AppSettingsFilePath()
        {
            return GetIdentityServer4FolderPath() + "\\deploy.appsettings.json";
        }

        internal static string GetOperaPath()
        {
            return Helper.GetExecutableDirectory() + "Opera\\launcher.exe";
        }
    }
}
