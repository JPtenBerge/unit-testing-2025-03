using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.MSTest;

[TestClass]
public class HelloWorldWebcontainer
{
    [TestMethod]
    public async Task HelloWorldDing()
    {
        var container = new ContainerBuilder()
          .WithImage("testcontainers/helloworld:1.1.0")
          .WithPortBinding(8080, true)
          .WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(8080)))
          .Build();

        // Start the container.
        await container.StartAsync();

        var httpClient = new HttpClient();

        var requestUri = new UriBuilder(Uri.UriSchemeHttp, container.Hostname, container.GetMappedPublicPort(8080), "uuid").Uri;

        var guid = await httpClient.GetStringAsync(requestUri);
        
        Assert.IsTrue(Guid.TryParse(guid, out _));
    }
}
