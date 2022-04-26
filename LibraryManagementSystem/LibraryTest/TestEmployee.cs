using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LibraryTest
{
    [TestClass]
    public class TestEmployee
    {
        [TestMethod]
        public void TestGetAllEmployees()
        {
            var mockEmps = new List<Supplier>();
            mockEmps.Add(new Supplier
            { SupplierId = 1, SupplierName = "F1", PurchaseNumber = 12 });
            mockEmps.Add(new Supplier
            { SupplierId = 2, SupplierName = "F1", PurchaseNumber = 123 });

            var employeeRepositoryMock = TestInitializer.MockEmployeeRepository;
            employeeRepositoryMock.Setup
                  (x => x.GetSuppliers()).Returns(Task.FromResult(mockEmps));

            var response = TestInitializer.TestHttpClient.GetAsync("api/Supplier").Result;

            var resp = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<List<Supplier>>(resp);
            Assert.AreEqual(3, responseData.Count);
            Assert.AreEqual(mockEmps[0].SupplierId, responseData[0].SupplierId);
        }
    }
}
