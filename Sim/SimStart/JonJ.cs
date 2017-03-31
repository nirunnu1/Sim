using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations.SimStart
{
    public static class JonJ
    {
        public static void Jonj(int TJonJ, Guid JonJ, Timer Time, int profile)
        {
            if (TJonJ <= 0 && JonJ == DALarrGuidcase.GetGuid)
            {
                foreach (StartList a in DALTimer.Set(profile, 6))
                {
                    if (a.name != null)
                    {
                        DAlActivities.Start(new Guid(a.name.ToString()));
                        DALarrTimecase.arrTimecase[5, profile - 1] = a.id; DALarrGuidcase.arrayGuid[5, profile - 1] = new Guid(a.name.ToString());
                        Time.Interval = 1000;
                        Time.Start();
                        break;
                    };
                };
            };
        }
    }
}
