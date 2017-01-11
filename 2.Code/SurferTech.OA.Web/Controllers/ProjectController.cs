using SurferTech.OA.ServiceClient.Clients;
using SurferTech.OA.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SurferTech.Utils.Common;
using SurferTech.OA.DataModel.Enums;

namespace SurferTech.OA.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly int pageSize = 20;

        public async Task<ActionResult> Index(int page = 1)
        {
            var result = await new ProjectsServiceClient().GetProjectsAsync(pageSize, page);
            var viewModels = new List<ProjectViewModel>();
            if (result.Code != 0)
            {
                ViewBag.ErrorMessage = string.Format("获取项目列表失败：{0}", result.Message);
            }
            else if (result.ReturnObject == null 
                || result.ReturnObject.ResultList == null 
                || result.ReturnObject.ResultList.Count == 0)
            {
                ViewBag.ErrorMessage = "未查询到结果";
            }
            else
            {
                viewModels = result.ReturnObject.ResultList.Select(p => new ProjectViewModel(p)).ToList();
                ViewBag.TotalPages = (int)Math.Ceiling(viewModels.Count * 1.0 / pageSize);
            }
            ViewBag.TotalPages = (int)Math.Ceiling(result.ReturnObject.TotalCount * 1.0 / pageSize);
            return View(viewModels);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var result = await new ProjectsServiceClient().GetProjectAsync(id);
            if (result.Code != 0)
            {
                ViewBag.ErrorMessage = string.Format("获取项目信息失败：{0}", result.Message);
            }
            return View(new ProjectViewModel(result.ReturnObject));
        }
    }
}