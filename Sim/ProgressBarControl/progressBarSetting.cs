using DevExpress.XtraEditors;

namespace Simulations.progressBarControl
{
    public static class progressBarSetting
    {
        public static void progress(ProgressBarControl P,int max )
        {
            ProgressBarControl Pcon = P;
            Pcon.Properties.PercentView = true;
            Pcon.Properties.Maximum = max+1;
            Pcon.Properties.Minimum = 0;
            Pcon.Properties.Step = 1;
            Pcon.PerformStep();    
            Pcon.Update();
        }

    }
}
