using HardwareStore.Core.DTOs.Catalogs;
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

namespace HardwareStore.Modules.Reports
{
    public partial class Index : PageBase
    {
        [Inject]
        public IReportsService ReportService { get; set; }
        [Inject]
        public ICommonServices CommonService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadProductReport()
        {
            //DataTable dt = new DataTable();
            //List<ProductDetailsDto> list = new List<ProductDetailsDto>();
            //list = this.ReportService.ListAllProductDetails();
            //dt = this.CommonService.ToDataTable(list);
            //reportviewer1.datasourcer = dt;
        }
    }
}