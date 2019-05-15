using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(blogWeb.Startup))]

namespace blogWeb
{
    public class Startup
    {
        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Data Source=DTMSIS18;Initial Catalog=blog;Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });

            yield return new BackgroundJobServer();
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireAspNet(GetHangfireServers);
            app.UseHangfireDashboard();

            // Let's also create a sample background job
            BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
        }
    }
}
