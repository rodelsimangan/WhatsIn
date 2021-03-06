﻿using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;

namespace WhatsIn.Web
{
    public class MvcApplication : AbpWebApplication<WhatsInWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            try { 
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            base.Application_Start(sender, e);
            }
            catch(Exception ex)
            {
                int i = 0;
            }
        }
    }
}
