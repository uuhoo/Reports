using LJ.Reports.BLL;
using LJ.Reports.Entity;
using LJ.Reports.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LJ.Reports.Web.Controllers
{
    public class DataServiceController : Controller
    {
        /// <summary>
        /// 获取服务机构数据
        /// </summary>
        /// <param name="orgSign">组织标识</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GeOrgListBy(int orgSign)
        {
            List<organization> list =new List<organization>();
            try
            {
                List<string> organizationList = new List<string>();
                var listCenter = SessionHelper.GetSession(SessionHelper.SubCenters) as List<center>;
                organizationList = listCenter.Where(c => c.org_sign.Equals(orgSign)).Select(c => c.org_id).ToList();  //根据机构标识 获取组织ID

                list.Add(new organization() { id = -1, name = "--全选--" });
                if (orgSign.Equals(1))
                    list.AddRange(new DataServiceBLL().GeOrganizationBy(string.Join(",", organizationList)));
                else
                    list.AddRange(new DataServiceBLL().GeStaffOrganizationBy(string.Join(",", organizationList)));

                return Json(list);
            }
            catch (Exception)
            {
                return this.Json("");
            }
        }



    }
}
