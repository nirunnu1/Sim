using DevExpress.XtraEditors;
using SimStart.SimStart;
using Simulations;
using Simulations.Models;
using Simulations.progressBarControl;
using Simulations.SimStop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sim.Regridview
{
   public  class regridview
    {
        public static void Regridview()
        {
            AIStart.GetAIStart();
            ColorLB. ColorSpinedit();
            TextLB();
            buttononOff();
        }

        public static void checkStart()
        {

            if (DALarrTimecase.casetime > 0)
            {
                Form1. a = DALarrTimecase.casetime / Form1.casenum;
                DALTimer.Listitmer[0].Enabled = true;
                DALTimer.Listitmer[0].Interval = 1000;
                DALTimer.Listitmer[0].Start();
                Form1. OnOff = 2;

            }
            else
            {
                DALMessageBox.MessageBoxset(DALMessageBox.MBset.settime);

            }
        }
        public static Button Bt_stop;
        public static Button button3;
        public static Button button4;
        public static Button Bt_set;
        public static Label lB_number;
        public static ProgressBarControl progressBar_case;
        public static int[] RandomizeStrings(int size)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(1, 100));
            }
            var sorted = list.ToList();
            int[] result = new int[size];
            int index = 0;
            foreach (int pair in sorted)
            {
                if (pair <= 50) { result[index] = 1; }
                else if (pair < 70) { result[index] = 2; }
                else { result[index] = 3; }
                index++;
            }
            return result;
        }
        public static int[] casegen = new int[Form1.casenum];
        public static void buttononOff()
        {
         
            Bt_stop.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            Bt_set.Visible = false;
            if (Form1.OnOff == 2)
            {
                Bt_stop.Visible = true;
                Bt_stop.Location = new Point(482, 27);
                if (DAlActivities.GetActivitiesEnd(Form1.number) == Form1.casenum * 6)
                {
                    if (Form1.number ==1)
                    {
                        Form1.OnOff = 0;
                        MessageBox.Show("เสร็จสิ้น");
                        Bt_stop.Visible = true;
                        Bt_stop.Location = new Point(482, 27);
                        progressBar_case.EditValue = 0;
                        Form1.number = 1;

                    }
                    else
                    {
                        ResetTimer();
                        Form1.number = Form1.number + 1;
                        lB_number.Text = Form1.number.ToString();
                        progressBarSetting.progress(progressBar_case, 10);
                        DALarrTimecase.casetime = Form1.casetimeindex;
                        checkStart();
                    }
                };
            }
            else if (Form1.OnOff == 1)
            {
                button3.Visible = true;
                button4.Visible = true;
            }
            else
            {
                Bt_set.Visible = true;
                button4.Visible = true;
                Bt_set.Location = new Point(482, 27);
            }

        }
        public static Label label_casenum;
        public static Label label_casetime;
        public static void TextLB()
        {
            label_casenum.Text = DAlActivities.GetActivitiesEnd(Form1.number) + "/" + Form1.casenum.ToString();
            label_casetime.Text = DALarrTimecase.casetime.ToString();
            ColorLB.ShowTextLabel();
            AIStart.GetAIStart();
        }

        public static void ResetTimer()
        {
            ResetTime.ResetTimer(DALTimer.Listitmer[0], DALTimer.Listitmer[1], DALTimer.Listitmer[2], DALTimer.Listitmer[3],
                                               DALTimer.Listitmer[4], DALTimer.Listitmer[5], DALTimer.Listitmer[6],
                                               DALTimer.Listitmer[7], DALTimer.Listitmer[8], DALTimer.Listitmer[9],
                                               DALTimer.Listitmer[10], DALTimer.Listitmer[11], DALTimer.Listitmer[12],
                                               DALTimer.Listitmer[13], DALTimer.Listitmer[14], DALTimer.Listitmer[15],
                                               DALTimer.Listitmer[16], DALTimer.Listitmer[17], DALTimer.Listitmer[18]
                                               );
            ResetTime.ResetData();

        }
    }
}
