using HardwareStore.Core.DTOs.Catalogs;
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
    public partial class WarehouseProducts : PageBase
    {
        [Inject]
        public IProductsAdminService _ProductAdminService { get; set; }

        public void LoadGridViewProductStocks(DateTime? Start, DateTime? End, string search = "")
        {
            List<ProductStocksDto> list = new List<ProductStocksDto>();
            if (Start != null && End != null)
            {
                list = this._ProductAdminService.ListProductStocks(search, true, (DateTime)Start, (DateTime)End);
                this.GridViewProductStocks.DataSource = list;
                this.GridViewProductStocks.DataBind();
            }
            else
            {
                DateTime StartDate = Convert.ToDateTime("1998-10-01");
                DateTime EndDate = DateTime.Now.AddDays(1);
                list = this._ProductAdminService.ListProductStocks(search, true, StartDate, EndDate);
                this.GridViewProductStocks.DataSource = list;
                this.GridViewProductStocks.DataBind();
            }
        }

        public void LoadGridViewStocksDetails(string LotNumber, string search = "", int? warehouseid = 0)
        {
            List<StocksDetailsDto> list = new List<StocksDetailsDto>();
            list = this._ProductAdminService.ListStocksDetails(LotNumber, search, (int)warehouseid);
            this.GridViewStocksDetails.DataSource = list;
            this.GridViewStocksDetails.DataBind();
        }

        public void LoadDropdownlistWarehouses()
        {
            List<WarehousesDropDto> list = new List<WarehousesDropDto>();
            list = this._ProductAdminService.ListWarehousesForDropDowns();
            this.DropDownListWarehousesFilter.DataSource = list;
            this.DropDownListWarehousesFilter.DataTextField = "Name";
            this.DropDownListWarehousesFilter.DataValueField = "Id";
            this.DropDownListWarehousesFilter.DataBind();

            this.DropDownListWarehousesFilter.Items.Insert(0, new ListItem("Seleccione una bodega", "0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGridViewProductStocks(null, null);
                this.LoadDropdownlistWarehouses();
            }
        }

        protected void btnSearchProductStocks_Click(object sender, EventArgs e)
        {
            string search = txtSearchProductStocks.Text;
            string ShowToaster = "ShowToaster('!La fecha inicio no debe <br/> ser mayor a la fecha final!', 'danger')";
            string StartDateString = PickerStartDateProductStocks.Text;
            string EndDateString = PickerEndDateProductStocks.Text;
            if (StartDateString != "" && EndDateString != "")
            {
                DateTime Start = Convert.ToDateTime(StartDateString);
                DateTime End = Convert.ToDateTime(EndDateString);
                
                if (Start >= End) { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true); } else { this.LoadGridViewProductStocks(Start, End, search); }
            }
            else { this.LoadGridViewProductStocks(null, null, search); }
        }

        protected void DropDownListWarehousesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lotnumber = txtLotNumberForStockDetails.Text;
            int warehouseid = Convert.ToInt32(DropDownListWarehousesFilter.SelectedValue);
            this.LoadGridViewStocksDetails(lotnumber, warehouseid: warehouseid);
        }

        protected void GridViewProductStocks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int index = Row.RowIndex;
            string lotnumber = Convert.ToString(GridViewProductStocks.DataKeys[index]["LotNumber"]);
            string ShowModal = string.Format("ShowModalStocksDetails('{0}')", lotnumber);
            switch (e.CommandName)
            {
                case "cmdShowStocksDetail":
                    txtLotNumberForStockDetails.Text = lotnumber;
                    this.LoadGridViewStocksDetails(lotnumber);
                    MultiViewProductStocks.ActiveViewIndex = 1;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModal, true);
                    break;

                default:
                    break;
            }
        }

        protected void btnSearchStocksDetails_Click(object sender, EventArgs e)
        {
            string lotnumber = txtLotNumberForStockDetails.Text;
            string search = txtSearchStocksDetails.Text;
            int warehouseid = Convert.ToInt32(DropDownListWarehousesFilter.SelectedValue);

            this.LoadGridViewStocksDetails(lotnumber, search, warehouseid);
        }

        protected void GridViewStocksDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int index = Row.RowIndex;
            string lotnumber = Convert.ToString(GridViewStocksDetails.DataKeys[index]["LotNumber"]);
            string stockscode = Convert.ToString(GridViewStocksDetails.DataKeys[index]["StocksCode"]);
            switch (e.CommandName)
            {
                case "cmdSelect":
                    //this.SendProductStocksDetailToTextbox(stockscode);
                    break;

                default:
                    break;
            }
        }

        protected void btnMove_Click(object sender, EventArgs e)
        {
            string ShowToaster = "launch_toast()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true);
        }

        protected void btnGoBackToMainView_Click(object sender, EventArgs e)
        {
            this.MultiViewProductStocks.ActiveViewIndex = 0;
        }
    }
}