using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted
{
    internal struct OLiOHostedCore_Address
    {
        //shotC
        public string URL { get; private set; }

        //apiMethods
        public void Set(string p_Protocol, string p_ServerName_IP, int p_Port)
        {
            this.protocol = p_Protocol;
            this.serverName_ip = p_ServerName_IP;
            this.port = p_Port;

            URL = $"{protocol}://{serverName_ip}:{port}";
        }

        //data
        private string protocol;
        private string serverName_ip;
        private int port;
        
    }
}
