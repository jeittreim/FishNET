using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Net;
using System.Threading;
namespace FishNET
{
    public class Network
    {
        public static int netconn()
        {
            int result = 0;
            Microsoft.SPOT.Net.NetworkInformation.NetworkInterface nf = Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0];
            if (!nf.IsDhcpEnabled)
            {
                Debug.Print("dhcp not enabled, setting up");
                nf.EnableDhcp();
                nf.RenewDhcpLease();
                Thread.Sleep(10000);
            }
            if (nf.IPAddress == "0.0.0.0")
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;           
        }

    }
}
