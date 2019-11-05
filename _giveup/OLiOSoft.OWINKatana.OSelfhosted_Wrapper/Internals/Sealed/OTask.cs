using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OSelfhosted_Wrapper.Sealed
{
    using OLiOSoft.OWINKatana.OServer.Interfaces;

    internal sealed class OTask<TServerCore>
        where TServerCore : IServerCore
    {
        #region -- Private Data --
        private TServerCore core;

        private Task task = null;

        #endregion

        #region -- Public ShotC --
        TServerCore Core
        {
            get {
                return core;
            }
            set {
                if (value == null)
                {
                    task = null;
                    return;
                }

                core = value;

                if (task == null)
                    task = new Task(core.Run);
            }
        }

        #endregion

        #region -- Public APIMethods --
        public void StartSync()
        {
            if (task == null)
                return;

            task.RunSynchronously();
        }

        public void StartAsync()
        {
            if (task == null)
                return;

            task.Start();
        }

        public void Stop()
        {
            if (core == null)
                return;
            
            
        }

        #endregion




    }
}
