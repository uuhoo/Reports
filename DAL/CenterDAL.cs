using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using LJ.Reports.Entity;

namespace LJ.Reports.DAL
{
    public class CenterDAL
    {
        /// <summary>
        /// 获取所有中心
        /// </summary>
        /// <returns></returns>
        public List<center> GetAllCounts()
        {
            using (IDbConnection conn = DapperHelper.getDBConnection())
            {
                var sql = @"SELECT * FROM center";
                return conn.Query<center>(sql).ToList();
            }
        }
    }
}
