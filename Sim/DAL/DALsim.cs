using Sim.Regridview;
using System;
using System.Collections;
using System.Linq;

namespace Simulations.Models
{
    public class DALsim
    {
        public static int randomcase()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 4);
            return randomNumber;
        }
        public static int cadd = 0;
        public static void caseadd(int id)
        {

            myDbContext Context = new myDbContext();
            var item = new testCase()
            {
                Uid = Guid.NewGuid(),
                Numbercase = regridview.casegen[cadd]/* randomcase()*/,
                Time = DateTime.Now,
                number = id
            };
            cadd = cadd + 1;
            Context.testCase.Add(item);
            Context.SaveChanges();

            ActivitiesAddFIFO(item.Uid);
            ActivitiesAddSJF(item.Uid, item.Numbercase);


        }
        public static void ActivitiesAdd(Guid id, int profile, int num)
        {
            myDbContext Context = new myDbContext();
            var item = new testActivities()
            {
                Uid = Guid.NewGuid(),
                CaseUid = id,
                profileUid = profile,
                DateStart = null,
                DateEnd = null,
                status = testActivities.Getstatus.Wait,
                num = num
            };
            Context.testActivities.Add(item);
            Context.SaveChanges();
            var item1 = Context.testCase.Find(item.CaseUid);
            if (num == 2 || num == 5) { DynamicCase.Dynamicase("FIFO", item1.number, num); }
            else if (num == 3 || num == 6 && testCase.Getcout()>1) { DynamicCase.Dynamicase("SJF", item1.number, num); }
        }

        public static void ActivitiesAddFIFO(Guid id)
        {
            ActivitiesAdd(id, getprofileActivitiesAddFIFO(1), 1);
            ActivitiesAdd(id, getprofileActivitiesAddFIFO(2), 2);
            ActivitiesAdd(id, getprofileActivitiesAddFIFO(3), 3);

        }
        public static void ActivitiesAddSJF(Guid id, int Numbercase)
        {
            ActivitiesAdd(id, getprofileActivitiesAddJSF(Numbercase), 4);
            ActivitiesAdd(id, getprofileActivitiesAddJSF(Numbercase), 5);
            ActivitiesAdd(id, getprofileActivitiesAddJSF(Numbercase), 6);
        }
        public static IEnumerable GetPRofilerandom(int item)
        {
            Random rnd = new Random();
            int month = rnd.Next(0, item);
            return month.ToString();
        }
        public static int getprofileActivitiesAddFIFO(int num)
        {
            myDbContext Context = new myDbContext();
            testActivities[] Activities = Context.testActivities.Where(A => (A.status == testActivities.Getstatus.Wait || A.status == testActivities.Getstatus.Running)&& A.num == num).ToArray();
            testProfile[] Profile = Context.testProfile.ToArray();

            var query = Profile
           .GroupJoin(Activities, x => x.Uid, x => x.profileUid, (a, b) => new { a.Uid, b })
           .SelectMany(x => x.b.DefaultIfEmpty(),
           (a, b) => new { a.Uid, ActivitiesUid = (b == null ? Guid.Empty : b.Uid), ststus = (b == null ? string.Empty : b.status.ToString()) }).ToList();
            var query1 = from q in query where q.ststus != testActivities.Getstatus.Wait.ToString() && q.ststus != testActivities.Getstatus.Running.ToString() select new { q.Uid };


            if (query1.Count() >= 1)
            {
                var newdata = query1.GroupBy(u => u.Uid)
                                    .Select(group => new { Uid = group.Key, Num = group.Count() })
                                    .ToList();
                var min = newdata.Min(m => m.Num);
                var mincase = newdata.Where(m => m.Num == min).ToList();
                if (mincase.Count >= 2)
                {
                    
                    int item = Convert.ToInt32(GetPRofilerandom(mincase.Count-1));
                    return mincase[item].Uid;
                }
                else
                {
                    return mincase[0].Uid;
                }
            }
            else
            {
                var newdata = query.GroupBy(u => u.Uid)
                                                     .Select(group => new { Uid = group.Key, Num = group.Count() })
                                                      .ToList();
                var min = newdata.Min(m => m.Num);
                var mincase = newdata.Where(m => m.Num == min).ToList();
                if (mincase.Count >= 2)
                {
                    int item = Convert.ToInt32(GetPRofilerandom(mincase.Count-1));
                    return mincase[item].Uid;
                }
                else
                {
                    return mincase[0].Uid;
                }
            }
        }
        public static int getprofileActivitiesAddJSF(int Numbercase)
        {
            myDbContext Context = new myDbContext();
            testProfile[] Profile = Context.testProfile.ToArray();

            var A = Profile.Select(q => new { q.Uid, q.Case1, q.Case2, q.Case3 });
            switch (Numbercase)
            {
                case 1:
                    var min1 = A.Min(m => m.Case1);
                    var minid1 = A.Where(q => q.Case1 == min1).Select(q => q.Uid).ToList();
                    return Convert.ToInt32(minid1[0]);

                case 2:
                    var min2 = A.Min(m => m.Case2);
                    var minid2 = A.Where(q => q.Case2 == min2).Select(q => q.Uid).ToList();
                    return Convert.ToInt32(minid2[0]);

                case 3:
                    var min3 = A.Min(m => m.Case3);
                    var minid3 = A.Where(q => q.Case3 == min3).Select(q => q.Uid).ToList();
                    return Convert.ToInt32(minid3[0]);

                default:
                    return 0;
            }
        }
        public static int minTimecase(int id)
        {
            myDbContext Context = new myDbContext();
            testActivities[] Activities = Context.testActivities.Where(ta => (ta.status == testActivities.Getstatus.Wait || ta.status == testActivities.Getstatus.Running)).ToArray();
            testProfile[] profile = Context.testProfile.ToArray();
            var query = profile
           .GroupJoin(Activities, x => x.Uid, x => x.profileUid, (a, b) => new { a.Uid, b })
           .SelectMany(x => x.b.DefaultIfEmpty(),
           (a, b) => new { a.Uid, ActivitiesUid = (b == null ? Guid.Empty : b.Uid), ststus = b.status }).ToList();
            var query1 = query.Where(q => q.ststus != testActivities.Getstatus.Wait).Select(q => new { q.Uid });
            if (query1.Count() >= 1)
            {
                var newdata = query1.GroupBy(u => u.Uid)
                                                .Select(group => new { Uid = group.Key, Num = group.Count() })
                                                 .ToList();
                var min = newdata.Min(m => m.Num);
                var mincase = newdata.Where(m => m.Num == min).ToList();
                var A = from q in profile join m in mincase on q.Uid equals m.Uid select new { q.Uid, q.Case1, q.Case2, q.Case3 };
                switch (id)
                {
                    case 1:
                        var min1 = A.Min(m => m.Case1);
                        var minid1 = A.Where(q => q.Case1 == min1).Select(q => q.Uid).ToList();
                        return Convert.ToInt32(minid1[0]);

                    case 2:
                        var min2 = A.Min(m => m.Case2);
                        var minid2 = A.Where(q => q.Case2 == min2).Select(q => q.Uid).ToList();
                        return Convert.ToInt32(minid2[0]);

                    case 3:
                        var min3 = A.Min(m => m.Case3);
                        var minid3 = A.Where(q => q.Case3 == min3).Select(q => q.Uid).ToList();
                        return Convert.ToInt32(minid3[0]);

                    default:
                        return 0;
                }

            }
            else
            {
                var newdata = query.GroupBy(u => u.Uid)
                                                  .Select(group => new { Uid = group.Key, Num = group.Count() })
                                                   .ToList();
                var min = newdata.Min(m => m.Num);
                var mincase = newdata.Where(m => m.Num == min).ToList();
                return mincase[0].Uid;
            }
        }
        public static void tabledelete()
        {
            myDbContext Context = new myDbContext();
            var B = Context.testActivities;

            Context.testActivities.RemoveRange(B);

            Context.SaveChanges();
            var a = Context.testCase;

            Context.testCase.RemoveRange(a);

            Context.SaveChanges();


        }

    }
}
