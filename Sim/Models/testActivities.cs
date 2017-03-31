
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Simulations.Models
{
    public class testActivities
    {
        [Key]
        public Guid Uid { get; set; }
      
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public Getstatus? status { get; set; }
        [ForeignKey("testProfile")]
        public int profileUid { get; set; }
        [ForeignKey("Case")]
        public Guid CaseUid { get; set; }
        public int num { get; set; }
        public virtual testProfile testProfile { get; set; }
        public virtual testCase Case { get; set; }

        public enum Getstatus { Wait=0, Running=1, Commit=2 }
    }

}
