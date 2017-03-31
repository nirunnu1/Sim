using Simulations;
using Simulations.DAL;
using Simulations.Models;
using Simulations.SimStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimStart.SimStart
{
    public class AIStart
    {
        public static void GetAIStart()
        {
            FOFF.Foff(DALarrTimecase.arrTimecase[0, 0], DALarrGuidcase.arrayGuid[0, 0], DALTimer.Listitmer[1], 1);
            FOFF.Foff(DALarrTimecase.arrTimecase[0, 1], DALarrGuidcase.arrayGuid[0, 1], DALTimer.Listitmer[2], 2);
            FOFF.Foff(DALarrTimecase.arrTimecase[0, 2], DALarrGuidcase.arrayGuid[0, 2], DALTimer.Listitmer[3], 3);

            FonF.Fonf(DALarrTimecase.arrTimecase[1, 0], DALarrGuidcase.arrayGuid[1, 0], DALTimer.Listitmer[4], 1);
            FonF.Fonf(DALarrTimecase.arrTimecase[1, 1], DALarrGuidcase.arrayGuid[1, 1], DALTimer.Listitmer[5], 2);
            FonF.Fonf(DALarrTimecase.arrTimecase[1, 2], DALarrGuidcase.arrayGuid[1, 2], DALTimer.Listitmer[6], 3);

            //FonJ.Fonj(DALarrTimecase.arrTimecase[2, 0], DALarrGuidcase.arrayGuid[2, 0], DALTimer.Listitmer[7], 1);
            //FonJ.Fonj(DALarrTimecase.arrTimecase[2, 1], DALarrGuidcase.arrayGuid[2, 1], DALTimer.Listitmer[8], 2);
            //FonJ.Fonj(DALarrTimecase.arrTimecase[2, 2], DALarrGuidcase.arrayGuid[2, 2], DALTimer.Listitmer[9], 3);

            JOFF.Joff(DALarrTimecase.arrTimecase[3, 0], DALarrGuidcase.arrayGuid[3, 0], DALTimer.Listitmer[10], 1);
            JOFF.Joff(DALarrTimecase.arrTimecase[3, 1], DALarrGuidcase.arrayGuid[3, 1], DALTimer.Listitmer[11], 2);
            JOFF.Joff(DALarrTimecase.arrTimecase[3, 2], DALarrGuidcase.arrayGuid[3, 2], DALTimer.Listitmer[12], 3);

            //JonF.Jonf(DALarrTimecase.arrTimecase[4, 0], DALarrGuidcase.arrayGuid[4, 0], DALTimer.Listitmer[13], 1);
            //JonF.Jonf(DALarrTimecase.arrTimecase[4, 1], DALarrGuidcase.arrayGuid[4, 1], DALTimer.Listitmer[14], 2);
            //JonF.Jonf(DALarrTimecase.arrTimecase[4, 2], DALarrGuidcase.arrayGuid[4, 2], DALTimer.Listitmer[15], 3);

            JonJ.Jonj(DALarrTimecase.arrTimecase[5, 0], DALarrGuidcase.arrayGuid[5, 0], DALTimer.Listitmer[16], 1);
            JonJ.Jonj(DALarrTimecase.arrTimecase[5, 1], DALarrGuidcase.arrayGuid[5, 1], DALTimer.Listitmer[17], 2);
            JonJ.Jonj(DALarrTimecase.arrTimecase[5, 2], DALarrGuidcase.arrayGuid[5, 2], DALTimer.Listitmer[18], 3);
        }
    }
}
