using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager.Abstracts
{
    using OLiOSoft.OWINKatana.OHosted.Interfaces;
    using OLiOSoft.OWINKatana.OHosted.OManager.Interfaces;

    internal abstract class AHostedPoolControllerInternal : IHostedPoolControllerInternal
    {
        #region -- Interface APIMethods --
        public abstract void Create(object p_Sender, EventArgs p_EventArgs);
        public abstract void Profiler(object p_Sender, EventArgs p_EventArgs);
        public abstract void Recycle(object p_Sender, EventArgs p_EventArgs);
        public abstract void Rest(object p_Sender, EventArgs p_EventArgs);

        #endregion
    }
}
