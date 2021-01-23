using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Billing;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HardwareStore.Modules.Billing
{
    public partial class Sales : PageBase
    {
        [Inject]
        public ISalesServices _SalesServices { get; set; }
        [Inject]
        public ICommonServices _CommonService { get; set; }
        public List<TempSaleList> TempList { get; set; }
        public string UserName;
        public string TempListKey = "SalesDetailsList";
        public string UserKey = "Current_Username";

        //public void PageConfiguration()
        //{
        //    GridView grid = new GridView();
        //    grid = this.GridViewProductStocks;
        //    DataGridViewColumn column = grid.Columns[2];
        //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        //}

        public void LoadGridViewProductStocks(DateTime? Start, DateTime? End, string search = "")
        {
            List<ProductStocksDto> list = new List<ProductStocksDto>();
            if (Start != null && End != null)
            {
                list = this._SalesServices.ListProductStocks(search, true, (DateTime)Start, (DateTime)End);
                this.GridViewProductStocks.DataSource = list;
                this.GridViewProductStocks.DataBind();
            }
            else
            {
                DateTime StartDate = Convert.ToDateTime("1998-10-01");
                DateTime EndDate = DateTime.Now.AddDays(1);
                list = this._SalesServices.ListProductStocks(search, true, StartDate, EndDate);
                this.GridViewProductStocks.DataSource = list;
                this.GridViewProductStocks.DataBind();
            }
        }

        public void LoadGridViewStocksDetails(string LotNumber, string search = "", int? warehouseid = 0)
        {
            List<StocksDetailsDto> list = new List<StocksDetailsDto>();
            list = this._SalesServices.ListStocksDetails(LotNumber, search, (int)warehouseid);
            this.GridViewStocksDetails.DataSource = list;
            this.GridViewStocksDetails.DataBind();
        }

        public void LoadDropdownlistWarehouses()
        {
            List<WarehousesDropDto> list = new List<WarehousesDropDto>();
            list = this._SalesServices.ListWarehousesForDropDowns();
            this.DropDownListWarehousesFilter.DataSource = list;
            this.DropDownListWarehousesFilter.DataTextField = "Name";
            this.DropDownListWarehousesFilter.DataValueField = "Id";
            this.DropDownListWarehousesFilter.DataBind();

            this.DropDownListWarehousesFilter.Items.Insert(0, new ListItem("Seleccione una bodega", "0"));
        }

        public void LoadDropDownListMeasureUnits(int TypeId)
        {
            List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();

            list = this._SalesServices.ListMeasureUnitForDropdownsByType(TypeId);
            this.ddlistMeasureUnits.DataSource = list;
            this.ddlistMeasureUnits.DataTextField = "Name";
            this.ddlistMeasureUnits.DataValueField = "Id";
            this.ddlistMeasureUnits.DataBind();

            this.ddlistMeasureUnits.Items.Insert(0, new ListItem("Selecciona la Unidad de medida", "0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGridViewProductStocks(null, null);
                this.LoadDropdownlistWarehouses();
            }

            Session[UserKey] = "01dlopezs98@gmail.com";
        }

        protected void btnSearchProductStocks_Click(object sender, EventArgs e)
        {
            string search = txtSearchProductStocks.Text;
            DateTime Start = Convert.ToDateTime(PickerStartDateProductStocks.Text);
            DateTime End = Convert.ToDateTime(PickerEndDateProductStocks.Text);

            this.LoadGridViewProductStocks(Start, End, search);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModal, true);
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

        protected void DropDownListWarehousesFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lotnumber = txtLotNumberForStockDetails.Text;
            int warehouseid = Convert.ToInt32(DropDownListWarehousesFilter.SelectedValue);
            this.LoadGridViewStocksDetails(lotnumber, warehouseid: warehouseid);
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
                    this.SendProductStocksDetailToTextbox(stockscode);
                    break;

                default:
                    break;
            }
        }

        private void SendProductStocksDetailToTextbox(string Code)
        {
            StocksDetailsDto dto = this._SalesServices.GetAStocksDetail(Code);
            this.LoadDropDownListMeasureUnits(dto.UnitTypeId);
            //Hidden Fields
            txtMeasureUnitBaseId.Text = dto.UnitBaseId.ToString();
            txtMeasureUnitPurchasedId.Text = dto.PurchaseUnitId.ToString();
            txtMeasureUnitTypeId.Text = dto.UnitTypeId.ToString();
            txtWarehouseId.Text = dto.WarehouseName;

            //Other Fields
            txtProductName.Text = dto.ProductName;
            txtProductDetailCode.Text = dto.ProductDetailCode;
            txtExpiryDate.Text = dto.ExpirationDate;
            txtWarehouseName.Text = dto.WarehouseName;
            txtBrandName.Text = dto.BrandName;
            txtCategoryName.Text = dto.CategoryName;
            txtMaterialName.Text = dto.MaterialName;
            txtDimensions.Text = dto.Dimensions;
            txtInitialsStocks.Text = dto.StocksQuantity.ToString();
            SpanForInitialsStocks.InnerText = dto.PurchaseUnitName;
            txtCurrentStocks.Text = dto.ConversionValue.ToString();
            SpanForCurrentStocks.InnerText = dto.UnitBaseName;
            txtSalePrice.Text = dto.SalePrice.ToString();
        }

        protected void btnAddToSaleDetailsList_Click(object sender, EventArgs e)
        {
            string Option = btnAddToSaleDetailsList.Text;
            string ShowToaster;
            switch (Option)
            {
                case "Agregar":
                    ShowToaster = "";
                    this.AddItemToTempList();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true);
                    break;

                case "Editar":
                    this.EditItemFromTempList();
                    break;

                default:
                    break;
            }
        }

        private void EditItemFromTempList()
        {
            throw new NotImplementedException();
        }

        private void AddItemToTempList()
        {
            bool AlreadyExist;
            string ShowToaster;
            TempSaleList Temp = this.CreateObjectForTempList();
            int idconvertfrom = Convert.ToInt32(ddlistMeasureUnits.SelectedValue);
            int idconvertto = Convert.ToInt32(txtMeasureUnitBaseId.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            double value = this._CommonService.GetConversionValue(idconvertfrom, idconvertto, quantity);
            double stocks = Convert.ToDouble(txtCurrentStocks.Text);
            double newstocks;
            if(value > stocks)
            {
                //no add
            }
            else
            {
                if(Session[TempListKey] == null)
                {
                    TempList = new List<TempSaleList>();
                    TempList.Add(Temp); Session[TempListKey] = TempList;
                    this.ResetInputsForSalesDetail();
                }
                else
                {
                    TempList = Session[TempListKey] as List<TempSaleList>;
                    AlreadyExist = TempList.Exists(x => x.s);
                }
            }

        }

        private TempSaleList CreateObjectForTempList()
        {
            throw new NotImplementedException();
        }

        private void ResetInputsForSalesDetail()
        {
            throw new NotImplementedException();
        }

        protected void btnCancelOrClearDetailForm_Click(object sender, EventArgs e)
        {

        }
    }
}