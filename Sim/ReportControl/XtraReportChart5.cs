namespace Simulations.ReportControl
{
    public partial class XtraReportChart5 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart5()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart, 5);
        }
    }
}
