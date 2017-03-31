using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Simulations.Models
{
    public class testProfile
    {
        [Key]
        public int Uid { get; set; }
        public string Name { get; set; }
        public int? Case1 { get; set; }
        public int? Case2 { get; set; }
        public int? Case3 { get; set; }

        public ICollection<testActivities> Activities { get; set; }

      
    }
  
}
