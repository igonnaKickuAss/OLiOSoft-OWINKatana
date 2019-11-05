using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.OServer.Interfaces
{
    public interface IMiddleware
    {
        IMiddlewareParam Param { get; set; }

        void Configuration(ref IAppBuilder appBuilder);
    }
}
