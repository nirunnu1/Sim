namespace Simulations.ReportControl
{
    public partial class XtraReportChart6 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart6()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 6);
        }
    }
}
