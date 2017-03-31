using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations.SimStart
{
    public static class FonJ
    {
        public static void Fonj(int TFonJ, Guid FonJ, Timer Time, int profile)
        {
            if (TFonJ <= 0 && FonJ == DALarrGuidcase.GetGuid)
            {
                foreach (StartList a in DALTimer.Set(profile, 3))
                {
                    if (a.name != null)
                    {
                        DAlActivities.Start(new Guid(a.name.ToString()));
                        DALarrTimecase.arrTimecase[2, profile-1] = a.id; DALarrGuidcase.arrayGuid[2, profile - 1] = new Guid(a.name.ToString());
                        Time.Interval = 1000;
                        Time.Start();
                        break;
                    };
                };
            };
        }
    }
}
