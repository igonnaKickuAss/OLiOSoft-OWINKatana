using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted
{
    /// <summary>
    /// 奥利奥服务器核心_状态
    /// </summary>
    public enum OLiOHostedCore_Status
    {
        /// <summary>
        /// 繁忙（未响应）
        /// </summary>
        busy = 0,
        /// <summary>
        /// 失败
        /// </summary>
        failure,
        /// <summary>
        /// 成功
        /// </summary>
        success,
        /// <summary>
        /// 异常
        /// </summary>
        exception
    }
}
