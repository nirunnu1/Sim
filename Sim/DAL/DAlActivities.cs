using System;
using System.Collections;
using System.Linq;

namespace Simulations.Models
{
    public class DAlActivities
    {
        public static void Start(Guid id)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testActivities.Find(id);
            model.status = testActivities.Getstatus.Running;
            model.DateStart = DateTime.Now;
            Context.SaveChanges();
            if (model.num == 2 || model.num == 5) { DynamicCase.Dynamicase("FIFO", model.Case.number, model.num); }
            else if (model.num == 3 || model.num == 6) { DynamicCase.Dynamicase("SJF", model.Case.number, model.num); }
        }
        public static void End(Guid id)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testActivities.Find(id);
            model.status = testActivities.Getstatus.Commit;
            model.DateEnd = DateTime.Now;
            Context.SaveChanges();
            if (model.num == 2 || model.num == 5) { DynamicCase.Dynamicase("FIFO", model.Case.number, model.num); }
            else if (model.num == 3 || model.num == 6) { DynamicCase.Dynamicase("SJF", model.Case.number, model.num); }
        }
        public static IEnumerable GetActivities()
        {
            myDbContext Context = new myDbContext();
            var model = Context.testActivities.Select(A => new
            {
                A.Case.Time,
                DateStart = A.DateStart,
                DateEnd = A.DateEnd,
                A.testProfile.Name,
                A.status,
                A.Case.number,
                A.num
            });
            return model.OrderBy(A => A.Time).ToList();
        }
        public static int GetActivitiesEnd(int id)
        {
            myDbContext Context = new myDbContext();
            int model = Context.testActivities.Where(A => A.status == testActivities.Getstatus.Commit && A.Case.number == id).Count();
            return model;
        }
      
        public static int GetEnd(int casenumber, int num)
        {
            myDbContext Context = new myDbContext();
            return Context.testActivities.Where(A => A.status == testActivities.Getstatus.Commit && A.num == num && A.Case.number == casenumber).Count();


        }
        public static IEnumerable Getprofile(int id, int number)
        {
            myDbContext Context = new myDbContext();
            var model = Context.testActivities.Where(A => A.profileUid == id && A.num == number)
                                               .Select(A => new { A.Case.Time, DateStart = A.DateStart, DateEnd = A.DateEnd, A.status })
                                               .OrderBy(A => A.Time).ToList();
            return model;
        }

        public static int GetCaseCount(int casenumber, int num)
        {
            myDbContext Context = new myDbContext();

            return Context.testActivities.Where(A => A.Case.number == casenumber && A.num == num).Count(); ;
        }
        public static int GetSkill(int id)
        {
            int model = 0;
            myDbContext Context = new myDbContext();
            if (id == 1) { model = Context.testActivities.Where(a => a.profileUid == id && a.Case.Numbercase == 1).Count(); }
            if (id == 2) { model = Context.testActivities.Where(a => a.profileUid == id && a.Case.Numbercase == 2).Count(); }
            if (id == 3) { model = Context.testActivities.Where(a => a.profileUid == id && (a.Case.Numbercase == 3)).Count(); }
            return model;
        }
    }
}
