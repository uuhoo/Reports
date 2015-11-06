using LJ.Reports.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LJ.Reports.Web.Controllers
{

    public class HomeController : Controller
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [SkipLoginAttribute]
        public ActionResult UserLogin()
        {
            return View();
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [SkipLoginAttribute]
        public ActionResult ValidateUser(FormCollection form)
        {
            string username = form["loginName"].ToString();
            string password = form["pwd"].ToString();

            //需要验证 用户名 密码
            LoginBLL bll = new LoginBLL();
            if (bll.Login(username, password))
            {
                //登录成功，跳转到主页面
                return this.JsonResult(E_JsonResult.OK, "", null, "~/Reports/Index");
            }
            else
            {
                //登录失败,发送错误错误给用户
                return this.JsonResult(E_JsonResult.Error, "登录失败！用户名密码错误！", null, null);
            }
        }

        /// <summary>
        /// Filters跳转到登录页面
        /// </summary>
        /// <returns></returns>
        [SkipLoginAttribute]
        public ActionResult RedirectToLogin()
        {
            return View();
        }
    }
}
