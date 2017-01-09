using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurferTech.OA.ServiceClient.Clients;
using SurferTech.OA.ServiceContract.Models;

namespace SurferTech.OA.ServiceClient.Tests
{
    [TestClass]
    public class UsersServiceClientTest
    {
        private UsersServiceClient client = new UsersServiceClient();

        [TestMethod]
        public void TestGetUserByUserName()
        {
            var result = client.GetUser("admin");
            result.Wait();
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void TestGetUserByUserId()
        {
            var result = client.GetUser(1);
            result.Wait();
            Assert.IsNotNull(result.Result);
        }
    }
}
