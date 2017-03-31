using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations.SimStart
{
    public static class JonF
    {
        public static void Jonf(int TJonF, Guid JonF, Timer Time, int profile)
        {
            if (TJonF <= 0 && JonF == DALarrGuidcase.GetGuid)
            {
                foreach (StartList a in DALTimer.Set(profile, 5))
                {
                    if (a.name != null)
                    {
                        DAlActivities.Start(new Guid(a.name.ToString()));
                        DALarrTimecase.arrTimecase[4, profile-1] = a.id; DALarrGuidcase.arrayGuid[4, profile - 1] = new Guid(a.name.ToString());
                        Time.Interval = 1000;
                        Time.Start();
                        break;
                    };
                };
            };
        }
    }
}
