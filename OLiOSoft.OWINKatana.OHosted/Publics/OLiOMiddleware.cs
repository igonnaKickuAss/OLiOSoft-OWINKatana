using Owin;

namespace OLiOSoft.OWINKatana.OHosted
{
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    /// <summary>
    /// 奥利奥中间件
    /// </summary>
    public abstract class OLiOMiddleware : IMiddleware
    {
        #region -- Private Data --
        private IMiddlewareParam param;

        #endregion

        #region -- Interface APIMethods --
        /// <summary>
        /// 中间件参数
        /// </summary>
        public virtual IMiddlewareParam Param { get => param; set => param = value; }

        /// <summary>
        /// 配置（在介里进行appBuilder.Use，你也可以把中间件参数喂给他，如果有的话）
        /// </summary>
        /// <param name="appBuilder">OWIN环境</param>
        public abstract void Configuration(ref IAppBuilder appBuilder);

        #endregion
    }
}
