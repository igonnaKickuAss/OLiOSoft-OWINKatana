using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OLiOSoft.OWINKatana.OServer
{
    using OLiOSoft.OWINKatana.OServer.Abstracts;
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    internal class OLiOServerCoreInternal : AServerCoreInternal
    {
        #region -- Override APIMethods --
        public override void RunInternal(IServerCore p_ServerCore)
        {
            this.Current.Start(p_ServerCore.Configuration);
        }


        #endregion
    }
}
