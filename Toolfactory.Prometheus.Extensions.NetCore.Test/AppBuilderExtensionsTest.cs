using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Toolfactory.Prometheus.Extensions.NetCore.Test
{
    [TestClass]
    public class AppBuilderExtensionsTest
    {
        
        private  HttpClient _client;
        [TestMethod]
        public async Task GetMetrics_MetricsRetrievedSuccessfully_CallToMetricsEndpoint_Net_Core()
        {
            using (var server = new TestServer(new WebHostBuilder().UseStartup<TestingStartup>()))
            {
                _client = server.CreateClient();
                var response = await _client.GetAsync("/metrics");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual("text/plain", response.Content.Headers.ContentType.MediaType);

                var stringContent = await response.Content.ReadAsStringAsync();
                Assert.IsTrue(stringContent.Contains("process_windows_processid"));

            }

                
        }
    }
}
