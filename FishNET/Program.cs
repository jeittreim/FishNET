using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.Collections;
using PluginInterface;
using System.IO;
using System.Reflection;

namespace FishNET
{
    public class Program
    {
        ArrayList list_Plugins = new ArrayList();
        public static void Main()
        {
            Debug.Print("\n\nstarting Network Setup\n----------------------");
            int netstat = Network.netconn();
            if (netstat == 1)
            {
                Debug.Print("Network Disconnected");
            }
            else
            {
                Debug.Print("IP: " + Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].IPAddress);
            }

            Debug.Print("\n\nstarting plugin loading\n-----------------------");
            try
            {
                //LoadPlugins();
            }
            catch (Exception e) { Debug.Print("error: " + e); }
            
            


        }

        private static void LoadPlugins()
        {
            string pluginDir = @"\SD\Plugins";
            foreach (string s in Directory.GetFiles(pluginDir))
            {
               //add check for proper .pe extension before load attempt.  also fix exception handling and alerts
                    try
                    {
                        using (FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read))
                        {
                            // Create an assembly
                            byte[] plugin = new byte[(int)fs.Length];
                            fs.Read(plugin, 0, (int)fs.Length);
                            Assembly asm = Assembly.Load(plugin);
                            foreach (Type t in asm.GetTypes())
                            {
                                Debug.Print(t.FullName);
                            }

                        }
                    }
                    catch (Exception e) { Debug.Print("something broke" + e); }
            }
        }
    }
}
