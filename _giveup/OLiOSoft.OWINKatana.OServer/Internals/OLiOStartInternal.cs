using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Hosting;

namespace OLiOSoft.OWINKatana.OServer
{
    using OLiOSoft.OWINKatana.OServer.Abstracts;

    internal class OLiOStartInternal : AStartInternal
    {
        #region -- Private Data --
        private string defaultPort = "9000";
        private string defaultURL = "";
        private string defaultServer = "Microsoft.Owin.Host.HttpListener";

        #endregion

        #region -- Override APIMethods --
        public override void Start(Action<IAppBuilder> p_Configuration)
        {
            StartOptions options = new StartOptions(defaultURL);

            options.ServerFactory = defaultServer;


            using (WebApp.Start())
            {

            }
        }

        public override void Start(Action<IAppBuilder> p_Configuration, string p_Port)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
