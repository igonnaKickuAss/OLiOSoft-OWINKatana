using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.Interfaces
{
    using OLiOSoft.OSystem.Helpers;

    internal interface IStartInternal
    {
        void Start(
            object p_Sender,
            EventArgs p_EventArgs
            );

        void Stop(
            object p_Sender,
            EventArgs p_EventArgs
            );
    }
}
