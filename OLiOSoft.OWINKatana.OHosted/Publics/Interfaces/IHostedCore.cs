using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.OHosted.Interfaces
{
    using OLiOSoft.OSystem.Helpers;

    /// <summary>
    /// 主机核心
    /// </summary>
    public interface IHostedCore
    {
        /// <summary>
        /// 奥利奥主机核心_状态
        /// </summary>
        OLiOHostedCore_Status Status { get; }

        /// <summary>
        /// 保持活着
        /// </summary>
        bool KeepAlive { get; }

        /// <summary>
        /// 周期时间
        /// </summary>
        int TimeSpan { get; set; }

        /// <summary>
        /// 配置，进行中间件组合
        /// </summary>
        /// <param name="p_AppBuilder">OWIN环境</param>
        void Configuration(IAppBuilder p_AppBuilder);
        
        /// <summary>
        /// 跑，运行默认服务器（使用OWIN的Katana实现(HttpListener)）
        /// </summary>
        void Run();

        /// <summary>
        /// 跑，根据类库反射你的服务器的名称，运行你的Http服务器
        /// </summary>
        /// <param name="p_EventArgs">回调函数</param>
        void Run(EventArgs p_EventArgs);

        /// <summary>
        /// 取消，关闭你的Http服务器
        /// </summary>
        /// <param name="p_EventArgs">回调函数</param>
        void Cancel(EventArgs p_EventArgs);
    }
}
