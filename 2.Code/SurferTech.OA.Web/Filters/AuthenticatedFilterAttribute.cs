using SurferTech.OA.ServiceClient.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurferTech.OA.Web.Filters
{
    public class AuthenticatedFilterAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller;
            var user = filterContext.HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var result = new UsersServiceClient().GetPagesByUserName(user.Identity.Name);
                if (result.Code == 0)
                {
                    controller.ViewBag.PageGroups = result.ReturnObject;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}