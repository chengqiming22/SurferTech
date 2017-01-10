﻿using SurferTech.OA.ServiceContract.Models;
using SurferTech.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceClient.Clients
{
    public class UsersServiceClient : ServiceClientBase
    {
        public async Task<BizResult<UserModel>> CreateUserAsync(UserModel userModel)
        {
            return await PostAsync<BizResult<UserModel>>("api/users", userModel);
        }

        public async Task<BizResult<UserModel>> GetUserAsync(int userId)
        {
            return await GetAsync<BizResult<UserModel>>(string.Format("api/users?id={0}", userId));
        }

        public async Task<BizResult<UserModel>> GetUserAsync(string userName)
        {
            return await GetAsync<BizResult<UserModel>>(string.Format("api/users?userName={0}", userName));
        }

        public BizResult<List<PageGroupModel>> GetPagesByUserName(string userName)
        {
            return Get<BizResult<List<PageGroupModel>>>(string.Format("api/users/{0}/pages", userName));
        }
    }
}
