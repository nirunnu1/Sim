using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.IO;
using System.Windows.Forms;

namespace Simulations.DocumentRichEdit
{
   public static class DocumentRichEditSetting
    {
        public static int classtab = 0;
        public static void SaveRichEdit(RichEditControl richEditControl)
        {
            Stream stream = File.Open(@"..\..\DocumentFile\Document" + classtab + ".doc", FileMode.Open);
            DialogResult dialogResult = MessageBox.Show("ต้องการบันทึก บทที่ " + classtab + ".doc หรือไม่", "Document" + classtab + ".doc", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                richEditControl.SaveDocument(stream, DocumentFormat.Doc);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            stream.Close();
        }
        public static  void LoadDocumentRichEdit(RichEditControl richEditControl)
        {
            richEditControl.InvalidFormatException += new DevExpress.XtraRichEdit.RichEditInvalidFormatExceptionEventHandler(richEditControl1_InvalidFormatException);
            Stream stream = File.Open(@"..\..\DocumentFile\Document" + classtab + ".doc", FileMode.Open);
            stream.Seek(0, SeekOrigin.Begin);
            CharacterProperties charProperties = richEditControl.Document.BeginUpdateCharacters(richEditControl.Document.Range);
            charProperties.FontName = "Angsana New";
            richEditControl.Document.EndUpdateCharacters(charProperties);

            richEditControl.LoadDocument(stream, DocumentFormat.Doc);
            stream.Close();

        }
        public static void richEditControl1_InvalidFormatException(object sender, RichEditInvalidFormatExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
