using SurferTech.OA.ServiceContract.Models;
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
        public async Task<BizResult<UserModel>> GetUser(string userName)
        {
            return await Get<BizResult<UserModel>>(string.Format("api/users?userName={0}", userName));
        }

        public async Task<BizResult<UserModel>> GetUser(int userId)
        {
            return await Get<BizResult<UserModel>>(string.Format("api/users/{0}", userId));
        }
    }
}
