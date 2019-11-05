using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager.Abstracts
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;
    using OLiOSoft.OWINKatana.OHosted.OManager.Interfaces;

    internal abstract class AHostedCentreInternal : IHostedCentreInternal
    {
        #region -- Private Data --
        private EventHandler<OLiOEventArgs<IHostedCore>> createEventHandles = null;
        private EventHandler<OLiOEventArgs<Type>> restEventHandles = null;
        private EventHandler<OLiOEventArgs<Action>> recycleEventHandles = null;
        private EventHandler<OLiOEventArgs<Action<OLiOHostedPool_Profiler>>> profilerEventHandles = null;

        #endregion

        #region -- Public ShotC --
        public event EventHandler<OLiOEventArgs<IHostedCore>> CreateEventHandler
        {
            add {
                if (createEventHandles == null)
                    createEventHandles += value;
            }
            remove {
                if (createEventHandles == null)
                    return;

                createEventHandles -= value;
            }
        }

        public event EventHandler<OLiOEventArgs<Type>> RestEventHandler
        {
            add {
                if (restEventHandles == null)
                    restEventHandles += value;
            }
            remove {
                if (restEventHandles == null)
                    return;

                restEventHandles -= value;
            }
        }

        public event EventHandler<OLiOEventArgs<Action>> RecycleEventHandler
        {
            add {
                if (recycleEventHandles == null)
                    recycleEventHandles += value;
            }
            remove {
                if (recycleEventHandles == null)
                    return;

                recycleEventHandles -= value;
            }
        }

        public event EventHandler<OLiOEventArgs<Action<OLiOHostedPool_Profiler>>> ProfilerEventHandler
        {
            add {
                if (profilerEventHandles == null)
                    profilerEventHandles += value;
            }
            remove {
                if (profilerEventHandles == null)
                    return;

                profilerEventHandles -= value;
            }
        }

        #endregion

        #region -- Interface APIMethods --
        public virtual EventHandler<OLiOEventArgs<IHostedCore>> GetCreateEventHandler { get=> createEventHandles; }
        public virtual EventHandler<OLiOEventArgs<Type>> GetRestEventHandler { get => restEventHandles; }
        public virtual EventHandler<OLiOEventArgs<Action>> GetRecycleEventHandler { get => recycleEventHandles; }
        public virtual EventHandler<OLiOEventArgs<Action<OLiOHostedPool_Profiler>>> GetProfilerEventHandler { get => profilerEventHandles; }

        public abstract void RunInternal<THostedCore>() where THostedCore : IHostedCore, new();
        public abstract void StopInternal<THostedCore>() where THostedCore : IHostedCore;
        public abstract void ReleaseInternal(Action p_Action);
        public abstract void InspectInternal(Action<OLiOHostedPool_Profiler> p_Action);


        #endregion
    }
}
