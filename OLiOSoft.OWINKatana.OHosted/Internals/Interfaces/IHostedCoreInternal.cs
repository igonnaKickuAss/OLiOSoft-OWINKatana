using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OLiOSoft.OWINKatana.OHosted.Interfaces
{
    using OLiOSoft.OSystem.Helpers;

    internal interface IHostedCoreInternal
    {
        EventHandler<OLiOEventArgs<
            Action,
            Action<IAppBuilder>,
            StartOptions
            >> GetStartEventHandler { get; }

        EventHandler<OLiOEventArgs<
            Action
            >> GetStopEventHandler { get; }

        void RunInternal(object p_Sender, string p_Server, params OLiOHostedCore_Address[] p_Addresses);
        void CancelInternal(object p_Sender);
    }
}
