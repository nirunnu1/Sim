namespace Simulations.ReportControl
{
    public partial class XtraReportChart8 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart8()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 8);
        }
    }
}
