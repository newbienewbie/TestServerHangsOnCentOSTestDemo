using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace XLib.Test
{
    public class IntegrationTest
    {
        private IConfigurationRoot _config;

        public IntegrationTest() {
            var p = Path.GetDirectoryName((typeof(XLib.Sample.Startup).Assembly.Location));
            this._config= new ConfigurationBuilder()
                .SetBasePath(p)
                .AddJsonFile("appsettings.json")
                .Build();
        }


        [Fact]
        public void Test2()
        {
            var hb = new WebHostBuilder()
                .UseConfiguration(this._config)
                .UseStartup<XLib.Sample.Startup>()
                ;
            using(var _testServer= new TestServer(hb))
            using(var _client = _testServer.CreateClient())
            {
                var resp = _client.GetAsync("/home/index").Result;
                Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            }
        }

    }
}
