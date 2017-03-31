using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL
{
    
    public class DALStatus
    {
        public enum Getstatus { Wait  = 0,Running =1,Commit=2}
        public string  GetStatus(Getstatus item)
        {
            string model = "";

            return model;
        }
    }
}
