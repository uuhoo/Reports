using LJ.Reports.DAL;
using LJ.Reports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Reports.BLL
{
    /// <summary>
    /// 登录业务
    /// </summary>
    public class LoginBLL
    {
        public bool Login(string username, string password)
        {
            LoginDAL _dal = new LoginDAL();
            /**
             * 1.验证用户 
             * 2.  如果成功保存用户信息到session
             * **/

            return _dal.Login(username, password);
        }
    }
}
