using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Hosting;
using System.Threading;
using static System.Environment;

namespace OLiOSoft.OWINKatana.TestHost
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    public class TestHosted : OLiOHostedCore
    {
        #region -- Private Data --
        private readonly int defaultPort = 9000;
        private readonly string defaultProtocol = "http";
        private readonly string defaultServerName = "localhost";
        private readonly string defaultServer = "Microsoft.Owin.Host.HttpListener";

        #endregion

        #region -- Override APIMethods --
        public override void Configuration(IAppBuilder p_AppBuilder)
        {
            p_AppBuilder.Use((context, next) =>
            {
                context.Response.ContentType = "text/plain;charset=utf-8";

                return next.Invoke();
            });

            p_AppBuilder.Use((context, next) =>
            {
                context.Response.Write("\nthis is first hello world!!");

                return next.Invoke();
            });

            p_AppBuilder.Use((context, next) =>
            {
                context.Response.Write("\nthis is second hello world!!!");

                return next.Invoke();
            });
        }

        public override void Run()
        {
            this.ORun();
        }

        bool keepAlive = false;

        public override void Run(EventArgs p_EventArgs)
        {
            OLiOEventArgs<Action<IHostedCore, bool>> oEventArgs = (OLiOEventArgs<Action<IHostedCore, bool>>)p_EventArgs;

			StartOptions options = new StartOptions();

			options.Urls.Add("http://localhost:9000");
			options.Urls.Add("http://192.168.0.21:9000");
			options.Urls.Add(string.Format("http://{0}:9000", Environment.MachineName));

			using (WebApp.Start(options, Configuration))
            {
                keepAlive = true;

                while (keepAlive)
                    Thread.Sleep(3000);
            }

            //done
            oEventArgs.Data.Invoke(this, true);
        }

        public override void Cancel(EventArgs p_EventArgs)
        {
            OLiOEventArgs<Action<IHostedCore, bool>> oEventArgs = (OLiOEventArgs<Action<IHostedCore, bool>>)p_EventArgs;

            keepAlive = false;

            //done
            oEventArgs.Data.Invoke(this, false);
        }

        #endregion

    }
}
