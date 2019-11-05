using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OLiOSoft.OWINKatana.OHosted.OManager
{
    internal struct OLiOHostedPool_Profiler
    {
        //apiMethods
        public void Set(int wkNum, int lvNum, int ryclNum)
        {
            currentWorkingOLiOTaskNum = wkNum.ToString();
            currentLiveOLiOTaskNum = lvNum.ToString();
            currentRecycleOLiOTaskNum = ryclNum.ToString();

            allOLiOTaskNum = (wkNum + lvNum + ryclNum).ToString();
        }

        //data
        public string allOLiOTaskNum;
        public string currentWorkingOLiOTaskNum;
        public string currentLiveOLiOTaskNum;
        public string currentRecycleOLiOTaskNum;

    }
}
