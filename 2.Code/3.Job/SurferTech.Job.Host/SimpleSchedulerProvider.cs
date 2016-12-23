namespace SurferTech.Job.Host
{
    using System;
    using CrystalQuartz.Core.SchedulerProviders;
    using Quartz;
    using SurferTech.Job.Host.Jobs;

    public class SimpleSchedulerProvider : StdSchedulerProvider
    {
        protected override System.Collections.Specialized.NameValueCollection GetSchedulerProperties()
        {
            var properties = base.GetSchedulerProperties();
            // Place custom properties creation here:
            //     properties.Add("test1", "test1value");
            return properties;
        }

        protected override void InitScheduler(IScheduler scheduler)
        {
            // Put jobs creation code here

            // Sample job
            var jobDetail = JobBuilder.Create<HelloWorldJob>()
                .StoreDurably()
                .WithIdentity("HelloWorldJob")
                .Build();
                
            var trigger = TriggerBuilder.Create()
                .WithIdentity("HelloWorldTrigger")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();
                
            scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}