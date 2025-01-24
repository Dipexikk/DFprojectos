using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace KeyAuth
{
    class Program
    {
        public static api KeyAuthApp = new api(
            name: "DFProject",
            ownerid: "kbWA2Nje7b",
            version: "1.0"
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetCurrentProcess();

        static void Main(string[] args)
        {
            securityChecks();

            Console.Title = "DF Auth";
            Console.WriteLine("\n\n Connecting...");
            KeyAuthApp.init();

            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(1500);
                TerminateProcess(GetCurrentProcess(), 1);
            }

            string hwid = GetHWID();
            Console.WriteLine("\n Authenticating using HWID...");
            KeyAuthApp.hwidlogin(hwid);

            if (!KeyAuthApp.response.success)
            {
                Console.WriteLine("\n Status: " + KeyAuthApp.response.message);
                Thread.Sleep(2500);
                TerminateProcess(GetCurrentProcess(), 1);
            }

            Console.WriteLine("\n Logged In Successfully!\n");

            // User data
            Console.WriteLine(" User data:");
            Console.WriteLine(" Username: " + KeyAuthApp.user_data.username);
            Console.WriteLine(" IP address: " + KeyAuthApp.user_data.ip);
            Console.WriteLine(" Hardware-Id: " + KeyAuthApp.user_data.hwid);
            Console.WriteLine(" Created at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.createdate)));
            if (!string.IsNullOrEmpty(KeyAuthApp.user_data.lastlogin))
                Console.WriteLine(" Last login at: " + UnixTimeToDateTime(long.Parse(KeyAuthApp.user_data.lastlogin)));

            Console.WriteLine("\n Closing in five seconds...");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        public static string GetHWID()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
        }

        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
            return dtDateTime;
        }

        static void securityChecks()
        {
            // Check if the Loader was executed by a different program
            var frames = new StackTrace().GetFrames();
            foreach (var frame in frames)
            {
                MethodBase method = frame.GetMethod();
                if (method != null && method.DeclaringType?.Assembly != Assembly.GetExecutingAssembly())
                {
                    TerminateProcess(GetCurrentProcess(), 1);
                }
            }

            // Check if HarmonyLib is attempting to poison our program
            var harmonyAssembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .FirstOrDefault(a => a.GetName().Name == "0Harmony");

            if (harmonyAssembly != null)
            {
                TerminateProcess(GetCurrentProcess(), 1);
            }
        }
    }
}
