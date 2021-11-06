using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using aspDateQueryStringBugDemo;
using System;
using aspDateQueryStringBugSDK;
using System.Threading.Tasks;

namespace aspDateQueryStringBugTests
{
    public class Tests
    {
        private TestServer _server;
        private AspDateQueryStringBugRequestSender _SUT;

        [SetUp]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseKestrel()
                .UseStartup<Startup>();

            _server = new TestServer(builder);
            
            _SUT = new AspDateQueryStringBugRequestSender(new Uri("http://localhost:5000"));
        }

        [Test]
        public async Task When_Date_Is_Unambigously_Not_Christmas_Return_No()
        {
            // Arrange
            var date = new DateTime(2021, 1, 1);

            // Act

            var result = await _SUT.IsItChristmas(date);

            // Assert
            Assert.That(result != null);
        }
    }
}
