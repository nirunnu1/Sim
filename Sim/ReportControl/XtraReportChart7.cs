namespace Simulations.ReportControl
{
    public partial class XtraReportChart7 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart7()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 7);
        }
    }
}
