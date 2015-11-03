using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Reports.Entity
{
    /// <summary>
    ///  登录中心信息
    /// </summary>
    public class center
    {
        public int id { get; set; }
        public int parent_code { get; set; }
        public string name { get; set; }
        public string login_name { get; set; }
        public string password { get; set; }
        public string remark { get; set; }
    }
}
