using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OLiOSoft.OWINKatana.OHosted.Abstracts
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    internal abstract class AStartInternal : IStartInternal
    {
        #region -- Interface APIMethods --
        public abstract void Start(object p_Sender, EventArgs p_EventArgs);
        public abstract void Stop(object p_Sender, EventArgs p_EventArgs);

        #endregion
    }
}
