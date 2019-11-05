using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OServer
{
    using Microsoft.Owin.Hosting;
    using OLiOSoft.OWINKatana.OServer.Interfaces;
    using Owin;

    /// <summary>
    /// 1.你只需要在奥利奥服务器核心（OLiOServerCore）中提供你的奥利奥中间件（OLiOMiddleware）或者你的应用程式（Application）。。
    /// 2.在方法Configuration中对你的奥利奥中间件（OLiOMiddleware）进行任意组合搭配。
    /// </summary>
    public abstract class OLiOServerCore : IServerCore
    {
        #region -- Private Data --
        private OLiOServerCoreInternal serverCoreInternal = null;

        private OLiOServerCore_Status status;

        #endregion

        #region -- Interface APIMethods --
        public virtual OLiOServerCore_Status Status { get => status; }

        public abstract void Configuration(IAppBuilder p_AppBuilder);
        public abstract void Run();


        #endregion

        #region -- Protected APIMethods --
        protected void ORun()
        {
            if (serverCoreInternal == null)
            {
                serverCoreInternal = new OLiOServerCoreInternal();
                serverCoreInternal.Current = new OLiOStartInternal();
            }

            serverCoreInternal.RunInternal(this);
        }

        #endregion
    }
}
