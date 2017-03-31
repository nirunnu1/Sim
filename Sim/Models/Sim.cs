using System;
using System.Collections;
using System.Linq;

namespace Simulations.Models
{
    //DynamicCaseFIFO
    public class DynamicCase
    {
        public static int numberUid(int Maintenan_mincase,int bastcase)
        {
            myDbContext Context = new myDbContext();
            var bastmin = Context.testProfile.Where(p => p.Uid == Maintenan_mincase).ToArray();

            if (bastmin.Where(m => m.Case1 == bastcase).Count() >= 1) { return   1; }
            else if (bastmin.Where(m => m.Case2 == bastcase).Count() >= 1) { return  2; }
            else {return 3; }
        }
        //public static void Dynamicase(string id,int numbercase,int num)
        //{
        //    myDbContext Context = new myDbContext();
        //    if (checkDynamic( numbercase,  num)==true )
        //    {
        //        int Maintenan_maxcase = Convert.ToInt32(GetMaxMaintenan(numbercase, num).ToString());
        //        int Maintenan_mincase = Convert.ToInt32(GetMinMaintenan(numbercase, num).ToString());
        //        testActivities[] max = Context.testActivities.Where(B => B.profileUid == Maintenan_maxcase && (B.status == "รอ" || B.status == "เริ่มงาน") && B.Case.number == numbercase && B.num == num).OrderBy(B => B.Case.Time).ToArray();
        //        var getmax = max.Where(m => m.status == "รอ").OrderBy(a => a.Case.Time).ToArray();
        //        if (id == "FIFO")
        //            {
               
        //                getmax[0].profileUid = Maintenan_mincase;
        //                Context.SaveChanges();
        //            }
        //            else if (id == "SJF" )
        //            {
        //            var basttimemin = Context.testProfile.Where(p => p.Uid == Maintenan_mincase).ToArray();
        //                int[] array = new int[] { Convert.ToInt32(basttimemin[0].Case1), Convert.ToInt32(basttimemin[0].Case2), Convert.ToInt32(basttimemin[0].Case3) };
        //                Array.Sort(array);
        //                int bastmincase = array[0];
        //                int A  = DynamicCase.numberUid(Maintenan_mincase, bastmincase);
        //                getmax = max.Where(i => i.Case.Numbercase == A).ToArray();
        //                int count = getmax.Count();
        //                while (getmax.Count() == 0 )
        //                {
        //                    count = count + 1;
        //                    if (count == 3){ break; }
        //                    bastmincase = array[count];
        //                    A = DynamicCase.numberUid(Maintenan_mincase, bastmincase);
        //                    getmax = max.Where(i => i.Case.Numbercase == A).ToArray();
        //                }
        //                if (getmax.Count()>0 && count<=2)
        //                {
        //                    getmax[0].profileUid = Maintenan_mincase;
        //                    Context.SaveChanges();
        //                }
        //        }
        //    };
        //}
        public static IEnumerable GetMaintenancerandom(int item)
        {
            Random rnd = new Random();
            int month = rnd.Next(0, item);
            return month.ToString();
        }
        public static bool checkDynamic(int numbercase, int num) {
            myDbContext Context = new myDbContext();
            testActivities[] Activities = Context.testActivities.Where(A => (A.status == testActivities.Getstatus.Wait|| A.status == testActivities.Getstatus.Running) && A.Case.number == numbercase && A.num == num).ToArray();
            testProfile[] profile = Context.testProfile.ToArray();
            var query = profile
              .GroupJoin(Activities, x => x.Uid, x => x.profileUid, (a, b) => new { a.Uid, b })
              .SelectMany(x => x.b.DefaultIfEmpty(),
              (a, b) => new { a.Uid, ActivitiesUid = (b == null ? Guid.Empty : b.Uid), ststus = (b == null ? string.Empty : b.status.ToString()) }).ToList();
            var newdata = query.GroupBy(u => u.Uid)
                                .Select(group => new { Uid = group.Key, Num = group.Count() })
                                .ToList();
            var max = newdata.Max(m => m.Num);
            var min = newdata.Min(m => m.Num);
            if ((max - min >= 2) || (max >= 2 && min <= 0) && Context.testActivities.Where(A => A.num == num && A.Case.number == numbercase).Count() >= 2)
            {
                return true;
            }
            return false;
        }


        //public static IEnumerable GetMaxMaintenan(int numbercase, int num)
        // {
        //     myDbContext Context = new myDbContext();
        //     testActivities[] Activities = Context.testActivities.Where(A => (A.status == "รอ" || A.status == "ดำเนินงาน") && A.Case.number == numbercase && A.num == num).ToArray();
        //     testProfile[] profile = Context.testProfile.ToArray();

        //     var query = profile
        //       .GroupJoin(Activities, x => x.Uid, x => x.profileUid, (a, b) => new { a.Uid, b })
        //       .SelectMany(x => x.b.DefaultIfEmpty(),
        //       (a, b) => new { a.Uid, ActivitiesUid = (b == null ? Guid.Empty : b.Uid), ststus = (b == null ? string.Empty : b.status) }).ToList();
        //     var newdata = query.GroupBy(u => u.Uid)
        //                         .Select(group => new { Uid = group.Key, Num = group.Count() })
        //                         .ToList();
        //         var max = newdata.Max(m => m.Num);
        //         var maxcase = newdata.Where(m => m.Num == max).ToList();
        //         return maxcase[0].Uid.ToString();
        // }
        // public static IEnumerable GetMinMaintenan(int numbercase, int num)
        // {
        //     myDbContext Context = new myDbContext();
        //     testActivities[] Activities = Context.testActivities.Where(A => (A.status == "รอ" || A.status == "ดำเนินงาน") && A.Case.number == numbercase && A.num == num).ToArray();

        //     var query = from p in Context.testProfile.ToArray()
        //     join a in Activities on p.Uid equals a.profileUid into pa
        //                 from subpet in pa.DefaultIfEmpty()
        //                 select new { p.Uid, ActivitiesUid = (subpet == null ? Guid.Empty : subpet.Uid), ststus = (subpet == null ? string.Empty : subpet.status) };


        //         var newdata = query.GroupBy(u => u.Uid)
        //                                           .Select(group => new { Uid = group.Key, Num = group.Count() })
        //                                            .ToList();
        //         var min = newdata.Min(m => m.Num);
        //         var mincase = newdata.Where(m => m.Num == min).ToList();
        //         return mincase[0].Uid.ToString();


        // }
        public static IEnumerable Getminmax(int numbercase, int num)
        {
            myDbContext Context = new myDbContext();
            testActivities[] Activities = Context.testActivities.Where(A => (A.status == testActivities.Getstatus.Wait || A.status == testActivities.Getstatus.Running) && A.Case.number == numbercase && A.num == num).ToArray();
            testProfile[] profile = Context.testProfile.ToArray();

            var query = profile
                .GroupJoin(Activities, x => x.Uid, x => x.profileUid, (a, b) => new { a.Uid, b })
                .SelectMany(x => x.b.DefaultIfEmpty(),
                (a, b) => new { a.Uid, ActivitiesUid = (b == null ? Guid.Empty : b.Uid), ststus = (b == null ? string.Empty : b.status.ToString()) }).ToList();
            var newdata = query.GroupBy(u => u.Uid)
                                .Select(group => new { Uid = group.Key, Num = group.Count() }).OrderBy(n => n.Num)
                                .ToArray();
            return newdata.Select(n=>n.Uid);
        }
        public static void Dynamicase(string id, int numbercase, int num)
        {
            myDbContext Context = new myDbContext();
            if (checkDynamic(numbercase, num) == true)
            {
                int[] profile = new int[3];
                int Uid = 0;
                foreach(int v in Getminmax( numbercase,  num))
                {
                    profile[Uid] = v; Uid = Uid + 1;
                }
                int Maintenan_maxcase = profile[2];
                int Maintenan_mincase = profile[0];
                testActivities[] maxcase = Context.testActivities.Where(B => B.profileUid == Maintenan_maxcase && (B.status == testActivities.Getstatus.Wait || B.status == testActivities.Getstatus.Running) && B.Case.number == numbercase && B.num == num).OrderBy(B => B.Case.Time).ToArray();
                var getmax = maxcase.Where(m => m.status == testActivities.Getstatus.Wait).OrderBy(a => a.Case.Time).ToArray();
                if (id == "FIFO")
                {

                    getmax[0].profileUid = Maintenan_mincase;
                    Context.SaveChanges();
                }
                else if (id == "SJF")
                {
                    var basttimemin = Context.testProfile.Where(p => p.Uid == Maintenan_mincase).ToArray();
                    int[] array = new int[] { Convert.ToInt32(basttimemin[0].Case1), Convert.ToInt32(basttimemin[0].Case2), Convert.ToInt32(basttimemin[0].Case3) };
                    Array.Sort(array);
                    int casei = 0;
                    int A = DynamicCase.numberUid(Maintenan_mincase, array[casei]);
                    getmax = maxcase.Where(i => i.Case.Numbercase == A).ToArray();
                    int count = getmax.Count();

                    while (getmax.Count() == 0)
                    {
                        casei = casei + 1;
                        if (casei == 3) { break; }
                        A = DynamicCase.numberUid(Maintenan_mincase, array[casei]);
                        getmax = maxcase.Where(i => i.Case.Numbercase == A).ToArray();
                    }
                    if (getmax.Count() > 0 && casei <= 2)
                    {
                        getmax[0].profileUid = Maintenan_mincase;
                        Context.SaveChanges();
                    }
                }
            };
        }
    }
}
