using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OServer.Interfaces
{
    internal interface IStartInternal
    {
        void Start(Action<IAppBuilder> p_Configuration);

        void Start(Action<IAppBuilder> p_Configuration, string p_Port);
    }
}
