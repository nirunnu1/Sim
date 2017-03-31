using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations.SimStart
{
    public static class FonF
    {
        public static string test = "00000000-0000-0000-0000-000000000000";
        public static void Fonf(int TFonF, Guid FonF, Timer Time, int profile)
        {
            if (TFonF <= 0 && FonF == new Guid(test))
            {
                foreach (StartList a in DALTimer.Set(profile, 2))
                {
                    if (a.name != null)
                    {
                        DAlActivities.Start(new Guid(a.name.ToString()));
                        DALarrTimecase.arrTimecase[1, profile-1] = a.id; DALarrGuidcase.arrayGuid[1, profile - 1] = new Guid(a.name.ToString());
                        Time.Interval = 1000;
                        Time.Start();
                  
                        break;
                    };
                };
            };
        }
    }
}
