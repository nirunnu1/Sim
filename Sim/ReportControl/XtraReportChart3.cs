namespace Simulations.ReportControl
{
    public partial class XtraReportChart3 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart3()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart3, 3);
        }
    }
}
