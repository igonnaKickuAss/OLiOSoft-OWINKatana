using Owin;

namespace OLiOSoft.OWINKatana.OServer
{
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    public abstract class OLiOMiddleware : IMiddleware
    {
        public abstract IMiddlewareParam Param { get; set; }

        public abstract void Configuration(ref IAppBuilder appBuilder);
    }
}
