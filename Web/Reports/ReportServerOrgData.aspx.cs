using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LJ.Reports.BLL;
using LJ.Reports.Utility;
using LJ.Reports.Entity;


namespace LJ.Reports.Web.Reports
{
    public partial class ReportServerOrgData : System.Web.UI.Page
    {
        private string reportname = "";
        private int org_sign = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            reportname = Request.QueryString["ReportName"].ToString();
            org_sign = int.Parse(Request.QueryString["org_sign"]);
            if (IsPostBack != true)
            {
                InitPage();
                BindReportDataSource();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindReportDataSource();
        }

        private void InitPage()
        {
             this.StartDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01 00:00:00");
             this.EndDate.Text = Convert .ToDateTime( DateTime.Now.ToString("yyyy-MM-01 00:00:00")).AddSeconds(-1).ToString("yyyy-MM-dd 23:59:59");
             this.HiddenOrgSign.Value = org_sign.ToString();
             this.HiddenSelectedOrgIDs.Value = "-1";
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        public void BindReportDataSource()
        {
            List<string> OrganizationList = new List<string>();
            string strOrgIDs = this.HiddenSelectedOrgIDs.Value;
            if (!strOrgIDs.Equals("-1"))
            {
                if (strOrgIDs.Contains(','))
                {
                    OrganizationList = strOrgIDs.Split(',').ToList();
                }
                else
                {
                    OrganizationList.Add(strOrgIDs);
                }
            }

            DateTime start = Convert.ToDateTime(this.StartDate.Text);
            DateTime end = Convert.ToDateTime(this.EndDate.Text);

            this.ReportViewer1.LocalReport.DataSources.Clear();
            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/Reports/" + reportname);
            string ststr = start.ToString();
            string edstr = end.ToString();
            Microsoft.Reporting.WebForms.ReportParameter st = new Microsoft.Reporting.WebForms.ReportParameter("StartTime", ststr);
            Microsoft.Reporting.WebForms.ReportParameter ed = new Microsoft.Reporting.WebForms.ReportParameter("EndTime", edstr);
            this.ReportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter[] { st, ed });
            switch (reportname)
            {
                case "ReportPromotionOrganization.rdlc":
                    DataTable dt1 = new PromotionOrganizationBLL().PromotionOrganizationData(start, end, OrganizationList);
                    this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt1));
                    this.ReportViewer1.LocalReport.Refresh();
                    break;
                case "ReportServerOrganization.rdlc":
                    DataTable dt2 = new ServerOrganizationBLL().ServerOrganizationData(start, end, OrganizationList);
                    this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt2));
                    this.ReportViewer1.LocalReport.Refresh();
                    break;
                default:
                    break;
            }

        }
    }
}