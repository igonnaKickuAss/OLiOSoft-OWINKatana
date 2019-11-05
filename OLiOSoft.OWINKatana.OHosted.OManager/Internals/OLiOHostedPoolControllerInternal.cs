using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;
    using OLiOSoft.OWINKatana.OHosted.OManager.Abstracts;

    internal class OLiOHostedPoolControllerInternal : AHostedPoolControllerInternal
    {
        #region -- Override APIMethods --
        public override void Create(object p_Sender, EventArgs p_EventArgs)
        {
            OLiOEventArgs<IHostedCore> oEventArgs = (OLiOEventArgs<IHostedCore>)p_EventArgs;

            Stack <OLiOTask<EventArgs>> livePool = OLiOHostedPoolInternal.liveOLiOHostedPool;
            Stack<OLiOTask<EventArgs>> reycPool = OLiOHostedPoolInternal.recycleOLiOHostedPool;
            Dictionary<Type, OLiOTask<EventArgs>> wkMapper = OLiOHostedPoolInternal.workOLiOHostedMapper;

            OLiOTask<EventArgs> oTask = null;

            if (livePool.Count > 0)
            {
                oTask = livePool.Pop();

                wkMapper[oEventArgs.Data.GetType()] = oTask;

                oTask.StartAsync();

                return;
            }

            if (reycPool.Count > 0)
            {
                oTask = reycPool.Pop();

                wkMapper[oEventArgs.Data.GetType()] = oTask;

                oTask.StartAsync();

                return;
            }

            //TODO.. 要给参数吗？
            //.. 给他一个回调函数
            oTask = new OLiOTask<EventArgs>(new OLiOEventArgs<Action<IHostedCore, bool>>(TaskComplete));

            wkMapper[oEventArgs.Data.GetType()] = oTask;

            oTask.CoreRun = oEventArgs.Data.Run;
            oTask.CoreCancel = oEventArgs.Data.Cancel;

            oTask.StartAsync();
        }

        public override void Recycle(object p_Sender, EventArgs p_EventArgs)
        {
            OLiOEventArgs<Action> oEventArgs = (OLiOEventArgs<Action>)p_EventArgs;

            Stack<OLiOTask<EventArgs>> livePool = OLiOHostedPoolInternal.liveOLiOHostedPool;
            Stack<OLiOTask<EventArgs>> reycPool = OLiOHostedPoolInternal.recycleOLiOHostedPool;

            int length = livePool.Count;
            for (int i = 0; i < length; i++)
                reycPool.Push(livePool.Pop());

            oEventArgs.Data.Invoke();
        }

        public override void Rest(object p_Sender, EventArgs p_EventArgs)
        {
            OLiOEventArgs<Type> oEventArgs = (OLiOEventArgs<Type>)p_EventArgs;

            Dictionary<Type, OLiOTask<EventArgs>> wkMapper = OLiOHostedPoolInternal.workOLiOHostedMapper;

            OLiOTask<EventArgs> oTask = null;

            if (!wkMapper.TryGetValue(oEventArgs.Data, out oTask))
                return;

            oTask.StopAsync();
        }

        public override void Profiler(object p_Sender, EventArgs p_EventArgs)
        {
            OLiOEventArgs<Action<OLiOHostedPool_Profiler>> oEventArgs = (OLiOEventArgs<Action<OLiOHostedPool_Profiler>>)p_EventArgs;

            Stack<OLiOTask<EventArgs>> livePool = OLiOHostedPoolInternal.liveOLiOHostedPool;
            Stack<OLiOTask<EventArgs>> reycPool = OLiOHostedPoolInternal.recycleOLiOHostedPool;
            Dictionary<Type, OLiOTask<EventArgs>> wkMapper = OLiOHostedPoolInternal.workOLiOHostedMapper;

            OLiOHostedPool_Profiler profiler = new OLiOHostedPool_Profiler();
            profiler.Set(wkMapper.Count, livePool.Count, reycPool.Count);

            oEventArgs.Data.Invoke(profiler);
        }

        #endregion

        #region -- Private APIMethods --
        private void TaskComplete(IHostedCore p_HostCore, bool isComplete)
        {
            if (!isComplete)
                return;

            Stack<OLiOTask<EventArgs>> livePool = OLiOHostedPoolInternal.liveOLiOHostedPool;
            Dictionary<Type, OLiOTask<EventArgs>> wkMapper = OLiOHostedPoolInternal.workOLiOHostedMapper;

            OLiOTask<EventArgs> oTask = null;

            Type key = p_HostCore.GetType();

            if (!wkMapper.TryGetValue(key, out oTask))
                return;

            wkMapper.Remove(key);

            livePool.Push(oTask);
        }

        #endregion

    }
}
