using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Threading;

namespace OLiOSoft.OWINKatana.OHosted
{
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    /// <summary>
    /// 1.你只需要在奥利奥主机核心（OLiOHostedCore）中提供你的奥利奥中间件（OLiOMiddleware）或者你的应用程式（Application）。。
    /// 还有，你也可以指定一个服务器，默认使用OWIN的Katana实现。。
    /// 2.在方法Configuration中对你的奥利奥中间件（OLiOMiddleware）进行任意组合搭配。
    /// </summary>
    public abstract class OLiOHostedCore : IHostedCore
    {
        #region -- Private Data --
        private OLiOHostedCoreInternal hostedCoreInternal = null;
        private OLiOStartInternal startInternal = null;

        private OLiOHostedCore_Status status;
        private bool keepAlive = true;
        private int timeSpan = 6000;

        private int defaultPort = 9000;
        private string defaultProtocol = "http";
        private string defaultServerName = "localhost";
        private string defaultServer = "Microsoft.Owin.Host.HttpListener";

        #endregion

        #region -- Interface APIMethods --
        /// <summary>
        /// 奥利奥主机核心_状态
        /// </summary>
        public virtual OLiOHostedCore_Status Status { get => status; }

        /// <summary>
        /// 保持活着
        /// </summary>
        public virtual bool KeepAlive { get => keepAlive; }

        /// <summary>
        /// 周期时间（卡线程用的）
        /// </summary>
        public virtual int TimeSpan { get => timeSpan; set => timeSpan = value; }

        /// <summary>
        /// 配置，进行中间件组合
        /// </summary>
        /// <param name="p_AppBuilder">OWIN环境</param>
        public abstract void Configuration(IAppBuilder p_AppBuilder);

        /// <summary>
        /// 跑，运行默认服务器（使用OWIN的Katana实现(HttpListener)）
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// 跑
        /// </summary>
        /// <param name="p_EventArgs">回调函数</param>
        public abstract void Run(EventArgs p_EventArgs);

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="p_EventArgs">回调函数</param>
        public abstract void Cancel(EventArgs p_EventArgs);

        #endregion

        #region -- Protected APIMethods --
        /// <summary>
        /// 拿去用，让你少写一点代码
        /// </summary>
        protected void ORun()
        {
            ORun(defaultServer, defaultProtocol, defaultServerName, defaultPort);
        }

        /// <summary>
        /// 拿去用，让你少写一点代码
        /// </summary>
        /// <param name="p_Server">服务器</param>
        protected void ORun(string p_Server)
        {
            ORun(p_Server, defaultProtocol, defaultServerName, defaultPort);
        }

        /// <summary>
        /// 拿去用，让你少写一点代码
        /// </summary>
        /// <param name="p_Server">服务器</param>
        /// <param name="p_Protocol">协议</param>
        /// <param name="p_ServerName_IP">服务器名称_IP</param>
        /// <param name="p_Port">端口</param>
        protected void ORun(string p_Server, string p_Protocol, string p_ServerName_IP, int p_Port)
        {
            Operation();

            OLiOHostedCore_Address address = new OLiOHostedCore_Address();

            address.Set(p_Protocol, p_ServerName_IP, p_Port);

            SetStatus(OLiOHostedCore_Status.busy);
            SetKeepAlive(true);

            hostedCoreInternal.RunInternal(
                this,
                p_Server,
                address
                );

            SetStatus(OLiOHostedCore_Status.success);
            SetKeepAlive(false);
        }

        /// <summary>
        /// 拿去用，让你少写一点代码
        /// </summary>
        protected void OCancel()
        {
            Operation();

            SetStatus(OLiOHostedCore_Status.busy);

            hostedCoreInternal.CancelInternal(this);

            SetStatus(OLiOHostedCore_Status.success);
            SetKeepAlive(false);
        }

        #endregion

        #region -- Internal APIMethods --
        /// <summary>
        /// 只有调用方，把奥利奥主机核心_状态标记为繁忙状态，才能进行。
        /// </summary>
        internal void Running()
        {
            if (!(this.status == OLiOHostedCore_Status.busy))
                return;

            SetStatus(OLiOHostedCore_Status.success);

            while (keepAlive)
                Thread.Sleep(timeSpan);     //卡线程
        }

        /// <summary>
        /// 只有调用方，把奥利奥主机核心_状态标记为繁忙状态，才能进行。
        /// </summary>
        internal void Canceling()
        {
            if (!(this.status == OLiOHostedCore_Status.busy))
                return;

            SetStatus(OLiOHostedCore_Status.success);

            if (keepAlive)
            {
                SetKeepAlive(false);
                Thread.Sleep(timeSpan);     //卡线程
            }
        }

        #endregion

        #region -- Private APIMethods --
        private void Operation()
        {
            if (startInternal == null)
                startInternal = new OLiOStartInternal();

            if (hostedCoreInternal == null)
            {
                hostedCoreInternal = new OLiOHostedCoreInternal();
                hostedCoreInternal.StartEventHandler += startInternal.Start;
                hostedCoreInternal.StopEventHandler += startInternal.Stop;
            }
        }

        private void SetStatus(OLiOHostedCore_Status p_Status)
        {
            this.status = p_Status;
        }

        private void SetKeepAlive(bool b)
        {
            this.keepAlive = b;
        }

        #endregion
    }
}
