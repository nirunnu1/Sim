using System;

namespace Simulations.DAL
{
    public static class DALarrGuidcase
    {
        public static Guid GetGuid = new Guid("00000000-0000-0000-0000-000000000000");
        public static  Guid[,] arrayGuid = new Guid[,] {

             {GetGuid,GetGuid,GetGuid},///TFoff1,TFoff2,TFoff3
             {GetGuid,GetGuid,GetGuid},///TFonF1,TFonF2,TFonF3
             {GetGuid,GetGuid,GetGuid},///TFonJ1,TFonJ2,TFonJ3
             {GetGuid,GetGuid,GetGuid},///TJoff1,TJoff2,TJoff3
             {GetGuid,GetGuid,GetGuid},///TJonF1,TJonF2,TJonF3
             {GetGuid,GetGuid,GetGuid }///TJonJ1,TJonJ2,TJonJ3
        };
        public static void ResetGuidAll() {
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    arrayGuid[i, j] = GetGuid;
                }
            }
        }
    }
}
