using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace Simulations
{
    public class ColorLB
    {
        //public static int comitcase1 = 0; public static int comitcase2 = 0; public static int comitcase3 = 0;
        //public static int comitcase4 = 0; public static int comitcase5 = 0; public static int comitcase6 = 0;
        public static SpinEdit[] spinEdit = new SpinEdit[2];
        public static void ColorSpinedit()
        {
            ///spinEdit_casenum
            if (spinEdit[0].Value == 0) { spinEdit[0].ForeColor = Color.Red; }
            else { spinEdit[0].ForeColor = Color.Lime; }
            ///spinEdit_casetime
            if (spinEdit[1].Value == 0) { spinEdit[1].ForeColor = Color.Red; }
            else { spinEdit[1].ForeColor = Color.Lime; }


        }
        public static void colorLBset(int number1 , int number2 , Label label)
        {
            if (number1== number2) { label.ForeColor = Color.Lime; }
            else { label.ForeColor = Color.Red; }

        }

        public static void ShowTextLabel()
        {
            GettextTime();
            GettextCaseSum();
        }
        /// <summary>
        /// text labels time AAA BBB CCC
        /// </summary>
        public static List<Label> ListLabelstextTime = new List<Label>();
        public static void SetListLabelstextTime(Label item)
        {
            ListLabelstextTime.Add(item);
        }
        public static string textTimeset(int format)
        {
            string text; int[] arr = new int[3];
            for (int i = 0;i<=2;i++  )
            {
                arr[i] = DALarrTimecase.arrTimecase[format, i];         
            }
            text = string.Format(" A : {0} B :{1} C {2} ", arr[0], arr[1], arr[2]); 
            return text;
        }
        public static void GettextTime()
        {
            string text;
            int i = 0;
            foreach(Label item in ListLabelstextTime)
            {
                item.Text = ColorLB.textTimeset(i);
                i++;
            }
        }
        /// <summary>
        /// text labels Case Sum AAA BBB CCC
        /// </summary>
        public static int[,] comitcase = new int[,]
       {
             {0,0,0,0,0,0}
       };
        public static void Resetcomitcase()
        {
            for (int i=0;i<=5; i++)
            {
                comitcase[0,i] = 0;
            }
        }
        public static List<Label> ListLabelstextCaseSum = new List<Label>();
        public static void SetListLabelstextCaseSum(Label item)
        {
            ListLabelstextCaseSum.Add(item);
        }
        public static string CaseSumset(int format)
        {
            string text; 
            text = string.Format("งานรวม : " + comitcase[0, format] + "/" + Form1.casenum);
            return text;
        }
        public static void GettextCaseSum()
        {
            string text;
            int i = 0;
            foreach (Label item in ListLabelstextCaseSum)
            {
                item.Text = ColorLB.CaseSumset(i);
                ColorLB.colorLBset(comitcase[0,i], Form1.casenum, item);
                i++;
            }
        }

    }
}
