using LJ.Reports.BLL;
using LJ.Reports.Entity;
using LJ.Reports.Entity.EasyUIModel;
using LJ.Reports.Utility;
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
            return View();
        }

        /// <summary>
        /// 获取统计列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ReportsList()
        {
            int pageSize = int.Parse(Request.Form["rows"]);
            //获取请求的页码
            int pageIndex = int.Parse(Request.Form["page"]);
            //从行数
            int rowCount = 0;

            //在session中获取CenterID
            center center=SessionHelper.GetSession(SessionHelper.LoginCenter) as center;

            // 查询分页数据
            List<permission> list = new PermissionBLL().getPermissionBy(center.id, pageIndex, pageSize, out rowCount);
            // 生成规定格式的 json字符串发回 给异步对象
            DataGridModel dgModel = new DataGridModel()
            {
                total = rowCount,
                rows = list,
                footer = null
            };

            return Json(dgModel);
        }

        #region 统计请求

        /// <summary>
        /// 服务统计
        /// </summary>
        public void ReportServerOrganization()
        {
            string ReportName = "ReportServerOrganization.rdlc";
            string aspxUrl = "~/Reports/ReportServerOrgData.aspx?ReportName=" + ReportName + "&org_sign=1";
            Response.Redirect(aspxUrl);
        }

        /// <summary>
        /// 推广统计
        /// </summary>
        public void ReportPromotionOrganization()
        {
            string ReportName = "ReportPromotionOrganization.rdlc";
            string aspxUrl = "~/Reports/ReportServerOrgData.aspx?ReportName=" + ReportName + "&org_sign=2";
            Response.Redirect(aspxUrl);
        }

        #endregion
    }
}
