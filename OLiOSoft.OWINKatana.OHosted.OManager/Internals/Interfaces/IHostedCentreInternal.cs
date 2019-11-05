using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager.Interfaces
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    internal interface IHostedCentreInternal
    {
        EventHandler<OLiOEventArgs<IHostedCore>> GetCreateEventHandler { get; }
        EventHandler<OLiOEventArgs<Type>> GetRestEventHandler { get; }
        EventHandler<OLiOEventArgs<Action>> GetRecycleEventHandler { get; }
        EventHandler<OLiOEventArgs<Action<OLiOHostedPool_Profiler>>> GetProfilerEventHandler { get; }


        void RunInternal<THostedCore>() where THostedCore : IHostedCore, new();
        void StopInternal<THostedCore>() where THostedCore : IHostedCore;
        void ReleaseInternal(Action p_Action);
        void InspectInternal(Action<OLiOHostedPool_Profiler> p_Action);
    }
}
