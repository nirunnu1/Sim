namespace Simulations.ReportControl
{
    public partial class XtraReportChart4 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart4()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 4);
        }
    }
}
