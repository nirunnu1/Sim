using System;
using System.ComponentModel.DataAnnotations;

namespace Simulations.Models
{
    public class SettingCase
    {
        [Key]
        public  Guid Uid { get; set; }
        public  string Name { get; set; }
        public  int Case1 { get; set; }
        public  int Case2 { get; set; }
        public  int Case3 { get; set; }
    }
}
