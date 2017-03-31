namespace Simulations.ReportControl
{
    public partial class XtraReportChart9 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart9()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 9);
        }
    }
}
