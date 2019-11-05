using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OSelfhosted_Wrapper
{
    using OLiOSoft.OSystem.Singleton;
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    public sealed class OSelfhostedManager : OLiOSingletonMaster<OSelfhostedManager>
    {
        private OSelfhostedManager(int fourBytes) : base(fourBytes)
        {
            selfhostedInternal = new OLiOSelfhostedInternal();
        }

        #region -- Private Data --
        private OLiOSelfhostedInternal selfhostedInternal = null;

        #endregion

        #region -- Public APIMethods --
        /// <summary>
        /// 开启一个新的服务器，根据你给定的类型实例化并且放入工作池子中（TaskLivePool）
        /// </summary>
        /// <typeparam name="T">奥利奥服务器</typeparam>
        public void OpenNewServer<T>() where T : IServerCore
        {
            
        }

        /// <summary>
        /// 开启一个新的服务器，你来实例化他我来把他放入工作池子中（TaskLivePool）
        /// </summary>
        /// <typeparam name="T">奥利奥服务器</typeparam>
        /// <param name="p_ServerCore">形参</param>
        public void OpenNewServer<T>(T p_ServerCore) where T : IServerCore
        {

        }

        /// <summary>
        /// 开启一个服务器，根据你给定的类型在回收池子中寻找（TaskRecyclePool）
        /// </summary>
        /// <typeparam name="T">奥利奥服务器</typeparam>
        public void OpenServer<T>() where T : IServerCore
        {

        }

        /// <summary>
        /// 开启一个服务器，根据你给的名称在回收池子中寻找（TaskRecyclePool）
        /// </summary>
        /// <typeparam name="T">奥利奥服务器</typeparam>
        /// <param name="p_ServerCoreName">形参</param>
        public void OpenServer<T>(string p_ServerCoreName) where T : IServerCore
        {
            
        }

        /// <summary>
        /// 关闭服务器，根据你给定的类型在工作池子中寻找（TaskLivePool）
        /// </summary>
        /// <typeparam name="T">奥利奥服务器</typeparam>
        public void CloseServer<T>() where T : IServerCore
        {

        }

        /// <summary>
        /// 关闭服务器，根据你给的名称在工作池子中寻找（TaskLivePool）
        /// </summary>
        /// <typeparam name="T">奥利奥服务器</typeparam>
        /// <param name="p_ServerCoreName">形参</param>
        public void CloseServer<T>(string p_ServerCoreName) where T: IServerCore
        {

        }


        #endregion
    }
}
