﻿using SurferTech.OA.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace SurferTech.OA.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthenticatedFilterAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
