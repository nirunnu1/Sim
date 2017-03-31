
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Simulations.Models
{
    public class testCase
    {
        [Key]
        public Guid Uid { get; set; }
        public int Numbercase { get; set; }
        public DateTime Time { get; set; }
        public int number { get; set; }
        public ICollection<testActivities> Activities { get; set; }
        public static IEnumerable GetCase()
        {
            myDbContext Context = new myDbContext();
            var model = from A in Context.testCase
                        select new { A.Uid, A.Time, A.Numbercase };
                        
            return model.OrderBy(a=>a.Time).ToList();
      
        }
        public static int Getcout()
        {
            myDbContext Context = new myDbContext();

            return Context.testCase.Count();
        }
    }
}
