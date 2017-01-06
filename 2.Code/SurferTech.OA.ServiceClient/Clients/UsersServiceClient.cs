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
        public async Task<BizResult<UserModel>> Login(LoginModel loginModel)
        {
            return await Post<BizResult<UserModel>>("api/login", loginModel);
        }
    }
}
