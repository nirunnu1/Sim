using Simulations;
using Simulations.DAL;
using Simulations.Models;
using System;
using System.Windows.Forms;

namespace Simulations.SimStart
{
    public static class FOFF
    {
        public static string test = "00000000-0000-0000-0000-000000000000";
        public static void Foff(int TFoff,Guid Foff,Timer Time,int profile )
        {
            if (TFoff <= 0 && Foff == new Guid(test))
            {
                foreach (StartList a in DALTimer.Set(profile, 1))
                {
                    if (a.name != null)
                    {
                        DAlActivities.Start(new Guid(a.name.ToString()));
                        DALarrTimecase.arrTimecase[0, profile-1] = a.id; DALarrGuidcase.arrayGuid[0, profile - 1] = new Guid(a.name.ToString());
                        Time.Interval = 1000;
                        Time.Start();
                        break;
                    };
                };
            };
           
        }
    }
}
