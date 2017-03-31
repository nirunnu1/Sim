using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using Simulations.Chartcontrol;
using System.Drawing;

namespace Simulations.ReportControl
{
    public  class BarViewsReport
    {
        public static void BarViewsSetting(XRChart chart, int casenumber)
        {
            XRChart settings = chart;
            settings.Name = "chart";
            settings.Width = 650 ;
            settings.Height = 300;
            settings.Titles.Clear();
            settings.Titles.Add(new ChartTitle()
            {
                Text = "BarChart แสดงเวลาการทำงาน การทดสอบครั้งที่ "+ casenumber
            });
            settings.Titles.Add(new ChartTitle()
            {
                Alignment = StringAlignment.Far,
                Dock = ChartTitleDockStyle.Bottom,
                Font = new Font("Tahoma", 8),
                TextColor = Color.Gray,
                Text = "เวลารวม"
            });

            settings.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;
            ((SideBySideBarSeriesLabel)settings.SeriesTemplate.Label).Position = BarSeriesLabelPosition.TopInside;
            ((SideBySideBarSeriesLabel)settings.SeriesTemplate.Label).TextOrientation = TextOrientation.TopToBottom;
            settings.DataSource = GreatLakesStateProductProvider.Getcaltest(casenumber);
            settings.SeriesDataMember = "Year";
            settings.SeriesTemplate.ArgumentDataMember = "State";
            settings.SeriesTemplate.ValueDataMembers[0] = "Product";
            settings.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            settings.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
        }

        public static void SettingXRChart(DocumentViewer ReportChart, XtraReport xtReport)
        {
            ReportChart.DocumentSource = xtReport;
            xtReport.CreateDocument();
          
        }
    }
}
