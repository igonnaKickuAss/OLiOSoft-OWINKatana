using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Hosting;
using System.Threading;

namespace OLiOSoft.OWINKatana.OHosted
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Abstracts;

    internal class OLiOStartInternal : AStartInternal
    {
        #region -- Override APIMethods --
        public override void Start(object p_Sender, EventArgs p_EventArgs)
        {
            OLiOEventArgs<
                Action,
                Action<IAppBuilder>,
                StartOptions
                > oEventArgs = p_EventArgs as OLiOEventArgs<
                    Action,
                    Action<IAppBuilder>,
                    StartOptions
                    >;

            if (oEventArgs == null)
                return;

            Action running = oEventArgs.Data;
            Action<IAppBuilder> configuration = oEventArgs.Data1;
            StartOptions options = oEventArgs.Data2;


            using (WebApp.Start(options, configuration))
                running.Invoke();       //该线程应在介里卡住
        }

        public override void Stop(object p_Sender, EventArgs p_EventArgs)
        {
            OLiOEventArgs<
                Action
                > oEventArgs = p_EventArgs as OLiOEventArgs<
                    Action
                    >;

            if (oEventArgs == null)
                return;

            Action canceling = oEventArgs.Data;

            canceling.Invoke();  //该线程应在介里卡住（数秒钟左右）
        }


        #endregion
    }
}
