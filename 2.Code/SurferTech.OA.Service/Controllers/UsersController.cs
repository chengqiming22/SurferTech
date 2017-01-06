using SurferTech.OA.DataAccess.Dao;
using SurferTech.OA.DataModel.Entites;
using SurferTech.OA.ServiceContract.Models;
using SurferTech.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SurferTech.OA.Service.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("~/api/login")]
        public BizResult<UserModel> Login(LoginModel loginModel)
        {
            var result = new BizResult<UserModel>();
            try
            {
                if (loginModel == null)
                {
                    throw new BizException(-1, "用户名和密码不能为空");
                }

                var userModel = new UserModel();
                var user = new UserDao().GetUser(loginModel.UID, loginModel.Password);
                if (user == null)
                {
                    throw new BizException(-1, "登录失败，用户名或密码错误");
                }
                userModel.UID = user.UID;
                var list = new PageDao().GetPagesByUID(user.UID);
                if (list != null)
                {
                    var groups = new List<PageGroupModel>();
                    foreach (var g in list.Select(p => p.Group).Distinct())
                    {
                        var group = g.ConvertTo<PageGroupModel>();
                        group.DefaultPage = g.Pages.FirstOrDefault(p => p.IsDefault).ConvertTo<PageModel>();
                        groups.Add(group);
                    }
                    userModel.PageGroups = groups;
                }

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

        public BizResult<List<User>> Get()
        {
            throw new NotImplementedException("GetAll未实现");
        }

        [HttpPost]
        public BizResult<List<User>> Get(UserQueryModel queryModel)
        {
            throw new NotImplementedException("GetByCondition未实现");
        }

        public BizResult<User> Get(int id)
        {
            throw new NotImplementedException("GetSingle未实现");
        }

        public BizResult Put(User user)
        {
            return new BizResult(0, user.Id + " " + user.UID);
        }

        public BizResult Delete(int id)
        {
            throw new NotImplementedException("DeleteUser未实现");
        }
    }
}
