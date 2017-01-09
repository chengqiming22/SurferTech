using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SurferTech.OA.Web.Controllers
{
    public class BaseController : Controller
    {
        public int UserId
        {
            get
            {
                if(User.Identity.IsAuthenticated)
                {
                    return User.Identity.GetUserId<int>();
                }
                return -1;
            }
        }
	}
}