using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OSelfhosted_Wrapper
{
    using OLiOSoft.OWINKatana.OSelfhosted_Wrapper.Abstracts;

    internal class OLiOSelfhostedInternal : ASelfhostedInternal
    {
        #region -- Override APIMethods --
        public override void Close<T>()
        {
            throw new NotImplementedException();
        }

        public override void Close<T>(T p_ServerCore)
        {
            throw new NotImplementedException();
        }

        public override Task CloseAsync<T>()
        {
            throw new NotImplementedException();
        }

        public override Task CloseAsync<T>(T p_ServerCore)
        {
            throw new NotImplementedException();
        }

        public override void Open<T>()
        {
            throw new NotImplementedException();
        }

        public override void Open<T>(T p_ServerCore)
        {
            throw new NotImplementedException();
        }

        public override Task OpenAsync<T>()
        {
            throw new NotImplementedException();
        }

        public override Task OpenAsync<T>(T p_ServerCore)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
