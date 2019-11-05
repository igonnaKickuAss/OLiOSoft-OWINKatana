using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager
{
    using OLiOSoft.OSystem.Helpers;

    static internal class OLiOHostedPoolInternal
    {
        /// <summary>
        /// 正在工作，（繁忙）
        /// </summary>
        static public Dictionary<Type, OLiOTask<EventArgs>> workOLiOHostedMapper = new Dictionary<Type, OLiOTask<EventArgs>>();

        /// <summary>
        /// 活着可以被拿来用的，（待命）
        /// </summary>
        static public Stack<OLiOTask<EventArgs>> liveOLiOHostedPool = new Stack<OLiOTask<EventArgs>>();

        /// <summary>
        /// 死掉需要被复活的，（已回收）
        /// </summary>
        static public Stack<OLiOTask<EventArgs>> recycleOLiOHostedPool = new Stack<OLiOTask<EventArgs>>();
    }
}
