using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurferTech.OA.Web.Controllers
{
    [RoutePrefix("project")]
    public class ProjectController : Controller
    {
        [Route("")]
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        [Route("{projectId:int}")]
        public ActionResult Detail(int projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }
    }
}