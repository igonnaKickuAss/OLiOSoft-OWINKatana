using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.OHosted.Interfaces
{
    /// <summary>
    /// 中间件
    /// </summary>
    public interface IMiddleware
    {
        /// <summary>
        /// 参数
        /// </summary>
        IMiddlewareParam Param { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="appBuilder">OWIN环境</param>
        void Configuration(ref IAppBuilder appBuilder);
    }
}
