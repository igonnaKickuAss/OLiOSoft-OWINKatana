using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.TestHost1
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    public class TestHosted1 : OLiOHostedCore
    {
        #region -- Private Data --
        private int defaultPort = 9001;
        private string defaultProtocol = "http";
        private string defaultServerName = "localhost";
        private string defaultServer = "Microsoft.Owin.Host.HttpListener";

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
                context.Response.Write("\nfuck u bitch, u sucks idiot!!");

                return next.Invoke();
            });

            p_AppBuilder.Use((context, next) =>
            {
                context.Response.Write("\nfuck u bitch, u sucks idiot!! motherfuck");

                return next.Invoke();
            });
        }

        public override void Run()
        {
            this.ORun();
        }

        public override void Run(EventArgs p_EventArgs)
        {
            OLiOEventArgs<Action<IHostedCore, bool>> oEventArgs = (OLiOEventArgs<Action<IHostedCore, bool>>)p_EventArgs;

            this.ORun(
                this.defaultServer,
                this.defaultProtocol,
                this.defaultServerName,
                this.defaultPort
                );

            //done
            oEventArgs.Data.Invoke(this, true);
        }

        public override void Cancel(EventArgs p_EventArgs)
        {
            OLiOEventArgs<Action<IHostedCore, bool>> oEventArgs = (OLiOEventArgs<Action<IHostedCore, bool>>)p_EventArgs;

            this.OCancel();

            //done
            oEventArgs.Data.Invoke(this, false);
        }

        #endregion

    }
}
