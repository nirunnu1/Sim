
using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations.SimStart
{
    public static class JOFF
    {
        public static string test = "00000000-0000-0000-0000-000000000000";
        public static void Joff(int TJoff, Guid Joff, Timer Time, int profile)
        {
            if (TJoff <= 0 && Joff == new Guid(test))
            {
                foreach (StartList a in DALTimer.Set(profile,4))
                {
                    if (a.name != null)
                    {
                        DAlActivities.Start(new Guid(a.name.ToString()));
                        DALarrTimecase.arrTimecase[3, profile-1] = a.id; DALarrGuidcase.arrayGuid[3, profile - 1] = new Guid(a.name.ToString());
                        Time.Interval = 1000;
                        Time.Start();
                        break;
                    };
                };
            };
        }
    }
}
