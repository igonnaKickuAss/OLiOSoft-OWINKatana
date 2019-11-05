using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.OServer.Interfaces
{
    public interface IServerCore
    {
        OLiOServerCore_Status Status { get; }

        void Configuration(IAppBuilder p_AppBuilder);
        void Run();
    }
}
