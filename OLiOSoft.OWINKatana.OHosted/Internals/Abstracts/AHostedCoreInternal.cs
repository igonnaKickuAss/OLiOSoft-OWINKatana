using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.Abstracts
{
    using Microsoft.Owin.Hosting;
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;
    using Owin;

    internal abstract class AHostedCoreInternal : IHostedCoreInternal
    {
        #region -- Private Data --
        private EventHandler<OLiOEventArgs<
            Action,
            Action<IAppBuilder>,
            StartOptions
            >> startEventHandles = null;

        private EventHandler<OLiOEventArgs<
            Action
            >> stopEventHandles = null;

        #endregion

        #region -- Public ShotC --

        public event EventHandler<OLiOEventArgs<Action, Action<IAppBuilder>, StartOptions>> StartEventHandler
        {
            add {
                if (startEventHandles == null)
                    startEventHandles += value;
            }
            remove {
                if (startEventHandles == null)
                    return;

                startEventHandles -= value;
            }
        }

        public event EventHandler<OLiOEventArgs<Action>> StopEventHandler
        {
            add {
                if (stopEventHandles == null)
                    stopEventHandles += value;
            }
            remove {
                if (stopEventHandles == null)
                    return;

                stopEventHandles -= value;
            }
        }

        #endregion

        #region -- Interface APIMethods --
        public virtual EventHandler<OLiOEventArgs<Action, Action<IAppBuilder>, StartOptions>>
            GetStartEventHandler { get => startEventHandles; }

        public virtual EventHandler<OLiOEventArgs<Action>>
            GetStopEventHandler { get=> stopEventHandles; }

        public abstract void RunInternal(object p_Sender, string p_Server, params OLiOHostedCore_Address[] p_Addresses);
        public abstract void CancelInternal(object p_Sender);




        #endregion
    }
}
