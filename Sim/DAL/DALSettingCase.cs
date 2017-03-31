
using System.Collections;
using System.Linq;

namespace Simulations.DAL
{
    public class DALSettingCase
    {
        public static IEnumerable GetSettingCase()
        {
            myDbContext Context = new myDbContext();
            var model = Context.SettingCase.ToArray();
            return model;
        }
    }
}
