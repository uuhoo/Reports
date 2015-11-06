using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Reports.DAL
{
    /// <summary>
    /// DapperHelper 连接工厂类
    /// </summary>
    public class DapperHelper
    {

        //获取字符串配置节点
        public static readonly ConnectionStringSettings connSettings = ConfigurationManager.ConnectionStrings["DBContext"];
        public static IDbConnection getDBConnection()
        {
            IDbConnection conn = DbProviderFactories.GetFactory(connSettings.ProviderName).CreateConnection();
            try
            {
                conn.ConnectionString = connSettings.ConnectionString;
                conn.Open(); //打开数据库
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conn;
        }

    }
}
