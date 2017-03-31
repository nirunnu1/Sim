using DevExpress.XtraRichEdit;
using Sim.groupAndTapControl;
using Simulations.DocumentRichEdit;

namespace Simulations
{
    public class richEditControl
    {
        public static RichEditControl richEditControl1;
        public static void Tab_RichEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DocumentRichEditSetting.classtab != 0) { DocumentRichEditSetting.SaveRichEdit(richEditControl1); };
            DocumentRichEditSetting.classtab = 0;
            groupBoxControl.HideGroup();
            groupBoxControl.panel.Visible = true;
        }

        public static void Tab_RichEdit1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DocumentRichEditSetting.classtab != 0) { DocumentRichEditSetting.SaveRichEdit(richEditControl1); };
            DocumentRichEditSetting.classtab = 1;
            DocumentRichEditSetting.LoadDocumentRichEdit(richEditControl1);
            groupBoxControl.HideGroup();
            groupBoxControl.panel.Visible = true;

        }
        public static void Tab_RichEdit2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DocumentRichEditSetting.classtab != 0) { DocumentRichEditSetting.SaveRichEdit(richEditControl1); };
            DocumentRichEditSetting.classtab = 2;
            DocumentRichEditSetting.LoadDocumentRichEdit(richEditControl1);
            groupBoxControl.HideGroup();
            groupBoxControl.panel.Visible = true;
        }
        public static void Tab_RichEdit3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DocumentRichEditSetting.classtab != 0) { DocumentRichEditSetting.SaveRichEdit(richEditControl1); }; DocumentRichEditSetting.classtab = 3;
            DocumentRichEditSetting.LoadDocumentRichEdit(richEditControl1);
            groupBoxControl.HideGroup();
            groupBoxControl.panel.Visible = true;
        }
        public static void Tab_RichEdit4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DocumentRichEditSetting.classtab != 0) { DocumentRichEditSetting.SaveRichEdit(richEditControl1); }; DocumentRichEditSetting.classtab = 4;
            DocumentRichEditSetting.LoadDocumentRichEdit(richEditControl1);
            groupBoxControl.HideGroup();
            groupBoxControl.panel.Visible = true;
        }
        public static void Tab_RichEdit5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (DocumentRichEditSetting.classtab != 0) { DocumentRichEditSetting.SaveRichEdit(richEditControl1); }; DocumentRichEditSetting.classtab = 5;
            DocumentRichEditSetting.LoadDocumentRichEdit(richEditControl1);
            groupBoxControl.HideGroup();
            groupBoxControl.panel.Visible = true;
        }

    }
}
