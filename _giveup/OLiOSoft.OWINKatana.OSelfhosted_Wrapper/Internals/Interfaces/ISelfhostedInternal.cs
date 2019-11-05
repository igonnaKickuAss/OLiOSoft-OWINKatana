using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OSelfhosted_Wrapper.Interfaces
{
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    internal interface ISelfhostedInternal
    {
        void Open<T>() where T : IServerCore, new();
        void Close<T>() where T : IServerCore, new();
        Task OpenAsync<T>() where T : IServerCore, new();
        Task CloseAsync<T>() where T : IServerCore, new();
        void Open<T>(T p_ServerCore) where T : IServerCore, new();
        void Close<T>(T p_ServerCore) where T : IServerCore, new();
        Task OpenAsync<T>(T p_ServerCore) where T : IServerCore, new();
        Task CloseAsync<T>(T p_ServerCore) where T : IServerCore, new();

        //void Profiler();
    }
}
