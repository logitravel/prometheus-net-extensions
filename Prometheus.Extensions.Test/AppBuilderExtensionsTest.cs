using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toolfactory.Prometheus.Extensions.Test
{
    [TestClass]
    public class AppBuilderExtensionsTest
    {
        [TestMethod]
        public async Task GetMetrics_MetricsRetrievedSuccessfully_CallToMetricsEndpoint()
        {

            using (var server = TestServer.Create<TestingStartup>())
            {
                var response = await server.HttpClient.GetAsync("/metrics");
                                
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual("text/plain", response.Content.Headers.ContentType.MediaType);

                var stringContent = await response.Content.ReadAsStringAsync();
                Assert.IsTrue(stringContent.Contains("process_windows_processid"));
            }

        }
    }
}
