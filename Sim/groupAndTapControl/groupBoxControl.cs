using DevExpress.XtraBars.Navigation;
using DevExpress.XtraTab;
using System.Drawing;
using System.Windows.Forms;

namespace Sim.groupAndTapControl
{
    public class groupBoxControl
    {
        public static GroupBox[] groupBox = new GroupBox[2];
        public static XtraTabControl[] xtraTabControl = new XtraTabControl[2];
        public static TabPane tabPane;
        public static void HideGroup()
        {
            groupBox[0].Visible = false;
            groupBox[1].Visible = false;

            xtraTabControl[0].Visible = false;
            xtraTabControl[1].Visible = false;
            tabPane.Visible = false;
            SizeGroup();
            LocationGroup();
        }

        public static void LocationGroup()
        {
            groupBox[0].Location = new Point(0, 0);
            groupBox[1].Location = new Point(0, 0);
            xtraTabControl[0].Location = new Point(0, 0);
            xtraTabControl[1].Location = new Point(0, 0);
            tabPane.Location = new Point(0, 0);
 
        }
        public static void SizeGroup()
        {
            groupBox[0].Dock = DockStyle.Fill;
            //groupBox_index.Size = new Size(900, 550);
            groupBox[1].Dock = DockStyle.Fill;
            //Set_index.Size = new Size(900, 550);
            xtraTabControl[0].Dock = DockStyle.Fill;
            // ReportChart.Size = new Size(900, 550);
            xtraTabControl[1].Dock = DockStyle.Fill;
            //TabControl_All.AutoSize = true;
            tabPane.Dock = DockStyle.Fill;
        }

    }
  
}
