using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OSelfhosted_Wrapper.Abstracts
{
    using OLiOSoft.OWINKatana.OSelfhosted_Wrapper.Interfaces;
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    internal abstract class ASelfhostedInternal : ISelfhostedInternal
    {
        #region -- Interface APIMethods --
        public abstract void Close<T>() where T : IServerCore, new();
        public abstract void Close<T>(T p_ServerCore) where T : IServerCore, new();
        public abstract Task CloseAsync<T>() where T : IServerCore, new();
        public abstract Task CloseAsync<T>(T p_ServerCore) where T : IServerCore, new();
        public abstract void Open<T>() where T : IServerCore, new();
        public abstract void Open<T>(T p_ServerCore) where T : IServerCore, new();
        public abstract Task OpenAsync<T>() where T : IServerCore, new();
        public abstract Task OpenAsync<T>(T p_ServerCore) where T : IServerCore, new();

        #endregion
    }
}
