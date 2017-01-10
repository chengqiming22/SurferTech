﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurferTech.OA.ServiceClient.Clients;
using SurferTech.OA.ServiceContract.Models;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceClient.Tests
{
    [TestClass]
    public class UsersServiceClientTest
    {
        private UsersServiceClient client = new UsersServiceClient();

        [TestMethod]
        public async Task TestGetUserByUserName()
        {
            var result = await client.GetUserAsync("admin");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestGetUserByUserId()
        {
            var result = await client.GetUserAsync(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetPagesByUserName()
        {
            var result = client.GetPagesByUserName("admin");
            Assert.IsNotNull(result);
        }
    }
}
