using LJ.Reports.Web.Filters;
using System;
using System.Web;
using System.Web.Mvc;

namespace LJ.Reports.Web
{

    public class SkipLoginAttribute : Attribute
    {
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginValidateAttribute()); //登录验证
        }
    }
}