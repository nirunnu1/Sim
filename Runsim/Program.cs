using System;
using System.Collections.Generic;
using Simulations.Models;
using Simulations;

namespace Runsim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("add >>  ");
            myDbContext context = new myDbContext();
            List<testProfile> list = new List<testProfile>()
            {
                new testProfile(){ Uid = 1,Name = "AAA", Case1= 5,Case2= 10, Case3= 15 },
                new testProfile(){ Uid = 2,Name = "BBB", Case1= 15,Case2= 10, Case3= 5 },
                new testProfile(){ Uid = 3,Name = "CCC", Case1= 5,Case2= 15, Case3= 10 }
            };
            context.testProfile.AddRange(list);
            context.SaveChanges();
            List<SettingCase> listcase = new List<SettingCase>()
            {
                new SettingCase(){Uid = new Guid(),Name = "DefaultIf",Case1 = 33,Case2=33,Case3=35 }
            };
            context.SettingCase.AddRange(listcase);
            context.SaveChanges();
        }
        
    }
}
