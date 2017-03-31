using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulations.Models
{
    class Combobox
    {

        public int id { get; set; }
        public string Name { get; set; }
        public static IEnumerable<Combobox> GetCombobox()
            {
            List<Combobox> Combobox = new List<Combobox>();

            Combobox.Add(new Combobox { Name = "1", id = 1 });
            Combobox.Add(new Combobox { Name = "2", id = 2 });
            Combobox.Add(new Combobox { Name = "3", id = 3 });
            return Combobox;
            }
    }
}
