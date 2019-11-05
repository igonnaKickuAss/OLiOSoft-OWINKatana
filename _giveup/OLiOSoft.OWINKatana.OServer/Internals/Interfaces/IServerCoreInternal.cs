using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OServer.Interfaces
{
    internal interface IServerCoreInternal
    {
        IStartInternal Current { get; set; }

        void RunInternal(IServerCore p_ServerCore);
    }
}
