using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace LibraryTest
{
    [TestClass]
    public class TestInitializer
    {
        public static HttpClient TestHttpClient;
        public static Mock<SupplierRepository> MockEmployeeRepository;

        [AssemblyInitialize]
        public static void InitializeTestServer(TestContext testContext)
        {
            var testServer = new TestServer(new WebHostBuilder()
               .UseStartup<TestStartup>()
               // this would cause it to use StartupIntegrationTest class
               // or ConfigureServicesIntegrationTest / ConfigureIntegrationTest
               // methods (if existing)
               // rather than Startup, ConfigureServices and Configure
               .UseEnvironment("IntegrationTest"));

            TestHttpClient = testServer.CreateClient();
        }

        //public static void RegisterMockRepositories(IServiceCollection services)
        //{
        //    MockEmployeeRepository = (new Mock<IEmployeeRepository>());
        //    services.AddSingleton(MockEmployeeRepository.Object);

        //    //add more mock repositories below
        //}

        public static void RegisterMockRepositories(IServiceCollection services)
        {
            MockEmployeeRepository = (new Mock<SupplierRepository>());
              services.AddSingleton(MockEmployeeRepository.Object);
        }
    }
}
