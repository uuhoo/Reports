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
    /// 数据服务类
    /// </summary>
    public class DataServiceBLL
    {
        /// <summary>
        ///  获取服务机构
        /// </summary>
        /// <param name="orgIDs"></param>
        /// <returns></returns>
        public List<organization> GeOrganizationBy(string orgIDs)
        {
            return new OrganizationDAL().GeOrganizationBy(orgIDs);
        }

        /// <summary>
        /// 获取推广机构
        /// </summary>
        /// <param name="orgIDs"></param>
        /// <returns></returns>
        public List<organization> GeStaffOrganizationBy(string orgIDs)
        {
            return new OrganizationDAL().GeStaffOrganizationBy(orgIDs);
        }

    }
}
