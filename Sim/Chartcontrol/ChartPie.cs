using System.Drawing;
using Simulations.Models;
using DevExpress.XtraCharts;
using DevExpress.XtraBars.Ribbon;

namespace Simulations.Chartcontrol
{
    public partial class ChartPie : RibbonForm
    {
        public static void Chart(ChartControl chart , ChartControl chart_times, ChartControl Chart1, ChartControl Chart2, ChartControl Chart3, int id,int number)
        {
            //1
            ChartControl Piechart = chart;
            Piechart.Series.Clear();
            Piechart.BackColor = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            Piechart.BorderOptions.Color = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            Piechart.Series.Add(new Series("Piechart", ViewType.Pie3D));
            Piechart.DataSource = DALChart.chart_all(number, id);
            Piechart.Titles.Clear();
            Piechart.Titles.Add(new ChartTitle(){ Text = "จำนวนงาน " + DALChart.GetCount(number, id)});
            Piechart.Series["Piechart"].ArgumentDataMember = "Name";
            Piechart.Series["Piechart"].Label.TextPattern = "{A}: {VP:p0}"; ;
            Piechart.Series["Piechart"].ValueDataMembers.AddRange(new string[] { "num" });

            ChartControl Piechart_time = chart_times;
            Piechart_time.Series.Clear();
            Piechart_time.BackColor = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            Piechart_time.BorderOptions.Color = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            Piechart_time.Series.Add(new Series("Piechart_time", ViewType.Pie3D));
            Piechart_time.DataSource = DALChart.chart_alltime(number, id);
            Piechart_time.Titles.Clear();
            Piechart_time.Titles.Add(new ChartTitle(){Text = "เวลารวม " + DALChart.chart_timesum(number, id) + " วินาที"});
            Piechart_time.Series["Piechart_time"].ArgumentDataMember = "Name";
            Piechart_time.Series["Piechart_time"].Label.TextPattern = "{A}: {VP:p0}"; ;
            Piechart_time.Series["Piechart_time"].ValueDataMembers.AddRange(new string[] { "num" });

            ChartControl chart1 = Chart1;
            chart1.Series.Clear();
            chart1.BackColor = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            chart1.BorderOptions.Color = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            chart1.Series.Add(new Series("chart1", ViewType.Pie3D));
            chart1.DataSource = DALChart.chart_get(1, number, id);
            chart1.Titles.Clear();
            chart1.Titles.Add(new ChartTitle()
            {
                Text = "AAA"
            });
            chart1.Series["chart1"].ArgumentDataMember = "Name";
            chart1.Series["chart1"].Label.TextPattern = "{A}: {VP:p0}"; ;
            chart1.Series["chart1"].ValueDataMembers.AddRange(new string[] { "num" });

            ChartControl chart2 = Chart2;
            chart2.Series.Clear();
            chart2.BackColor = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            chart2.BorderOptions.Color = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            chart2.Series.Add(new Series("chart2", ViewType.Pie3D));
            chart2.DataSource = DALChart.chart_get(2, number, id);
            chart2.Titles.Clear();
            chart2.Titles.Add(new ChartTitle()
            {
                Text = "BBB"
            });
            chart2.Series["chart2"].ArgumentDataMember = "Name";
            chart2.Series["chart2"].Label.TextPattern = "{A}: {VP:p0}"; ;
            chart2.Series["chart2"].ValueDataMembers.AddRange(new string[] { "num" });


            ChartControl chart3 = Chart3;
            chart3.Series.Clear();
            chart3.BackColor = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            chart3.BorderOptions.Color = Color.FromArgb(0x00, 0xFF, 0xFF, 0xFF);
            chart3.Series.Add(new Series("chart3", ViewType.Pie3D));
            chart3.DataSource = DALChart.chart_get(3, number, id);
            chart3.Titles.Clear();
            chart3.Titles.Add(new ChartTitle()
            {
                Text = "CCC"
            });
            chart3.Series["chart3"].ArgumentDataMember = "Name";
            chart3.Series["chart3"].Label.TextPattern = "{A}: {VP:p0}"; ;
            chart3.Series["chart3"].ValueDataMembers.AddRange(new string[] { "num" });
           
        }
    }
}
