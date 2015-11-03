using LJ.Reports.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LJ.Reports.Web.Controllers
{
    public class ReportsController : Controller
    {
        /// <summary>
        ///  显示统计列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            LoginBLL bll = new LoginBLL();
            return View(bll.testc());
        }

        /// <summary>
        /// 暂无
        /// </summary>
        /// <returns></returns>
        public void ReportsList()
        {
           //
        }

    }
}
