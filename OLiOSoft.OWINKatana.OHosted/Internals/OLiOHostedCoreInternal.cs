using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OLiOSoft.OWINKatana.OHosted
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Abstracts;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;
    using Owin;

    internal class OLiOHostedCoreInternal : AHostedCoreInternal
    {
        #region -- Override APIMethods --
        public override void CancelInternal(object p_Sender)
        {
            if (this.GetStopEventHandler == null)
                return;

            OLiOHostedCore hCore = p_Sender as OLiOHostedCore;

            if (hCore == null)
                return;

            this.GetStopEventHandler.Invoke(
                this,
                new OLiOEventArgs<Action>(
                    hCore.Canceling
                    )
                );
        }

        public override void RunInternal(object p_Sender, string p_Server, params OLiOHostedCore_Address[] p_Addresses)
        {
            if (this.GetStartEventHandler == null)
                return;

            OLiOHostedCore hCore = p_Sender as OLiOHostedCore;

            if (hCore == null)
                return;

            StartOptions options = new StartOptions();

            int length = p_Addresses.Length;
            for (int i = 0; i < length; i++)
                options.Urls.Add(p_Addresses[i].URL);
            options.ServerFactory = p_Server;

            this.GetStartEventHandler.Invoke(
                this,
                new OLiOEventArgs<Action, Action<IAppBuilder>, StartOptions>(
                    hCore.Running,
                    hCore.Configuration,
                    options
                    )
                );
        }

        #endregion
    }
}


