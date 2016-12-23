using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurferTech.Job.Host.Jobs
{
    public class HelloWorldJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello World, CrystalQuartz!");
        }
    }
}