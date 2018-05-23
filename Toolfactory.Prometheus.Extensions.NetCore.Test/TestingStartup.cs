using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Toolfactory.Prometheus.Extensions.NetCore.Test
{
    public class TestingStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UsePrometheus();
        }
    }
}
