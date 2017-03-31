namespace Simulations.ReportControl
{
    public partial class XtraReportChart10 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart10()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 10
                );
        }
    }
}
