namespace Simulations.ReportControl
{
    partial class XtraReportChart7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportChart7));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrChart = new DevExpress.XtraReports.UI.XRChart();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.field1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field2 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field3 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNumbercase1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.field4 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 51.04167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "localhost_test_Connection 2";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "testActivities";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrChart
            // 
            this.xrChart.BorderColor = System.Drawing.Color.Black;
            this.xrChart.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrChart.Name = "xrChart";
            this.xrChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.xrChart.SizeF = new System.Drawing.SizeF(300F, 200F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 50F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart});
            this.GroupHeader1.HeightF = 200F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Angsana New", 8F);
            this.xrPivotGrid1.DataMember = "testActivities";
            this.xrPivotGrid1.DataSource = this.sqlDataSource1;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.field1,
            this.field2,
            this.field3,
            this.fieldNumbercase1,
            this.field4});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.True;
            this.xrPivotGrid1.OptionsPrint.PrintUnusedFilterFields = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(730F, 50F);
            // 
            // field1
            // 
            this.field1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.field1.AreaIndex = 0;
            this.field1.FieldName = "รูปแบบ";
            this.field1.Name = "field1";
            // 
            // field2
            // 
            this.field2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.field2.AreaIndex = 1;
            this.field2.FieldName = "จำนวนงาน";
            this.field2.Name = "field2";
            this.field2.Width = 71;
            // 
            // field3
            // 
            this.field3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.field3.AreaIndex = 0;
            this.field3.FieldName = "เวลา";
            this.field3.Name = "field3";
            this.field3.Width = 48;
            // 
            // fieldNumbercase1
            // 
            this.fieldNumbercase1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldNumbercase1.AreaIndex = 0;
            this.fieldNumbercase1.FieldName = "Numbercase";
            this.fieldNumbercase1.Name = "fieldNumbercase1";
            // 
            // field4
            // 
            this.field4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.field4.AreaIndex = 1;
            this.field4.FieldName = "ช่าง";
            this.field4.Name = "field4";
            this.field4.Width = 69;
            // 
            // XtraReportChart7
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.XRChart xrChart;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field2;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field3;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNumbercase1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field4;
    }
}
