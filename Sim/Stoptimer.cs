
using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations
{
    public static class Stoptimer
    {
        public static bool Check(int num1,int num2 , Guid Uid, Timer timer, int id,string Ai)
        {

            if (DALarrTimecase.arrTimecase[num1, num2] <= 0 && Uid != DALarrGuidcase.GetGuid)
            {
                switch (Ai)
                {
                    case "FOFF":
                        DAlActivities.End(Uid);
                        DALarrTimecase.arrTimecase[0, id - 1] = 0; DALarrGuidcase.arrayGuid[0, id - 1] = DALarrGuidcase.GetGuid;
                        ColorLB.comitcase[0,0] = ColorLB.comitcase[0, 0] + 1;
                        timer.Stop();
                        
                        return true;
                    case "FONF":
                        DAlActivities.End(Uid);
                        DALarrTimecase.arrTimecase[1, id - 1] = 0; DALarrGuidcase.arrayGuid[1, id - 1] = DALarrGuidcase.GetGuid;
                        ColorLB.comitcase[0, 1] = ColorLB.comitcase[0, 1]+1;
                        timer.Stop();
                        return true;
                    case "FONJ":
                        DAlActivities.End(Uid);
                        DALarrTimecase.arrTimecase[2, id - 1] = 0; DALarrGuidcase.arrayGuid[2, id - 1] = DALarrGuidcase.GetGuid;
                        ColorLB.comitcase[0, 2] = ColorLB.comitcase[0, 2+1];
                        timer.Stop();
                        return true;
                    case "JOFF":

                        DAlActivities.End(Uid);
                        DALarrTimecase.arrTimecase[3, id - 1] = 0; DALarrGuidcase.arrayGuid[3, id - 1] = DALarrGuidcase.GetGuid;
                        ColorLB.comitcase[0, 3] = ColorLB.comitcase[0, 3] + 1;
                        timer.Stop();
                        return true;
                    case "JONF":


                        DAlActivities.End(Uid);
                        DALarrTimecase.arrTimecase[4, id - 1] = 0; DALarrGuidcase.arrayGuid[4, id - 1] = DALarrGuidcase.GetGuid;
                        ColorLB.comitcase[0, 4] = ColorLB.comitcase[0, 4] + 1;
                        timer.Stop();
                        return true;
                    case "JONJ":

                        DAlActivities.End(Uid);
                        DALarrTimecase.arrTimecase[5, id - 1] = 0; DALarrGuidcase.arrayGuid[5, id - 1] = DALarrGuidcase.GetGuid;
                        ColorLB.comitcase[0, 5] = ColorLB.comitcase[0, 5] + 1;
                        timer.Stop();
                        return true;
                    default:
                        return false;
                }
            }
            else {
                DALarrTimecase.arrTimecase[num1, num2]--;
                return false;
            }
           
        }

    }
}
