using LJ.Reports.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Reports.BLL
{
    public  class PromotionOrganizationBLL
    {
        PromotionOrganizationDAL SDAL = new PromotionOrganizationDAL();
        public DataTable PromotionOrganizationData(DateTime beginTime, DateTime endTime, List<string> OrganizationIDList)
        {
            List<string> dd = new List<string>();
            return SDAL.getPromotionOrganizationData(beginTime, endTime, OrganizationIDList);
        }
    }
}
