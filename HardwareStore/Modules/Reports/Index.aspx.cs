using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Reports;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.ComponentModel;
using HardwareStore.Core.Interfaces.Catalogs;

namespace HardwareStore.Modules.Reports
{
    public partial class Index : PageBase
    {
        [Inject]
        public IReportsService ReportService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadProductReport();
            }
        }

        private void LoadProductReport()
        {
            DataTable dt = new DataTable();
            dt = this.ReportService.GetProductDetailsFromDatabase(false, "");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource Rdlc = new ReportDataSource("DataSetProductReport", dt);
            ReportViewer1.LocalReport.DataSources.Add(Rdlc);
            ReportViewer1.LocalReport.Refresh();
            //MultiviewReports.ActiveViewIndex = 1;
        }
    }
}