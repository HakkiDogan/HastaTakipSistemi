using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HastaTakip.Controllers;
using HastaTakip.Helper;

namespace HastaTakip
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //StartScheduler();
        }
        /*
        //public List<VitalSignMeasurementController> deneme = new List<VitalSignMeasurementController>();
        private static void StartScheduler()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            IScheduler sched = schedFact.GetScheduler();
            sched.Start();


            IJobDetail job = JobBuilder.Create<SetVitalValue>().WithIdentity("job1", "group1").Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity("job1", "group1").StartAt(DateTime.Now).WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(2)).Build();
            sched.ScheduleJob(job, trigger);
        }

        
        /*public class SetVitalValue : IJob
        {
            void IJob.Execute(IJobExecutionContext context)
            {
                //VitalSignMeasurementController m = new VitalSignMeasurementController();
                //m.AddVitalSignAll();                   
            }
        }*/

    }
}
