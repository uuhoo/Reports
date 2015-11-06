using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using LJ.Reports.DAL;

namespace LJ.Reports.BLL
{
    public class ServerOrganizationBLL
    {
        ServerOrganizationDAL SDAL = new ServerOrganizationDAL();
        public DataTable ServerOrganizationData(DateTime beginTime, DateTime endTime, List<string> OrganizationIDList)
        {
            List<string> dd = new List<string>();
            return SDAL.getServerOrganizationData(  beginTime,   endTime,  OrganizationIDList);
        }
    }
}
