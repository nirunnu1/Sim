using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Drawing;

namespace Simulations
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            // UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            // UserLookAndFeel.Default.SetSkinStyle("Office 2013 Dark Gray");
            UserLookAndFeel.Default.SetSkinStyle("Office 2013");

            DevExpress.XtraRichEdit.RichEditControlCompatibility.DefaultFontSize = 16;
            DevExpress.XtraRichEdit.RichEditControlCompatibility.DefaultFontName = "Angsana New";
            Application.Run(new Form1());
            
        }

       
    }
}