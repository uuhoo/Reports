using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LJ.Reports.Entity;
using System.Data;

namespace LJ.Reports.DAL
{
    /// <summary>
    /// 机构数据
    /// </summary>
    public class OrganizationDAL
    {
        /// <summary>
        /// 服务机构
        /// </summary>
        /// <param name="orgList"></param>
        /// <returns></returns>
        public List<organization> GeOrganizationBy(string[] orgIDs)
        {
            using (IDbConnection conn = DapperHelper.getDBConnection())
            {
                var sql = @"SELECT id,name FROM organization where id IN @ids";
                var sss = conn.Query<organization>(sql, new { ids = orgIDs }).ToList();
                return sss;
            }
        }

        /// <summary>
        /// 推广机构
        /// </summary>
        /// <param name="orgList"></param>
        /// <returns></returns>
        public List<organization> GeStaffOrganizationBy(string[] orgIDs)
        {
            using (IDbConnection conn = DapperHelper.getDBConnection())
            {
                var sql = @"SELECT id,name FROM staff_organization where id IN @ids ";
                return conn.Query<organization>(sql, new { ids = orgIDs }).ToList();
            }
        }
    }
}
