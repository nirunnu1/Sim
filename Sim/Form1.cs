using System;
using System.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using Simulations.Models;
using System.Windows.Forms;
using Simulations.Chartcontrol;
using Simulations.SimStart;
using Sim;
using Simulations.SimStop;
using Simulations.progressBarControl;
using Simulations.DAL;
using Simulations.ReportControl;
using Simulations.DocumentRichEdit;
using System.Collections.Generic;
using SimStart.SimStart;
using Sim.Regridview;
using Sim.groupAndTapControl;

namespace Simulations
{
    public partial class Form1 : RibbonForm
    {
        public static int casenum = 0;
        public static int number = 1;
        public static int casetimeindex = 0;
        public static int OnOff = 0;

        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            regridview.label_casenum = label_casenum;
            regridview.label_casetime = label_casetime;

            DALTimer.Listitmer[0] = timer_case;

            DALTimer.Listitmer[1] = timer_Foff_1;DALTimer.Listitmer[2] = timer_Foff_2; DALTimer.Listitmer[3] = timer_Foff_3;
            DALTimer.Listitmer[4] = timer_FonF_1; DALTimer.Listitmer[5] = timer_FonF_2; DALTimer.Listitmer[6] = timer_FonF_3;
            DALTimer.Listitmer[7] = timer_FonJ_1; DALTimer.Listitmer[8] = timer_FonJ_2; DALTimer.Listitmer[9] = timer_FonJ_3;
            DALTimer.Listitmer[10] = timer_Joff_1; DALTimer.Listitmer[11] = timer_Joff_2; DALTimer.Listitmer[12] = timer_Joff_3;
            DALTimer.Listitmer[13] = timer_JonF_1; DALTimer.Listitmer[14] = timer_JonF_2; DALTimer.Listitmer[15] = timer_JonF_3;
            DALTimer.Listitmer[16] = timer_JonJ_1; DALTimer.Listitmer[17] = timer_JonJ_2; DALTimer.Listitmer[18] = timer_JonJ_3;

            DALTimer.label_casetime = label_casetime;

            ColorLB.SetListLabelstextTime(lb_off);
            ColorLB.SetListLabelstextTime(lb_FonF);
            ColorLB.SetListLabelstextTime(lb_FonJ);
            ColorLB.SetListLabelstextTime(lb_Joff);
            ColorLB.SetListLabelstextTime(lb_SonF);
            ColorLB.SetListLabelstextTime(lb_SonS);

            ColorLB.SetListLabelstextCaseSum(lb_off1);
            ColorLB.SetListLabelstextCaseSum(lb_FonF1);
            ColorLB.SetListLabelstextCaseSum(lb_FonJ1);
            ColorLB.SetListLabelstextCaseSum(lb_Joff1);
            ColorLB.SetListLabelstextCaseSum(lb_SonF1);
            ColorLB.SetListLabelstextCaseSum(lb_SonS1);

            ColorLB.colorLBset(DAlActivities.GetActivitiesEnd(number), casenum, label_casenum);

            ColorLB.spinEdit[0] = spinEdit_numcase;
            ColorLB.spinEdit[1] = spinEdit_casetime;

            regridview.lB_number = lB_number;
            regridview.progressBar_case = progressBar_case;

            regridview.Bt_stop= Bt_stop;
            regridview. button3= button3;
            regridview. button4= button4;
            regridview. Bt_set= Bt_set;

            groupBoxControl.groupBox[0] = groupBox_index;
            groupBoxControl.groupBox[1] = Set_index;
            groupBoxControl.tabPane = ReportChart;
            groupBoxControl.xtraTabControl[0] = TabControl_All;
            groupBoxControl.xtraTabControl[1] = Barview10;
            groupBoxControl.panel = panelRichEdit;
            richEditControl.richEditControl1 = richEditControl1;
            groupBoxControl.HideGroup();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        private void Setup(int Casenum, int Casetime, int onOff,int Number)
        {
            casenum = Casenum;
            DALarrTimecase.casetime = Casetime;
            OnOff = onOff;
            number = Number;
        }      
        private void Nav_home_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBoxControl.HideGroup();
            regridview.Regridview();
            groupBox_index.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            regridview.ResetTimer();
            regridview.Regridview();
            regridview. ResetTimer();
            spin_M11.Text = DALProfile.GetSkillprofile(1, 1).ToString();
            spin_M12.Text = DALProfile.GetSkillprofile(1, 2).ToString();
            spin_M13.Text = DALProfile.GetSkillprofile(1, 3).ToString();

            spin_M21.Text = DALProfile.GetSkillprofile(2, 1).ToString();
            spin_M22.Text = DALProfile.GetSkillprofile(2, 2).ToString();
            spin_M23.Text = DALProfile.GetSkillprofile(2, 3).ToString();

            spin_M31.Text = DALProfile.GetSkillprofile(3, 1).ToString();
            spin_M32.Text = DALProfile.GetSkillprofile(3, 2).ToString();
            spin_M33.Text = DALProfile.GetSkillprofile(3, 3).ToString();
        }
        private void Cb_main_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Cb_main.SelectedIndex != -1)
            {
                groupSet_main1.Visible = false;
                groupSet_main3.Visible = false;
                groupSet_main2.Visible = false;
                if (Cb_main.SelectedIndex >= 0)
                {
                    groupSet_main1.Visible = true;
                }
                if (Cb_main.SelectedIndex >= 1)
                {
                    groupSet_main2.Visible = true;
                }
                if (Cb_main.SelectedIndex >= 2)
                {
                    groupSet_main3.Visible = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (spinEdit_casetime.Text != null)
            {
                casetimeindex = Convert.ToInt32(spinEdit_casetime.Text);
                Setup(Convert.ToInt32(spinEdit_numcase.Text), Convert.ToInt32(spinEdit_casetime.Text), 1,1);
                DALProfile.UpdateSkill(1,Convert.ToInt32( spin_M11.Text), Convert.ToInt32(spin_M12.Text),Convert.ToInt32( spin_M13.Text));
                DALProfile.UpdateSkill(2, Convert.ToInt32(spin_M21.Text), Convert.ToInt32(spin_M22.Text), Convert.ToInt32(spin_M23.Text));
                DALProfile.UpdateSkill(3, Convert.ToInt32(spin_M31.Text), Convert.ToInt32(spin_M32.Text), Convert.ToInt32(spin_M33.Text));
            }
           
        }
       public static int a;
        private void button3_Click(object sender, EventArgs e)
        {
            regridview.casegen = regridview. RandomizeStrings(Form1.casenum);
            progressBarSetting.progress(progressBar_case, 10);
            regridview.checkStart();
        }     
        private void button4_Click(object sender, EventArgs e)
        {
            DALsim.tabledelete();
            regridview.Regridview();
            regridview. ResetTimer();
            MessageBox.Show("ลบข้อมูลเรียบร้อย");
        }
        private void Dv1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBoxControl.HideGroup();
            ReportChart.Visible = true;
        }
        private void spinEdit_casetime_EditValueChanged(object sender, EventArgs e)
        {
            ColorLB.ColorSpinedit();
        }
        private void Bt_stop_Click(object sender, EventArgs e)
        {
            Setup(0, 0, 0,1);
            progressBar_case.EditValue = 0;
            regridview.ResetTimer();
            regridview.Regridview();
        }
        private void Bt_set_Click(object sender, EventArgs e)
        {
            groupBoxControl.HideGroup();
            groupSet_main1.Visible = false;
            groupSet_main3.Visible = false;
            groupSet_main2.Visible = false;
            Set_index.Visible = true;
            regridview.Regridview();
        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            regridview.Regridview();
            ChartPie.Chart(Chart_Foff1, Chart_Foff1_time, Chart_Foff1_1, Chart_Foff1_2, Chart_Foff1_3, 1, 1);
            ChartPie.Chart(Chart_Foff2, Chart_Foff2_time, Chart_Foff2_1, Chart_Foff2_2, Chart_Foff2_3, 2, 1);
            ChartPie.Chart(Chart_Foff3, Chart_Foff3_time, Chart_Foff3_1, Chart_Foff3_2, Chart_Foff3_3, 3, 1);
            ChartPie.Chart(Chart_Foff4, Chart_Foff4_time, Chart_Foff4_1, Chart_Foff4_2, Chart_Foff4_3, 4, 1);
            ChartPie.Chart(Chart_Foff5, Chart_Foff5_time, Chart_Foff5_1, Chart_Foff5_2, Chart_Foff5_3, 5, 1);
            ChartPie.Chart(Chart_Foff6, Chart_Foff6_time, Chart_Foff6_1, Chart_Foff6_2, Chart_Foff6_3, 6, 1);
            ChartPie.Chart(Chart_Foff7, Chart_Foff7_time, Chart_Foff7_1, Chart_Foff7_2, Chart_Foff7_3, 7, 1);
            ChartPie.Chart(Chart_Foff8, Chart_Foff8_time, Chart_Foff8_1, Chart_Foff8_2, Chart_Foff8_3, 8, 1);
            ChartPie.Chart(Chart_Foff9, Chart_Foff9_time, Chart_Foff9_1, Chart_Foff9_2, Chart_Foff9_3, 9, 1);
            ChartPie.Chart(Chart_Foff10, Chart_Foff10_time, Chart_Foff10_1, Chart_Foff10_2, Chart_Foff10_3, 10, 1);

            ChartPie.Chart(Chart_FonF1, Chart_FonF1_time, Chart_FonF1_1, Chart_FonF1_2, Chart_FonF1_3, 1, 2);
            ChartPie.Chart(Chart_FonF2, Chart_FonF2_time, Chart_FonF2_1, Chart_FonF2_2, Chart_FonF2_3, 2, 2);
            ChartPie.Chart(Chart_FonF3, Chart_FonF3_time, Chart_FonF3_1, Chart_FonF3_2, Chart_FonF3_3, 3, 2);
            ChartPie.Chart(Chart_FonF4, Chart_FonF4_time, Chart_FonF4_1, Chart_FonF4_2, Chart_FonF4_3, 4, 2);
            ChartPie.Chart(Chart_FonF5, Chart_FonF5_time, Chart_FonF5_1, Chart_FonF5_2, Chart_FonF5_3, 5, 2);
            ChartPie.Chart(Chart_FonF6, Chart_FonF6_time, Chart_FonF6_1, Chart_FonF6_2, Chart_FonF6_3, 6, 2);
            ChartPie.Chart(Chart_FonF7, Chart_FonF7_time, Chart_FonF7_1, Chart_FonF7_2, Chart_FonF7_3, 7, 2);
            ChartPie.Chart(Chart_FonF8, Chart_FonF8_time, Chart_FonF8_1, Chart_FonF8_2, Chart_FonF8_3, 8, 2);
            ChartPie.Chart(Chart_FonF9, Chart_FonF9_time, Chart_FonF9_1, Chart_FonF9_2, Chart_FonF9_3, 9, 2);
            ChartPie.Chart(Chart_FonF10, Chart_FonF10_time, Chart_FonF10_1, Chart_FonF10_2, Chart_FonF10_3, 10, 2);

            ChartPie.Chart(Chart_FonS1, Chart_FonS1_time, Chart_FonS1_1, Chart_FonS1_2, Chart_FonS1_3, 1, 3);
            ChartPie.Chart(Chart_FonS2, Chart_FonS2_time, Chart_FonS2_1, Chart_FonS2_2, Chart_FonS2_3, 2, 3);
            ChartPie.Chart(Chart_FonS3, Chart_FonS3_time, Chart_FonS3_1, Chart_FonS3_2, Chart_FonS3_3, 3, 3);
            ChartPie.Chart(Chart_FonS4, Chart_FonS4_time, Chart_FonS4_1, Chart_FonS4_2, Chart_FonS4_3, 4, 3);
            ChartPie.Chart(Chart_FonS5, Chart_FonS5_time, Chart_FonS5_1, Chart_FonS5_2, Chart_FonS5_3, 5, 3);
            ChartPie.Chart(Chart_FonS6, Chart_FonS6_time, Chart_FonS6_1, Chart_FonS6_2, Chart_FonS6_3, 6, 3);
            ChartPie.Chart(Chart_FonS7_, Chart_FonS7_time, Chart_FonS7_1, Chart_FonS7_2, Chart_FonS7_3, 7, 3);
            ChartPie.Chart(Chart_FonS8, Chart_FonS8_time, Chart_FonS8_1, Chart_FonS8_2, Chart_FonS8_3, 8, 3);
            ChartPie.Chart(Chart_FonS9, Chart_FonS9_time, Chart_FonS9_1, Chart_FonS9_2, Chart_FonS9_3, 9, 3);
            ChartPie.Chart(Chart_FonS10, Chart_FonS10_time, Chart_FonS10_1, Chart_FonS10_2, Chart_FonS10_3, 10, 3);

            ChartPie.Chart(Chart_SoFF1, Chart_SoFF1_time, Chart_SoFF1_1, Chart_SoFF1_2, Chart_SoFF1_3, 1, 4);
            ChartPie.Chart(Chart_SoFF2, Chart_SoFF2_time, Chart_SoFF2_1, Chart_SoFF2_2, Chart_SoFF2_3, 2, 4);
            ChartPie.Chart(Chart_SoFF3, Chart_SoFF3_time, Chart_SoFF3_1, Chart_SoFF3_2, Chart_SoFF3_3, 3, 4);
            ChartPie.Chart(Chart_SoFF4, Chart_SoFF4_time, Chart_SoFF4_1, Chart_SoFF4_2, Chart_SoFF4_3, 4, 4);
            ChartPie.Chart(Chart_SoFF5, Chart_SoFF5_time, Chart_SoFF5_1, Chart_SoFF5_2, Chart_SoFF5_3, 5, 4);
            ChartPie.Chart(Chart_SoFF6, Chart_SoFF6_time, Chart_SoFF6_1, Chart_SoFF6_2, Chart_SoFF6_3, 6, 4);
            ChartPie.Chart(Chart_SoFF7, Chart_SoFF7_time, Chart_SoFF7_1, Chart_SoFF7_2, Chart_SoFF7_3, 7, 4);
            ChartPie.Chart(Chart_SoFF8, Chart_SoFF8_time, Chart_SoFF8_1, Chart_SoFF8_2, Chart_SoFF8_3, 8, 4);
            ChartPie.Chart(Chart_SoFF9, Chart_SoFF9_time, Chart_SoFF9_1, Chart_SoFF9_2, Chart_SoFF9_3, 9, 4);
            ChartPie.Chart(Chart_SoFF10, Chart_SoFF10_time, Chart_SoFF10_1, Chart_SoFF10_2, Chart_SoFF10_3, 10, 4);


            ChartPie.Chart(Chart_SonF1, Chart_SonF1_time, Chart_SonF1_1, Chart_SonF1_2, Chart_SonF1_3, 1, 5);
            ChartPie.Chart(Chart_SonF2, Chart_SonF2_time, Chart_SonF2_1, Chart_SonF2_2, Chart_SonF2_3, 2, 5);
            ChartPie.Chart(Chart_SonF3, Chart_SonF3_time, Chart_SonF3_1, Chart_SonF3_2, Chart_SonF3_3, 3, 5);
            ChartPie.Chart(Chart_SonF4, Chart_SonF4_time, Chart_SonF4_1, Chart_SonF4_2, Chart_SonF4_3, 4, 5);
            ChartPie.Chart(Chart_SonF5, Chart_SonF5_time, Chart_SonF5_1, Chart_SonF5_2, Chart_SonF5_3, 5, 5);
            ChartPie.Chart(Chart_SonF6, Chart_SonF6_time, Chart_SonF6_1, Chart_SonF6_2, Chart_SonF6_3, 6, 5);
            ChartPie.Chart(Chart_SonF7, Chart_SonF7_time, Chart_SonF7_1, Chart_SonF7_2, Chart_SonF7_3, 7, 5);
            ChartPie.Chart(Chart_SonF8, Chart_SonF8_time, Chart_SonF8_1, Chart_SonF8_2, Chart_SonF8_3, 8, 5);
            ChartPie.Chart(Chart_SonF9, Chart_SonF9_time, Chart_SonF9_1, Chart_SonF9_2, Chart_SonF9_3, 9, 5);
            ChartPie.Chart(Chart_SonF10, Chart_SonF10_time, Chart_SonF10_1, Chart_SonF10_2, Chart_SonF10_3, 10, 5);

            ChartPie.Chart(Chart_SonS1, Chart_SonS1_time, Chart_SonS1_1, Chart_SonS1_2, Chart_SonS1_3, 1, 6);
            ChartPie.Chart(Chart_SonS2, Chart_SonS2_time, Chart_SonS2_1, Chart_SonS2_2, Chart_SonS2_3, 2, 6);
            ChartPie.Chart(Chart_SonS3, Chart_SonS3_time, Chart_SonS3_1, Chart_SonS3_2, Chart_SonS3_3, 3, 6);
            ChartPie.Chart(Chart_SonS4, Chart_SonS4_time, Chart_SonS4_1, Chart_SonS4_2, Chart_SonS4_3, 4, 6);
            ChartPie.Chart(Chart_SonS5, Chart_SonS5_time, Chart_SonS5_1, Chart_SonS5_2, Chart_SonS5_3, 5, 6);
            ChartPie.Chart(Chart_SonS6, Chart_SonS6_time, Chart_SonS6_1, Chart_SonS6_2, Chart_SonS6_3, 6, 6);
            ChartPie.Chart(Chart_SonS7, Chart_SonS7_time, Chart_SonS7_1, Chart_SonS7_2, Chart_SonS7_3, 7, 6);
            ChartPie.Chart(Chart_SonS8, Chart_SonS8_time, Chart_SonS8_1, Chart_SonS8_2, Chart_SonS8_3, 8, 6);
            ChartPie.Chart(Chart_SonS9, Chart_SonS9_time, Chart_SonS9_1, Chart_SonS9_2, Chart_SonS9_3, 9, 6);
            ChartPie.Chart(Chart_SonS10, Chart_SonS10_time, Chart_SonS10_1, Chart_SonS10_2, Chart_SonS10_3, 10, 6);
            TabControl_All.Visible = true;
        }
        private void ChaetBarView_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBoxControl.HideGroup();
            BarViews_1.BarViewsSetting(Barview_1);
            BarViews_2.BarViewsSetting(Barview_2);
            BarViews_test.BarViewsSetting(Barview1,1);
            BarViews_test.BarViewsSetting(Barview2, 2);
            BarViews_test.BarViewsSetting(Barview3, 3);
            BarViews_test.BarViewsSetting(Barview4, 4);
            BarViews_test.BarViewsSetting(Barview5, 5);
            BarViews_test.BarViewsSetting(Barview6, 6);
            BarViews_test.BarViewsSetting(Barview7, 7);
            BarViews_test.BarViewsSetting(Barview8, 8);
            BarViews_test.BarViewsSetting(Barview9, 9);
            BarViews_test.BarViewsSetting(Barview_10, 10);
            Barview10.Visible = true;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            regridview.ResetTimer();
        }
        private void SetDef_Click(object sender, EventArgs e)
        {
            Setup(10, 10, 1,1);
            casetimeindex = 10;
            groupBoxControl.HideGroup();
            regridview.Regridview();
            groupBox_index.Visible = true;
        }
        private void ReportChart_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            int A = ReportChart.SelectedPageIndex;
            switch (A)
            {
                case 0 :
                    BarViewsReport.SettingXRChart(documentViewer1, new XtraReport1());
                    documentViewerRibbonController1.DocumentViewer = documentViewer1;
                    break;
                case 1:
                    BarViewsReport.SettingXRChart(ReportChart1, new XtraReportChart1());
                    documentViewerRibbonController1.DocumentViewer = ReportChart1;
                    break;
                case 2:
                    BarViewsReport.SettingXRChart(ReportChart2, new XtraReportChart2());
                    documentViewerRibbonController1.DocumentViewer = ReportChart2;
                    break;
                case 3:
                    BarViewsReport.SettingXRChart(ReportChart3, new XtraReportChart3());
                    documentViewerRibbonController1.DocumentViewer = ReportChart3;
                    break;
                case 4:
                    BarViewsReport.SettingXRChart(ReportChart4, new XtraReportChart4());
                    documentViewerRibbonController1.DocumentViewer = ReportChart4;
                    break;
                case 5:
                    BarViewsReport.SettingXRChart(ReportChart5, new XtraReportChart5());
                    documentViewerRibbonController1.DocumentViewer = ReportChart5;
                    break;
                case 6:
                    BarViewsReport.SettingXRChart(ReportChart6, new XtraReportChart6());
                    documentViewerRibbonController1.DocumentViewer = ReportChart6;
                    break;
                case 7:
                    BarViewsReport.SettingXRChart(ReportChart7, new XtraReportChart7());
                    documentViewerRibbonController1.DocumentViewer = ReportChart7;
                    break;
                case 8:
                    BarViewsReport.SettingXRChart(ReportChart8, new XtraReportChart8());
                    documentViewerRibbonController1.DocumentViewer = ReportChart8;
                    break;
                case 9:
                    BarViewsReport.SettingXRChart(ReportChart9, new XtraReportChart9());
                    documentViewerRibbonController1.DocumentViewer = ReportChart9;
                    break;
                case 10:
                    BarViewsReport.SettingXRChart(ReportChart10, new XtraReportChart10());
                    documentViewerRibbonController1.DocumentViewer = ReportChart10;
                    break;
            }
      
        }
        private void Nav_set_Click(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBoxControl.HideGroup();
            Cb_main.DataSource = Combobox.GetCombobox();
            Cb_main.ValueMember = "id";
            Cb_main.DisplayMember = "Name";

            CB_Setgencase.DataSource = DALSettingCase.GetSettingCase();
            CB_Setgencase.ValueMember = "Uid";
            CB_Setgencase.DisplayMember = "Name";
            groupSet_main1.Visible = false;
            groupSet_main3.Visible = false;
            groupSet_main2.Visible = false;
            Set_index.Visible = true;
        }
        private void bt_addSetcase_Click(object sender, EventArgs e)
        {
            var form = new SettingCaseAdd();
            form.Show(this);
        }
    }
}