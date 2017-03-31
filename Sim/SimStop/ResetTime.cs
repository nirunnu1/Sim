using Simulations.DAL;
using System.Windows.Forms;

namespace Simulations.SimStop
{
    public static class ResetTime
    {
        public static void ResetTimer(Timer T1, Timer T2, Timer T3,
                                       Timer AT1, Timer AT2, Timer AT3, 
                                       Timer BT1, Timer BT2, Timer BT3,
                                       Timer CT1, Timer CT2, Timer CT3,
                                       Timer DT1, Timer DT2, Timer DT3,
                                       Timer ET1, Timer ET2, Timer ET3, Timer FT3)
        {
            T1.Stop();T2.Stop();T3.Stop();
            AT1.Stop(); AT2.Stop(); AT3.Stop();
            BT1.Stop(); BT2.Stop(); BT3.Stop();
            CT1.Stop(); CT2.Stop(); CT3.Stop();
            DT1.Stop(); DT2.Stop(); DT3.Stop();
            ET1.Stop(); ET2.Stop(); ET3.Stop();
            FT3.Stop();


        }
        public static void ResetData()
        {
            DALarrTimecase.ResetarrTimecaseALL();
            DALarrGuidcase.ResetGuidAll();
            ColorLB.Resetcomitcase();
        }
    }
}
