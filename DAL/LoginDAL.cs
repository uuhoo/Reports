using LJ.Reports.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace LJ.Reports.DAL
{

    /// <summary>
    ///  登录数据交互
    /// </summary>
    public class LoginDAL
    {
        /// <summary>
        ///  用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public center Login(string username, string password)
        {
            using (IDbConnection conn = DapperHelper.getDBConnection())
            {
                var sql = @"SELECT * FROM center WHERE login_name=@uname AND pwd=@pwd ";
                return conn.Query<center>(sql, new { uname = username, pwd = password }).SingleOrDefault();
            }
        }
    }
}
