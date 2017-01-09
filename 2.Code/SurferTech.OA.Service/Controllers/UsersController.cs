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
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        //[HttpPost]
        //[Route("~/api/login")]
        //public BizResult<UserModel> Login(LoginModel loginModel)
        //{
        //    var result = new BizResult<UserModel>();
        //    try
        //    {
        //        if (loginModel == null)
        //        {
        //            throw new BizException(-1, "用户名和密码不能为空");
        //        }

        //        var userModel = new UserModel();
        //        var user = new UserDao().GetUser(loginModel.UserName, loginModel.Password);
        //        if (user == null)
        //        {
        //            throw new BizException(-1, "登录失败，用户名或密码错误");
        //        }
        //        userModel.UserName = user.UserName;
        //        var list = new PageDao().GetPagesByUserName(user.UserName);
        //        if (list != null)
        //        {
        //            var groups = new List<PageGroupModel>();
        //            foreach (var g in list.Select(p => p.Group).Distinct())
        //            {
        //                var group = g.ConvertTo<PageGroupModel>();
        //                group.DefaultPage = g.Pages.FirstOrDefault(p => p.IsDefault).ConvertTo<PageModel>();
        //                groups.Add(group);
        //            }
        //            userModel.PageGroups = groups;
        //        }

        //        result.ResultObject = userModel;
        //    }
        //    catch (BizException ex)
        //    {
        //        result.SetCodeAndMessage(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.SetCodeAndMessage(-1, ex.Message);
        //    }
        //    return result;
        //}

        public BizResult<List<User>> Get()
        {
            throw new NotImplementedException("GetAll未实现");
        }

        [HttpPost]
        public BizResult<List<User>> Get(UserQueryModel queryModel)
        {
            throw new NotImplementedException("GetByCondition未实现");
        }

        [Route("{userId:int}")]
        public BizResult<UserModel> Get(int userId)
        {
            var result = new BizResult<UserModel>();
            try
            {
                if (userId <= 0)
                {
                    throw new BizException(-1, "用户Id不能为空");
                }

                var user = new UserDao().GetUser(userId);
                if (user == null)
                {
                    throw new BizException(-1, "根据用户Id【{0}】未查询到用户信息", userId);
                }
                result.ResultObject = user.ConvertTo<UserModel>();
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

        public BizResult<UserModel> Get(string userName)
        {
            var result = new BizResult<UserModel>();
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    throw new BizException(-1, "用户名不能为空");
                }

                var user = new UserDao().GetUser(userName);
                if (user == null)
                {
                    throw new BizException(-1, "根据用户名【{0}】未查询到用户信息",userName);
                }
                result.ResultObject = user.ConvertTo<UserModel>();
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

        public BizResult Put(User user)
        {
            return new BizResult(0, user.Id + " " + user.UserName);
        }

        public BizResult Delete(int id)
        {
            throw new NotImplementedException("DeleteUser未实现");
        }
    }
}
