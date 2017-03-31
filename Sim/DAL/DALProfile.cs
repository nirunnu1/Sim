using Simulations.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simulations.DAL
{
    public static class DALProfile
    {
        public static testProfile[] GetProfile()
        {
            myDbContext Context = new myDbContext();
            var model = Context.testProfile.ToList();
            return model.ToArray();
        }
        public static int GetSkillprofile(int ProfileUid,int SkillUid)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testProfile.Where(P=>P.Uid ==ProfileUid ).Select(A => new
            {
                A.Case1,A.Case2,A.Case3
            }).ToArray();

            switch (SkillUid)
            {
                case 1:
                    return Convert.ToInt32( model[0].Case1);
                case 2:
                    return Convert.ToInt32(model[0].Case2);
                case 3:
                    return Convert.ToInt32(model[0].Case3);
                default:
                    return 0;
            }
          
        }
        public static void UpdateSkill(int profileUid,int case1,int case2,int case3)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testProfile.Find(profileUid);
            model.Case1 = case1;
            model.Case2 = case2;
            model.Case3 = case3;
            Context.SaveChanges();
        }
    }
}
