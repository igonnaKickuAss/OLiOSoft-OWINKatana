using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.OServer.Abstracts
{
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    internal abstract class AStartInternal : IStartInternal
    {
        #region -- Interface APIMethods --
        public abstract void Start(Action<IAppBuilder> p_Configuration);
        public abstract void Start(Action<IAppBuilder> p_Configuration, string p_Port);

        #endregion
    }
}
