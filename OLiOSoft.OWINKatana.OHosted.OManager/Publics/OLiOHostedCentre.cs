using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager
{
    using OLiOSoft.OSystem.Singleton;
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    /// <summary>
    /// 奥利奥主机中心（似一个单例）
    /// </summary>
    sealed public class OLiOHostedCentre : OLiOSingletonMaster<OLiOHostedCentre>
    {
        private OLiOHostedCentre(int fourBytes) : base(fourBytes)
        {

        }

        #region -- Private Data --
        private OLiOHostedCentreInternal hostedCentreInternal = null;

        private OLiOHostedPoolControllerInternal hostedPoolControllerInternal = null;

        #endregion

        #region -- Public APIMethods --
        /// <summary>
        /// 运行指定的主机
        /// </summary>
        /// <typeparam name="THostedCore">主机</typeparam>
        public void Run<THostedCore>() where THostedCore : IHostedCore, new()
        {
            Operation();

            hostedCentreInternal.RunInternal<THostedCore>();
        }

        /// <summary>
        /// 停止指定的主机
        /// </summary>
        /// <typeparam name="THostedCore">主机</typeparam>
        public void Stop<THostedCore>() where THostedCore : IHostedCore
        {
            Operation();

            hostedCentreInternal.StopInternal<THostedCore>();
        }

        /// <summary>
        /// 回收所以没有工作空闲的主机
        /// </summary>
        public void Release()
        {
            Operation();

            hostedCentreInternal.ReleaseInternal(LogConsole);
        }

        /// <summary>
        /// 检查当前池子数据
        /// </summary>
        public void Inspect()
        {
            Operation();

            hostedCentreInternal.InspectInternal(LogConsole);
        }

        /// <summary>
        /// 检查当前池子数据
        /// </summary>
        /// <param name="p_Sender">this</param>
        /// <param name="p_EventArgs">数据鸡肋</param>
        public void Inspect(object p_Sender, EventArgs p_EventArgs)
        {
            Operation();

            OLiOEventArgs<Action<string[]>> oEventArgs = p_EventArgs as OLiOEventArgs<Action<string[]>>;

            hostedCentreInternal.InspectInternal(LogConsole);

            if (oEventArgs != null)
                oEventArgs.Data.Invoke(profiler);
        }

        string[] profiler = null;

        #endregion

        #region -- Private APIMethods --
        private void Operation()
        {
            if (hostedPoolControllerInternal == null)
                hostedPoolControllerInternal = new OLiOHostedPoolControllerInternal();

            if (hostedCentreInternal == null)
            {
                hostedCentreInternal = new OLiOHostedCentreInternal();
                hostedCentreInternal.CreateEventHandler += hostedPoolControllerInternal.Create;
                hostedCentreInternal.RestEventHandler += hostedPoolControllerInternal.Rest;
                hostedCentreInternal.RecycleEventHandler += hostedPoolControllerInternal.Recycle;
                hostedCentreInternal.ProfilerEventHandler += hostedPoolControllerInternal.Profiler;
            }
        }


        private void LogConsole(OLiOHostedPool_Profiler profiler)
        {
            this.profiler = new string[4]
            {
                $"总任务数：{profiler.allOLiOTaskNum}",
                $"正在工作的任务数：{profiler.currentWorkingOLiOTaskNum}",
                $"空闲状态的任务数：{profiler.currentLiveOLiOTaskNum}",
                $"已经被回收的任务数：{profiler.currentRecycleOLiOTaskNum}"
            };

            Console.WriteLine(this.profiler[0]);
            Console.WriteLine(this.profiler[1]);
            Console.WriteLine(this.profiler[2]);
            Console.WriteLine(this.profiler[3]);
        }

        private void LogConsole()
        {
            Console.WriteLine("Release Done..");
        }


        #endregion
    }
}
