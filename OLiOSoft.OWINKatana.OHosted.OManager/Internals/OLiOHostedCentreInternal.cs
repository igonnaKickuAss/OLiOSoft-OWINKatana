using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager
{
    using OLiOSoft.OWINKatana.OHosted.Interfaces;
    using OLiOSoft.OWINKatana.OHosted.OManager.Abstracts;
    using OSystem.Helpers;

    internal class OLiOHostedCentreInternal : AHostedCentreInternal
    {
        #region -- Override APIMethods --
        public override void RunInternal<THostedCore>()
        {
            if (this.GetCreateEventHandler == null)
                return;

            IHostedCore hCore = new THostedCore();

            this.GetCreateEventHandler.Invoke(this, new OLiOEventArgs<IHostedCore>(hCore));
        }

        public override void StopInternal<THostedCore>()
        {
            if (this.GetRestEventHandler == null)
                return;

            this.GetRestEventHandler.Invoke(this, new OLiOEventArgs<Type>(typeof(THostedCore)));
        }

        public override void ReleaseInternal(Action p_Action)
        {
            if (this.GetRecycleEventHandler == null)
                return;

            this.GetRecycleEventHandler.Invoke(this, new OLiOEventArgs<Action>(p_Action));
        }

        public override void InspectInternal(Action<OLiOHostedPool_Profiler> p_Action)
        {
            if (this.GetProfilerEventHandler == null)
                return;

            this.GetProfilerEventHandler.Invoke(this, new OLiOEventArgs<Action<OLiOHostedPool_Profiler>>(p_Action));
        }


        #endregion
    }

}

