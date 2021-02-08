using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static HardwareStore.Core.Entities.Enums;

namespace HardwareStore.Modules.ProductsAdmin
{
    public partial class TranfersAdministration : PageBase
    {
        [Inject]
        public IProductsAdminService _ProductAdminService { get; set; }
        [Inject]
        public ICommonServices CommonService { get; set; }
        public string UserName;
        public string UserKey = "Current_Username";

        public void LoadGridviewPendingTransfer(string Search = "")
        {
            List<PendingTranfersDto> list = new List<PendingTranfersDto>();
            list = this._ProductAdminService.GetPendingTransferProducts(Search, TransferStatus.Pending);
            this.GridViewPendingTransfer.DataSource = list;
            this.GridViewPendingTransfer.DataBind();
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

        public void LoadDropdownlistWarehouses()
        {
            List<WarehousesDropDto> list = new List<WarehousesDropDto>();
            list = this._ProductAdminService.ListWarehousesForDropDowns();

            this.DropDownListTargetWarehouse.DataSource = list;
            this.DropDownListTargetWarehouse.DataTextField = "Name";
            this.DropDownListTargetWarehouse.DataValueField = "Id";
            this.DropDownListTargetWarehouse.DataBind();

            this.DropDownListTargetWarehouse.Items.Insert(0, new ListItem("Seleccione una bodega", "0"));
        }

        public void LoadGridViewProductsTransfer(DateTime? Start, DateTime? End, string search = "")
        {
            List<TransfersDto> list = new List<TransfersDto>();
            if (Start != null && End != null)
            {
                list = this._ProductAdminService.ListProductTransfer(search, (DateTime)Start, (DateTime)End);
                this.GridViewProductsTransfers.DataSource = list;
                this.GridViewProductsTransfers.DataBind();
            }
            else
            {
                DateTime StartDate = Convert.ToDateTime("1998-10-01");
                DateTime EndDate = DateTime.Now.AddDays(1);
                list = this._ProductAdminService.ListProductTransfer(search, StartDate, EndDate);
                this.GridViewProductsTransfers.DataSource = list;
                this.GridViewProductsTransfers.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadGridviewPendingTransfer("");
                this.LoadGridViewProductsTransfer(null, null);
            }

            Session[UserKey] = "01dlopezs98@gmail.com";
        }

        protected void btnPendingTransferFilter_Click(object sender, EventArgs e)
        {
            string search = txtSearchTransferProductPending.Text;
            this.LoadGridviewPendingTransfer(search);
        }

        protected void GridViewPendingTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int Index = Row.RowIndex;
            string Code = Convert.ToString(GridViewPendingTransfer.DataKeys[Index]["Code"]);
            string StocksCode = Convert.ToString(GridViewPendingTransfer.DataKeys[Index]["StocksCode"]);
            string ProductDetailCode = Convert.ToString(GridViewPendingTransfer.DataKeys[Index]["ProductDetailCode"]);
            string showmodal = string.Format("ShowAlertInfo('Estás seguro de eliminar el producto de la lista?')");
            switch (e.CommandName)
            {
                case "cmdEdit":
                    this.LoadDropdownlistWarehouses();
                    txtStockCodeTransfer.Text = StocksCode;
                    var data = this._ProductAdminService.GetAStocksDetail(StocksCode);
                    int UnitTypeId = data.UnitTypeId;
                    txtProductNameTransfer.Text = data.ProductName;
                    txtProductDetailCodeTransfer.Text = data.ProductDetailCode;
                    txtEditPendingTransferCode.Text = Code;
                    var pending = this._ProductAdminService.GetPendingTransferProduct(Code);
                    int targetwarehouse = pending.TargetWarehouseId;
                    int measureunitid = pending.TargetUnitId;
                    txtEditWarehouseId.Text = targetwarehouse.ToString();
                    txtUnitQuantityToTransfer.Text = pending.UnitQuantity.ToString();
                    this.LoadDropDownListMeasureUnitsToTransfer(UnitTypeId);
                    DropDownListTargetWarehouse.SelectedValue = targetwarehouse.ToString();
                    DropDownListMeasureUnitsToTransfer.SelectedValue = measureunitid.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "ShowLoader(false); $('#TransferModal').modal('show');", true);
                    break;
                case "cmdDelete":
                    txtPendingTransferCode.Text = Code;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showmodal, true);
                    break;
                default:
                    break;
            }
        }

        protected void btnConfirmDeleteProduct_Click(object sender, EventArgs e)
        {
            string showAlert;
            string Code = txtPendingTransferCode.Text;
            this.UserName = Session[UserKey] as string;
            Response res = this._ProductAdminService.DeleteProductFromTransferList(Code, this.UserName);
            if (res.Success) { showAlert = string.Format("$('#ConfirmDeletions').modal('hide'); ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
            else { showAlert = string.Format("$('#ConfirmDeletions').modal('hide'); ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
            this.LoadGridviewPendingTransfer();
        }

        private PendingTranfersModelDto CreateObjectToSendProductToTransferList(string StocksCode)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script1", "ShowLoader(true);", true);
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
                    dto.Code = txtEditPendingTransferCode.Text;
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

        protected void btnConfirmUpdateProductTrasnfer_Click(object sender, EventArgs e)
        {
            string showAlert, stockscode, Code;
            stockscode = txtStockCodeTransfer.Text;
            Code = txtEditPendingTransferCode.Text;
            //int warehouseid = Convert.ToInt32(txtEditWarehouseId.Text);
            PendingTranfersModelDto tranfer = this.CreateObjectToSendProductToTransferList(stockscode);
            if (tranfer != null)
            {
                Response res = this._ProductAdminService.UpdatePendingTranfer(Code, tranfer);
                if (res.Success) { showAlert = string.Format("ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
                else { showAlert = string.Format("ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script01", "ShowLoader(false); $('#TransferModal').modal('hide');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
                this.LoadGridviewPendingTransfer();
            }
        }

        protected void SendAllProductsToGenerateTransfer_Click(object sender, EventArgs e)
        {
            string showAlert;
            this.UserName = Session[UserKey] as string;
            var list = this._ProductAdminService.GetPendingTransferProducts("", TransferStatus.Pending);
            Response res = this._ProductAdminService.GenerateTransferTransaction(list, this.UserName);
            if (res.Success) { showAlert = string.Format("ShowLoader(false); ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
            else { showAlert = string.Format("ShowLoader(false); ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script01", "ShowLoader(false); $('#TransferModal').modal('hide');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
            this.LoadGridviewPendingTransfer();
            this.LoadGridViewProductsTransfer(null, null);
        }

        protected void btnSearchTransferDetailsFilter_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductTransferId.Text);
            string search = txtSearchTransferDetails.Text;
            this.loadGridViewTransferDetails(id, search);
        }

        protected void GridViewProductsTransfers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int index = Row.RowIndex;
            int Id = Convert.ToInt32(GridViewProductsTransfers.DataKeys[index]["Id"]);
            string Code = Convert.ToString(GridViewProductsTransfers.DataKeys[index]["Code"]);
            string ShowModal = string.Format("ShowModalTransferDetails('{0}')", Code);
            switch (e.CommandName)
            {
                case "cmdDetails":
                    this.loadGridViewTransferDetails(Id, "");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModal, true);
                    txtProductTransferId.Text = Id.ToString();
                    break;

                default:
                    break;
            }
        }

        private void loadGridViewTransferDetails(int id, string search)
        {
            List<TransferDetailsDto> list = new List<TransferDetailsDto>();
            list = this._ProductAdminService.ListTransfersDetails(id, search);
            this.GridViewTransferDetails.DataSource = list;
            this.GridViewTransferDetails.DataBind();
        }

        protected void btnTransfersFilter_Click(object sender, EventArgs e)
        {
            
                string search, ShowToaster, StartDateString, EndDateString;

            search = txtSearchProductTransfers.Text;
            ShowToaster = "ShowToaster('!La fecha inicio no debe <br/> ser mayor a la fecha final!', 'danger')";
            StartDateString = TransfersDatePickerStartDate.Text;
            EndDateString = TransfersDatePickerEndDate.Text;
            if (StartDateString != "" && EndDateString != "")
            {
                DateTime Start = Convert.ToDateTime(StartDateString);
                DateTime End = Convert.ToDateTime(EndDateString);
                if (Start >= End) { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true); } else { this.LoadGridViewProductsTransfer(Start, End, search); }
            }
            else
            {
                this.LoadGridViewProductsTransfer(null, null, search);
            }
        }
    }
}