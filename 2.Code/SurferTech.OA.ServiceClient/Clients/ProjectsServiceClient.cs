using SurferTech.OA.ServiceContract.Models;
using SurferTech.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceClient.Clients
{
    public class ProjectsServiceClient : ServiceClientBase
    {
        public BizResult<List<ProjectModel>> GetAllProjects()
        {
            return Get<BizResult<List<ProjectModel>>>("api/projects");
        }
        public async Task<BizResult<List<ProjectModel>>> GetAllProjectsAsync()
        {
            return await GetAsync<BizResult<List<ProjectModel>>>("api/projects");
        }

        public BizResult<ProjectModel> GetProject(int id)
        {
            return Get<BizResult<ProjectModel>>("api/projects/{0}", id);
        }
        public async Task<BizResult<ProjectModel>> GetProjectAsync(int id)
        {
            return await GetAsync<BizResult<ProjectModel>>("api/projects/{0}", id);
        }

        public BizResult<ProjectQueryResultModel> GetProjects(int pageSize, int pageNo)
        {
            return Get<BizResult<ProjectQueryResultModel>>("api/projects?pageSize={0}&pageNo={1}", pageSize, pageNo);
        }
        public async Task<BizResult<ProjectQueryResultModel>> GetProjectsAsync(int pageSize, int pageNo)
        {
            return await GetAsync<BizResult<ProjectQueryResultModel>>("api/projects?pageSize={0}&pageNo={1}", pageSize, pageNo);
        }
    }
}
