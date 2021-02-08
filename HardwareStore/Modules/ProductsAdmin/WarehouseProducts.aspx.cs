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
using System.Web.Script.Serialization;
using HardwareStore.Core.Interfaces;
using HardwareStore.Core.DTOs;

namespace HardwareStore.Modules.ProductsAdmin
{
    public partial class WarehouseProducts : PageBase
    {
        [Inject]
        public IProductsAdminService _ProductAdminService { get; set; }
        [Inject]
        public ICommonServices CommonService { get; set; }
        private string UserName;
        private string UserKey = "Current_Username";
        private List<StocksDetailsDto> TempList { get; set; }
        private string TempListKey = "StocksPendingToTransfer";

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

            this.DropDownListTargetWarehouse.DataSource = list;
            this.DropDownListTargetWarehouse.DataTextField = "Name";
            this.DropDownListTargetWarehouse.DataValueField = "Id";
            this.DropDownListTargetWarehouse.DataBind();

            this.DropDownListTargetWarehouse.Items.Insert(0, new ListItem("Seleccione una bodega", "0"));
        }

        public void LoadDropDownListMeasureUnits(int? TypeId = null)
        {
            List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();
            if (TypeId != null)
                list = this._ProductAdminService.ListMeasureUnitForDropdownsByType((int)TypeId);

            this.DropDownListUnitsMeasure.DataSource = list;
            this.DropDownListUnitsMeasure.DataTextField = "Name";
            this.DropDownListUnitsMeasure.DataValueField = "Id";
            this.DropDownListUnitsMeasure.DataBind();

            this.DropDownListUnitsMeasure.Items.Insert(0, new ListItem("Selecciona la Unidad de medida", "0"));
        }

        public void LoadDropDownListMeasureUnitsToTransfer(int? TypeId = null)
        {
            List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();
            if (TypeId != null)
                list = this._ProductAdminService.ListMeasureUnitForDropdownsByType((int)TypeId);

            this.DropDownListMeasureUnitsToTransfer.DataSource = list;
            this.DropDownListMeasureUnitsToTransfer.DataTextField = "Name";
            this.DropDownListMeasureUnitsToTransfer.DataValueField = "Id";
            this.DropDownListMeasureUnitsToTransfer.DataBind();

            this.DropDownListMeasureUnitsToTransfer.Items.Insert(0, new ListItem("Selecciona la Unidad de medida", "0"));
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
            string ShowModal;
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int index = Row.RowIndex;
            string lotnumber = Convert.ToString(GridViewStocksDetails.DataKeys[index]["LotNumber"]);
            string stockscode = Convert.ToString(GridViewStocksDetails.DataKeys[index]["StocksCode"]);
            string showAlert;
            switch (e.CommandName)
            {
                case "cmdTransfer":
                    this.LoadDropdownlistWarehouses();
                    txtStockCodeTransfer.Text = stockscode;
                    var data = this._ProductAdminService.GetAStocksDetail(stockscode);
                    int UnitTypeId = data.UnitTypeId;
                    txtProductNameTransfer.Text = data.ProductName;
                    txtProductDetailCodeTransfer.Text = data.ProductDetailCode;
                    this.LoadDropDownListMeasureUnitsToTransfer(UnitTypeId);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ShowLoader(false); $('#TransferModal').modal('show');", true);
                    break;

                case "cmdDelete":
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script0", "ShowLoader(true)", true);
                    StocksDetailsDto dto = this.getProductStockAndSendToModal(stockscode);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonData = js.Serialize(dto);
                    ShowModal = string.Format("ShowModalDeleteProduct('{0}')", jsonData);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModal, true);
                    break;

                default:
                    break;
            }
        }

        private PendingTranfersModelDto CreateObjectToSendProductToTransferList(string StocksCode)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script001", "ShowLoader(true);", true);
            string ShowToaster;
            string username = Session[UserKey] as string;
            StocksDetailsDto stocks = this._ProductAdminService.GetAStocksDetail(StocksCode);
            PendingTranfersModelDto dto = new PendingTranfersModelDto();
            int targetUnitId = Convert.ToInt32(DropDownListMeasureUnitsToTransfer.SelectedValue);
            int quantity = Convert.ToInt32(txtUnitQuantityToTransfer.Text);
            int targetWarehouseId = Convert.ToInt32(DropDownListTargetWarehouse.SelectedValue);
            double value = this.CommonService.GetConversionValue(targetUnitId, stocks.UnitBaseId, quantity).Value;

            if (value > stocks.ConversionValue)
            {
                ShowToaster = "ShowLoader(false); ShowToaster('Cantidad no disponible <br/>en las existencias!', 'danger')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true);
                return null;
            }
            else
            {
                if (targetWarehouseId != stocks.WarehouseId)
                {
                    dto.ProductStocksId = stocks.ProductStocksId;
                    dto.LotNumber = stocks.LotNumber;
                    dto.StocksCode = stocks.StocksCode;
                    dto.ProductDetailCode = stocks.ProductDetailCode;
                    dto.WarehouseId = stocks.WarehouseId;
                    dto.TargetWarehouseId = targetWarehouseId;
                    dto.TargetUnitId = targetUnitId;
                    dto.UnitTypeId = stocks.UnitTypeId;
                    dto.PurchasedUnitId = stocks.PurchaseUnitId;
                    dto.UnitQuantity = quantity;
                    dto.UserName = username;

                    return dto;
                }
                else
                {
                    ShowToaster = "ShowLoader(false); ShowToaster('La bodega destino no debe ser <br/> la misma de origen!', 'danger')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true);
                    return null;
                }
            }
        }

        public StocksDetailsDto getProductStockAndSendToModal(string Code)
        {
            StocksDetailsDto dto = new StocksDetailsDto();
            dto = this._ProductAdminService.GetAStocksDetail(Code);
            this.LoadDropDownListMeasureUnits(dto.UnitTypeId);
            txtStocksQuantity.Text = dto.StocksQuantity.ToString();
            txtMeasureUnitBaseId.Text = dto.UnitBaseId.ToString();
            txtMeasureUnitPurchasedId.Text = dto.PurchaseUnitId.ToString();
            txtMeasureUnitTypeId.Text = dto.UnitTypeId.ToString();
            txtProductStockId.Text = dto.ProductStocksId.ToString();
            txtStocksDetailCode.Text = dto.StocksCode;
            txtLotNumber.Text = dto.LotNumber;
            txtCurrentStocks.Text = dto.ConversionValue.ToString();
            return dto;
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

        protected void btnDeleteProductFromStocks_Click(object sender, EventArgs e)
        {
            string showAlert, ShowToaster;
            this.UserName = Session[UserKey] as string;
            int UnitQuantity = Convert.ToInt32(txtDeleteQuantity.Text);
            int UnitBaseId = Convert.ToInt32(txtMeasureUnitBaseId.Text);
            int MeasureUnitId = Convert.ToInt32(DropDownListUnitsMeasure.SelectedValue);
            double value = this.CommonService.GetConversionValue(MeasureUnitId, UnitBaseId, UnitQuantity).Value;
            double stocks = Convert.ToDouble(txtCurrentStocks.Text);
            if (value > stocks)
            {
                ShowToaster = "ShowLoader(false); ShowToaster('Cantidad no disponible <br/>en las existencias!', 'warning');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script0", ShowToaster, true);
            }
            else
            {
                DeleteProductDto rmp = new DeleteProductDto()
                {
                    Title = txtDeleteTitle.Text,
                    Description = txtDeleteDescription.Text,
                    ProductStockId = Convert.ToInt32(txtProductStockId.Text),
                    LotNumber = txtLotNumber.Text,
                    StockDetailCode = txtStocksDetailCode.Text,
                    MeasureUnitId = MeasureUnitId,
                    UnitQuantity = UnitQuantity,
                    UnitBaseId = UnitBaseId,
                    ConversionQuantity = this.CommonService.GetConversionValue(MeasureUnitId, UnitBaseId, UnitQuantity).Value,
                    PurchasedUnitId = Convert.ToInt32(txtMeasureUnitPurchasedId.Text),
                    User = this.UserName,
                    CreatedAt = DateTime.Now
                };

                this.ResetInputsForDeleteProductForm();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script1", "$('#ModalDeleteProduct').modal('hide')", true);

                Response res = new Response();
                res = this._ProductAdminService.DeleteProductFromStocks(rmp);
                if (res.Success) { showAlert = string.Format("ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
                else { showAlert = string.Format("ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
                this.LoadGridViewStocksDetails(rmp.LotNumber);
                this.LoadGridViewProductStocks(null, null);
            }
        }

        private void ResetInputsForDeleteProductForm()
        {
            txtDeleteTitle.Text = "";
            txtDeleteQuantity.Text = "";
            txtDeleteDescription.Text = "";
            txtStocksQuantity.Text = "";
            txtMeasureUnitBaseId.Text = "";
            txtMeasureUnitPurchasedId.Text = "";
            txtMeasureUnitTypeId.Text = "";
            txtProductStockId.Text = "";
            txtLotNumber.Text = "";
            txtStocksDetailCode.Text = "";
        }

        protected void btnConfirmProductTrasnfer_Click(object sender, EventArgs e)
        {
            string showAlert, stockscode;
            stockscode = txtStockCodeTransfer.Text;

            PendingTranfersModelDto tranfer = this.CreateObjectToSendProductToTransferList(stockscode);
            if (tranfer != null)
            {
                Response res = this._ProductAdminService.CreatePendingTransfer(tranfer);
                if (res.Success) { showAlert = string.Format("ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
                else { showAlert = string.Format("ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script01", "ShowLoader(false); $('#TransferModal').modal('hide');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
            }
        }
    }
}