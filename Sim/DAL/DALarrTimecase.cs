namespace Simulations
{
    public class DALarrTimecase
    {
        public static int casetime = 0;
        public static int[,] arrTimecase = new int[,]
      {
             {0,0,0},///TFoff1,TFoff2,TFoff3
             {0,0,0},///TFonF1,TFonF2,TFonF3
             {0,0,0},///TFonJ1,TFonJ2,TFonJ3
             {0,0,0},///TJoff1,TJoff2,TJoff3
             {0,0,0},///TJonF1,TJonF2,TJonF3
             {0,0,0}///TJonJ1,TJonJ2,TJonJ3
      };
        public static void ResetarrTimecaseALL()
        {
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    arrTimecase[i, j] = 0;
                }
            }
        }

    }
}
