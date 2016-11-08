using Owin;

namespace Prometheus.Extensions.Test
{
    public class TestingStartup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UsePrometheus();
        }
    }
}
