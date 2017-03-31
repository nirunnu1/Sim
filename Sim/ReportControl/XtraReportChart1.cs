using System;

namespace Simulations.ReportControl
{
    public partial class XtraReportChart1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChart1()
        {
            InitializeComponent();
            BarViewsReport.BarViewsSetting(xrChart1, 1);
        }
    }
}
