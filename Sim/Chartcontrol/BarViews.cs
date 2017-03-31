
using DevExpress.Utils;
using DevExpress.XtraCharts;
using Simulations.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Simulations.Chartcontrol
{
    public static class GreatLakesStateProductProvider
    {
        public static IList<GreatLakesStateProduct> GetGreatLakesStateProduct()
        {
            string[] states = new string[] { "FIFO", "FIFO on FIFO", "FIFO on SJF", "SJF", "SJF on FIFO", "SJF on SJF" };
            string[] years = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            Dictionary<string, IList<double>> values = new Dictionary<string, IList<double>>();
            for (int i = 0; i <= 9; i++)
            {
                values.Add(years[i], new double[] { DALChart.chart_timesum(1, i + 1), DALChart.chart_timesum(2, i + 1), DALChart.chart_timesum(3, i + 1), DALChart.chart_timesum(4, i + 1), DALChart.chart_timesum(5, i + 1), DALChart.chart_timesum(6, i + 1) });
            }

            List<GreatLakesStateProduct> result = new List<GreatLakesStateProduct>();
            foreach (string year in years)
                for (int i = 0; i < states.Length; i++)
                    result.Add(new GreatLakesStateProduct(states[i], year, values[year][i]));
            return result;
        }
        public static IList<GreatLakesStateProduct> GetAVG()
        {
            string[] states = new string[] { "FIFO", "FIFO on FIFO", "FIFO on SJF", "SJF", "SJF on FIFO", "SJF on SJF" };
            string[] years = new string[] { "1" };
            Dictionary<string, IList<double>> values = new Dictionary<string, IList<double>>();
            for (int i = 0; i < 1; i++)
            {
                values.Add(years[i], new double[] { calavg(1), calavg(2), calavg(3), calavg(4), calavg(5), calavg(6) });

            }
            List<GreatLakesStateProduct> result = new List<GreatLakesStateProduct>();
            foreach (string year in years)
                for (int i = 0; i < states.Length; i++)
                    result.Add(new GreatLakesStateProduct(states[i], year, values[year][i]));
            return result;
        }
        //public static IList<GreatLakesStateProduct> Getcaltest(int casenumber)
        //{
        //    string[] states = new string[] { "FIFO", "FIFO on FIFO", "FIFO on SJF", "SJF", "SJF on FIFO", "SJF on SJF" };
        //    string[] years = new string[] { "AAA","BBB","CCC" };
        //    Dictionary<string, IList<double>> values = new Dictionary<string, IList<double>>();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        values.Add(years[i], new double[] { calavgtime(i+1, 1, casenumber),
        //                                            calavgtime(i+1, 2, casenumber),
        //                                            calavgtime(i+1, 3, casenumber),
        //                                            calavgtime(i+1, 4, casenumber),
        //                                            calavgtime(i+1, 5, casenumber),
        //                                            calavgtime(i+1, 6, casenumber)});

        //    }
        //    List<GreatLakesStateProduct> result = new List<GreatLakesStateProduct>();
        //    foreach (string year in years)
        //        for (int i = 0; i < states.Length; i++)
        //            result.Add(new GreatLakesStateProduct(states[i], year, values[year][i]));
        //    return result;
        //}
        public static IList<GreatLakesStateProduct> Getcaltest(int casenumber)
        {
            string[] states = new string[] { "FIFO", "FIFO on FIFO", "FIFO on SJF", "SJF", "SJF on FIFO", "SJF on SJF" };
            string[] years = new string[] { "Waitingtime" };
            Dictionary<string, IList<double>> values = new Dictionary<string, IList<double>>();
            for (int i = 0; i < 1; i++)
            {
                values.Add(years[i], new double[] { calavgtime(i+1, 1, casenumber),
                                                    calavgtime(i+1, 2, casenumber),
                                                    calavgtime(i+1, 3, casenumber),
                                                    calavgtime(i+1, 4, casenumber),
                                                    calavgtime(i+1, 5, casenumber),
                                                    calavgtime(i+1, 6, casenumber)});

            }
            List<GreatLakesStateProduct> result = new List<GreatLakesStateProduct>();
            foreach (string year in years)
                for (int i = 0; i < states.Length; i++)
                    result.Add(new GreatLakesStateProduct(states[i], year, values[year][i]));
            return result;
        }
        public static int calavg(int id)
        {
            int Avg = 0;
            for (int i = 0; i <= 9; i++)
            {
                Avg = Avg + DALChart.chart_timesum(id, i + 1);
            }
            Avg = Avg / 10;
            return Avg;
        }
        public static double calavgtime(int profile, int number, int casenumber)
        {

            return DALChart.chart_Waitingtime(number, casenumber);
        }
        //public static int calavgtime(int profile,int number, int casenumber)
        //{

        //    return DALChart.chart_timeprofile(number, casenumber, profile);
        //}
    }

    public class GreatLakesStateProduct
    {
        string state;
        string year;
        double product;

        public string State { get { return state; } }
        public string Year { get { return year; } }
        public double Product { get { return product; } }

        public GreatLakesStateProduct(string state, string year, double product)
        {
            this.state = state;
            this.year = year;
            this.product = product;
        }
    }
    public static class BarViews_1
    {
        public static void BarViewsSetting(ChartControl chart)
        {
            ChartControl settings = chart;
            settings.Name = "chart";
            settings.Width = 900;
            settings.Height = 500;
            settings.Titles.Clear();
            settings.Titles.Add(new ChartTitle()
            {
                Text = "เวลารวม"
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
            settings.DataSource = GreatLakesStateProductProvider.GetGreatLakesStateProduct();
            settings.SeriesDataMember = "Year";
            settings.SeriesTemplate.ArgumentDataMember = "State";
            settings.SeriesTemplate.ValueDataMembers[0] = "Product";
            settings.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            settings.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
        }
    }
    public static class BarViews_2
    {
        public static void BarViewsSetting(ChartControl chart)
        {
            ChartControl settings = chart;
            settings.Name = "chart";
            settings.Width = 900;
            settings.Height = 500;
            settings.Titles.Clear();
            settings.Titles.Add(new ChartTitle()
            {
                Text = "เวลารวม"
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
            settings.DataSource = GreatLakesStateProductProvider.GetAVG();
            settings.SeriesDataMember = "Year";
            settings.SeriesTemplate.ArgumentDataMember = "State";
            settings.SeriesTemplate.ValueDataMembers[0] = "Product";
            settings.SeriesTemplate.Label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            settings.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
        }
    }
    public static class BarViews_test
    {
        public static void BarViewsSetting(ChartControl chart, int casenumber)
        {
            ChartControl settings = chart;
            settings.Name = "chart";
            settings.Width = 900;
            settings.Height = 500;
            settings.Titles.Clear();
            settings.Titles.Add(new ChartTitle()
            {
                Text = "เวลารวม"
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
            settings.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
        }
    }

}
