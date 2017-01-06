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
        public void TestLogin()
        {
            var loginModel = new LoginModel
            {
                UID = "admin",
                Password = "123456"
            };
            var result = client.Login(loginModel);
            result.Wait();
            Assert.IsNotNull(result.Result);
        }
    }
}
