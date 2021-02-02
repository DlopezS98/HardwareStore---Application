using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HardwareStore.Modules.ProductsAdmin
{
    public partial class RemovedProducts : PageBase
    {
        [Inject]
        public IProductsAdminService ProductAdminService { get; set; }

        public void LoadGridViewProductStocks(DateTime? Start, DateTime? End, string search = "")
        {
            List<RemovedProductsDto> list = new List<RemovedProductsDto>();
            if (Start != null && End != null)
            {
                list = this.ProductAdminService.GetRemovedProducts((DateTime)Start, (DateTime)End, search);
                this.GridViewRemovedProducts.DataSource = list;
                this.GridViewRemovedProducts.DataBind();
            }
            else
            {
                DateTime StartDate = Convert.ToDateTime("1998-10-01");
                DateTime EndDate = DateTime.Now.AddDays(1);
                list = this.ProductAdminService.GetRemovedProducts(StartDate, EndDate, search);
                this.GridViewRemovedProducts.DataSource = list;
                this.GridViewRemovedProducts.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGridViewProductStocks(null, null);
            }
        }

        protected void GridViewRemovedProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnSearchRemovedProducts_Click(object sender, EventArgs e)
        {
            string search = txtSearchRemovedProducts.Text;
            string ShowToaster = "ShowToaster('!La fecha inicio no debe <br/> ser mayor a la fecha final!', 'danger')";
            string StartDateString = PickerStartDateRemovedProducts.Text;
            string EndDateString = PickerEndDateRemovedProducts.Text;
            if (StartDateString != "" && EndDateString != "")
            {
                DateTime Start = Convert.ToDateTime(StartDateString);
                DateTime End = Convert.ToDateTime(EndDateString);

                if (Start >= End) { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true); } else { this.LoadGridViewProductStocks(Start, End, search); }
            }
            else { this.LoadGridViewProductStocks(null, null, search); }
        }
    }
}