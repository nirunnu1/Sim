﻿using System;
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
using DevExpress.XtraReports.UI;

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
            BarViewsReport.SettingXRChart(ReportChart1, new XtraReportChart1());
            documentViewerRibbonController1.DocumentViewer = ReportChart1;

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
            ChartPie.Chart(Chart_FonF1, Chart_FonF1_time, Chart_FonF1_1, Chart_FonF1_2, Chart_FonF1_3, 1, 2);
            ChartPie.Chart(Chart_FonS1, Chart_FonS1_time, Chart_FonS1_1, Chart_FonS1_2, Chart_FonS1_3, 1, 3);
            ChartPie.Chart(Chart_SoFF1, Chart_SoFF1_time, Chart_SoFF1_1, Chart_SoFF1_2, Chart_SoFF1_3, 1, 4);
            ChartPie.Chart(Chart_SonF1, Chart_SonF1_time, Chart_SonF1_1, Chart_SonF1_2, Chart_SonF1_3, 1, 5);
            ChartPie.Chart(Chart_SonS1, Chart_SonS1_time, Chart_SonS1_1, Chart_SonS1_2, Chart_SonS1_3, 1, 6);

            TabControl_All.Visible = true;
        }
        private void ChaetBarView_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupBoxControl.HideGroup();
            BarViews_test.BarViewsSetting(Barview1,1);
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