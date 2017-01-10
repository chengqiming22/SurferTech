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
        public BizResult<UserModel> Post(UserModel userModel)
        {
            var result = new BizResult<UserModel>();
            try
            {
                if (userModel == null)
                {
                    throw new BizException(-1, "用户信息不能为空");
                }

                var user = userModel.ConvertTo<User>();
                user.IsActive = true;
                if (!new UserDao().CreateUser(user))
                {
                    throw new BizException(-1, "创建用户失败");
                }
                result.ReturnObject = user.ConvertTo<UserModel>();
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

        public BizResult<UserModel> Get(int id)
        {
            var result = new BizResult<UserModel>();
            try
            {
                if (id <= 0)
                {
                    throw new BizException(-1, "用户Id不能为空");
                }

                var user = new UserDao().GetUser(id);
                if (user == null)
                {
                    throw new BizException(-1, "根据用户Id【{0}】未查询到用户信息", id);
                }
                result.ReturnObject = user.ConvertTo<UserModel>();
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
                    throw new BizException(-1, "根据用户名【{0}】未查询到用户信息", userName);
                }
                result.ReturnObject = user.ConvertTo<UserModel>();
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

        [Route("{userName}/pages")]
        public BizResult<List<PageGroupModel>> GetPagesByUserName(string userName)
        {
            var result = new BizResult<List<PageGroupModel>>();
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    throw new BizException(-1, "用户名不能为空");
                }

                var pages = new PageDao().GetPagesByUserName(userName);
                if (pages == null || pages.Count == 0)
                {
                    throw new BizException(-1, "根据用户名【{0}】未查询到结果", userName);
                }

                var groups = new List<PageGroupModel>();
                foreach (var g in pages.Select(p => p.Group).Distinct())
                {
                    var group = g.ConvertTo<PageGroupModel>();
                    group.DefaultPage = g.Pages.FirstOrDefault(p => p.IsDefault).ConvertTo<PageModel>();
                    groups.Add(group);
                }
                result.ReturnObject = groups;
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
