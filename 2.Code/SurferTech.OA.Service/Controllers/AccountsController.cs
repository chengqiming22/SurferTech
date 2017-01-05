using SurferTech.OA.DataAccess.Dao;
using SurferTech.OA.DataModel.Models;
using SurferTech.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SurferTech.OA.Service.Controllers
{
    public class AccountsController : ApiController
    {
        [HttpPost]
        public BizResult<UserModel> Login(LoginModel loginModel)
        {
            var result = new BizResult<UserModel>();
            try
            {
                var userModel = new UserModel();
                var user = new UserDao().GetUser(loginModel.UID, loginModel.Password);
                if (user == null)
                {
                    throw new BizException(-1, "登录失败，用户名或密码错误");
                }
                userModel.UID = user.UID;
                userModel.Pages = new PageDao().GetPagesByUID(user.UID);

                result.ResultObject = userModel;
            }
            catch (BizException ex)
            {
                result.SetCodeAndMessage(ex);
            }
            catch (Exception ex)
            {
                result.SetCodeAndMessage(-1, ex.Message);
            }
            return result;
        }
    }
}
