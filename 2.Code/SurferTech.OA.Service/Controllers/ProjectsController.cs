using SurferTech.OA.DataAccess.Dao;
using SurferTech.OA.ServiceContract.Models;
using SurferTech.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SurferTech.OA.Service.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : BaseController
    {
        public async Task<BizResult<List<ProjectModel>>> Get()
        {
            return await InvokeWithCatchAsync(() =>
            {
                return new ProjectDao().GetAll().ListCovnertTo<ProjectModel>().ToList();
            });
        }

        public async Task<BizResult<ProjectModel>> Get(int id)
        {
            return await InvokeWithCatchAsync(() =>
            {
                if (id <= 0)
                {
                    throw new BizException(-1, "项目Id不能为空");
                }
                var project = new ProjectDao().Get(id);
                if (project == null)
                {
                    throw new BizException(-1, "根据项目Id【{0}】未查询到项目信息", id);
                }
                return project.ConvertTo<ProjectModel>();
            });
        }

        public async Task<BizResult<ProjectQueryResultModel>> Get(int pageSize, int pageNo)
        {
            return await InvokeWithCatchAsync(() =>
            {
                var result = new ProjectQueryResultModel();
                if(pageSize <1)
                {
                    throw new BizException(-1, "pageSize不合法");
                }
                if (pageNo < 1)
                {
                    throw new BizException(-1, "pageNo不合法");
                }
                int totalCount;
                result.ResultList = new ProjectDao().Get(pageSize, pageNo, out totalCount).ListCovnertTo<ProjectModel>().ToList();
                result.TotalCount = totalCount;
                return result;
            });
        }
    }
}