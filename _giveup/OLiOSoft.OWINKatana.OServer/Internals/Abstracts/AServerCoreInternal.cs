using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OServer.Abstracts
{
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    internal abstract class AServerCoreInternal : IServerCoreInternal
    {
        #region -- Private Data --
        private IStartInternal current;

        #endregion

        #region -- Interface APIMethods --
        public virtual IStartInternal Current { get => current; set => current = value; }

        public abstract void RunInternal(IServerCore p_ServerCore);


        #endregion
    }
}
