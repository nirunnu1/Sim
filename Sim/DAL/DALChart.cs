using System;
using System.Linq;
using System.Collections;
using System.Data.Entity.Core.Objects;

namespace Simulations.Models
{
    public class DALChart
    {
        public static IEnumerable chart_all(int num,int casenum)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testActivities.Where(A => A.Case.number == casenum && A.num == num)
                                               .GroupBy(u => u.testProfile.Name)
                                               .Select(group => new { Name = group.Key, Num = group.Count() })
                                               .ToList();
            return model;
        }
        public static IEnumerable chart_alltime(int num, int casenum)
        {
            myDbContext Context = new myDbContext();

            var model = Context.testActivities.Where(A => A.Case.number == casenum && A.num == num)
                                              .GroupBy(u => u.testProfile.Name)
                                              .Select(group => new { Name = group.Key, num = group.Sum(g => EntityFunctions.DiffSeconds(g.DateStart, g.DateEnd)) })
                                               .ToList();
            return model;
        }
        public static int chart_timeprofile(int num, int casenum,int profileuid)
        {
            myDbContext Context = new myDbContext();

            var model = Context.testActivities.Where(A => A.Case.number == casenum && A.num == num && A.profileUid == profileuid)
                                              .GroupBy(u => u.testProfile.Name)
                                              .Select(group => new { Name = group.Key, num = group.Sum(g => EntityFunctions.DiffSeconds(g.DateStart, g.DateEnd)) })
                                               .ToList();
            return model.Sum(i => Convert.ToInt32(i.num));
        }
        public static int GetCount(int num, int casenum)
        {
            myDbContext Context = new myDbContext();
            int model = Context.testActivities.Where(A => A.status == testActivities.Getstatus.Commit && A.Case.number == casenum  && A.num == num).Count();
            return model;
        }
        public static int chart_timesum(int num, int casenum)
        {
            myDbContext Context = new myDbContext();
           
            var item = Context.testActivities.Where(A => A.Case.number == casenum && A.num == num)
                                            .GroupBy(u => u.testProfile.Name)
                                             .Select(group => new { Name = group.Key, num = group.Sum(g => EntityFunctions.DiffSeconds(g.DateStart, g.DateEnd)) })
                                              .ToList();

            return item.Sum(i => Convert.ToInt32(i.num));
        }
        public static IEnumerable chart_get(int id, int num, int casenum)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testActivities.Where(A => A.profileUid == id && A.Case.number == casenum && A.num == num)
                                              .GroupBy(u => u.Case.Numbercase)
                                              .Select(group => new { Name = group.Key, Num = group.Count() })
                                              .ToList();
            return model;
        }

        public static double chart_Waitingtime(int num, int casenum)
        {

            myDbContext Context = new myDbContext();
            var item1 = Context.testActivities.Where(A => A.Case.number == casenum && A.num == num)
                 .Select(i => new { time = i.Case.Time, DateStart = i.DateStart, num = EntityFunctions.DiffSeconds(i.Case.Time, i.DateStart) })
                                             .ToList();

            double alltime = 0;
            foreach (var i in item1)
            {
                Console.WriteLine(i.time + "  " + i.DateStart + "" + i.num);
                alltime = alltime + Convert.ToInt16(i.num);
            }
            double Waitingtime = alltime / item1.Count();

            return Waitingtime;
        }

    }
}
