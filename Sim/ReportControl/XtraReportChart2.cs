namespace Simulations.ReportControl
{
    public partial class XtraReportChart2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart2()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart2, 2);
        }

    }
}
