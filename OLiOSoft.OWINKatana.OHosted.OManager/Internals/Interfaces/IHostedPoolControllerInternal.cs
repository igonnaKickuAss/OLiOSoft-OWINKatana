using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager.Interfaces
{
    using OLiOSoft.OWINKatana.OHosted.Interfaces;

    internal interface IHostedPoolControllerInternal
    {
        void Create(object p_Sender, EventArgs p_EventArgs);

        void Recycle(object p_Sender, EventArgs p_EventArgs);

        void Rest(object p_Sender, EventArgs p_EventArgs);

        void Profiler(object p_Sender, EventArgs p_EventArgs);
    }
}
