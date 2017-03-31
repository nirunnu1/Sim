using Sim.Regridview;
using SimStart.SimStart;
using Simulations.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace Simulations.Models
{
    public class DALTimer
    {
        public static Timer[] Listitmer = new Timer[19];

        public static Label CountTimetext;
       
       public static int Counttime = 0;
        public static IEnumerable Set(int id,int num)
        {
 
            myDbContext Context = new myDbContext();
            testProfile[] testProfile = DALProfile.GetProfile().Where(p=>p.Uid==id).ToArray();
            testActivities[] testActivities = Context.testActivities.Where(a=>a.status==Models.testActivities.Getstatus.Wait &&a.profileUid == id && a.num == num).OrderBy(a=>a.Case.Time).ToArray();
             List<StartList> st = new List<StartList>();
            if (testActivities.Count()>=1 )
            {
                
                if (testActivities[0].Case.Numbercase == 1) {
                    st.Add(new StartList { id = Convert.ToInt32(testProfile[0].Case1), name = testActivities[0].Uid });
                    return st.ToList();
                }
                else if (testActivities[0].Case.Numbercase == 2) {
                    st.Add(new StartList { id = Convert.ToInt32(testProfile[0].Case2), name = testActivities[0].Uid });
                    return st.ToList();
                }
                else if (testActivities[0].Case.Numbercase == 3) {
                    st.Add(new StartList { id = Convert.ToInt32(testProfile[0].Case3), name = testActivities[0].Uid });
                    return st.ToList();
                }
            }
                st.Add(new StartList { id =0, name = null});
                return st.ToList();
            
        }
        public static void GetCountTimetext(Label text)
        {
             text.Text = "เวลารวาม " + Counttime.ToString();
             CountTimetext = text;
        }
        public static void CountTime_Tick(object sender, EventArgs e)
        {
            Counttime++;
            GetCountTimetext(CountTimetext);
        }
        public static Label label_casetime;
        public static void timer1_Tick(object sender, EventArgs e)
        {

            label_casetime.Text = DALarrTimecase.casetime.ToString();
            if (DALarrTimecase.casetime == 0)
            {
                Listitmer[0].Stop();
                AIStart.GetAIStart();
            }
            else if (DALarrTimecase.casetime % Form1.a == 0)
            {
                DALsim.caseadd(Form1.number);
                AIStart.GetAIStart();
            }
            AIStart.GetAIStart();
            DALarrTimecase.casetime--;

        }
        public static void timer_1_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(0, 0, DALarrGuidcase.arrayGuid[0, 0], Listitmer[1], 1, "FOFF");
            regridview.Regridview();
        }
        public static void timer_2_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(0, 1, DALarrGuidcase.arrayGuid[0, 1], Listitmer[2], 2, "FOFF");
            regridview.Regridview();

        }
        public static void timer_3_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(0, 2, DALarrGuidcase.arrayGuid[0, 2], Listitmer[3], 3, "FOFF");
            regridview.Regridview();
        }
       
        public static void timer_FonF_1_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(1, 0, DALarrGuidcase.arrayGuid[1, 0], Listitmer[4], 1, "FONF");
            regridview.Regridview();

        }
        public static void timer_FonF_2_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(1, 1, DALarrGuidcase.arrayGuid[1, 1], Listitmer[5], 2, "FONF");
            regridview.Regridview();

        }
        public static void timer_FonF_3_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(1, 2, DALarrGuidcase.arrayGuid[1, 2], Listitmer[6], 3, "FONF");
            regridview.Regridview();

        }
        public static void timer_FonJ_1_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(2, 0, DALarrGuidcase.arrayGuid[2, 0], Listitmer[7], 1, "FONJ");
            regridview.Regridview();

        }
        public static void timer_FonJ_2_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(2, 1, DALarrGuidcase.arrayGuid[2, 1], Listitmer[8], 2, "FONJ");
            regridview.Regridview();

        }
        public static void timer_FonJ_3_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(2, 2, DALarrGuidcase.arrayGuid[2, 2], Listitmer[9], 3, "FONJ");
            regridview.Regridview();

        }
        public static void timer_Joff_1_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(3, 0, DALarrGuidcase.arrayGuid[3, 0], Listitmer[10], 1, "JOFF");
            regridview.Regridview();

        }
        public static void timer_Joff_2_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(3, 1, DALarrGuidcase.arrayGuid[3, 1], Listitmer[11], 2, "JOFF");
            regridview.Regridview();
        }
        public static void timer_Joff_3_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(3, 2, DALarrGuidcase.arrayGuid[3, 2], Listitmer[12], 3, "JOFF");
            regridview.Regridview();
        }
        public static void timer_JonF_1_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(4, 0, DALarrGuidcase.arrayGuid[4, 0], Listitmer[13], 1, "JONF");
            regridview.Regridview();

        }
        public static void timer_JonF_2_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(4, 1, DALarrGuidcase.arrayGuid[4, 1], Listitmer[14], 2, "JONF");
            regridview.Regridview();

        }
        public static void timer_JonF_3_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(4, 2, DALarrGuidcase.arrayGuid[4, 2], Listitmer[15], 3, "JONF");
            regridview.Regridview();

        }
        public static void timer_JonJ_1_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(5, 0, DALarrGuidcase.arrayGuid[5, 0], Listitmer[16], 1, "JONJ");
            regridview.Regridview(); ;

        }
        public static void timer_JonJ_2_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(5, 1, DALarrGuidcase.arrayGuid[5, 1], Listitmer[17], 2, "JONJ");
            regridview.Regridview();

        }
        public static void timer_JonJ_3_Tick(object sender, EventArgs e)
        {
            Stoptimer.Check(5, 2, DALarrGuidcase.arrayGuid[5, 2], Listitmer[18], 3, "JONJ");
            regridview.Regridview();

        }
    }
}
