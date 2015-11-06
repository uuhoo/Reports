using LJ.Reports.DAL;
using LJ.Reports.Entity;
using LJ.Reports.Utility;
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
            /*
             * 1.验证用户 
             * 2.如果成功保存用户信息到session
             */

            center user = _dal.Login(username, password);
            if (user != null)
            {
                SessionHelper.SetSession(SessionHelper.LoginCenter, user); //保存登录的Center

                var listCenter = new CenterDAL().GetAllCounts();
                List<center> listSubCenters = new List<center>();

                if (user.org_sign > 0)
                    listSubCenters.Add(user);

                getSubCenterOrgIDsBy(listCenter, listSubCenters, user.id); // 递归得到 下属服务机构 and 推广机构信息
                SessionHelper.SetSession(SessionHelper.SubCenters, listSubCenters); //保存子中心
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取所有下级组织信息
        /// </summary>
        public void getSubCenterOrgIDsBy(List<center> allCenter, List<center> listSubCenters, int pCenterID)
        {
           // 1.循环所有center
           // 2.判断 父节点里面所有 = pCenterID    然后加入 subCenter中
         
            foreach (var item in allCenter)
            {
                if (item.parent_code.Equals(pCenterID))
                {
                    if (item.org_sign > 0)
                        listSubCenters.Add(item);// 添加到子中心

                    getSubCenterOrgIDsBy(allCenter, listSubCenters, item.id); //继续找子中心
                }
            }
        }
    }
}
