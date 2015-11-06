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
    ///  权限业务
    /// </summary>
   public class PermissionBLL
    {
       PermissionDAL _dal = new PermissionDAL();

       public List<permission> getPermissionBy(int centerID, int pageIndex, int pageSize, out int counts)
       {
           return _dal.getPermissionBy(centerID, pageIndex, pageSize, out counts);
       }



    }
}
