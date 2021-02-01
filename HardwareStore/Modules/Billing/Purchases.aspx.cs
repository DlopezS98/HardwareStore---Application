using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Billing;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HardwareStore.Modules.Billing
{
    public partial class Purchases : PageBase
    {
        [Inject]
        public IPurchasesService _PurchaseService { get; set; }
        public ICommonServices _CommonServices { get; set; }
        public List<TempPurchaseList> TempList = null;
        public string UserName;
        private string TempListKey = "PurchaseDetailList";
        public string UserKey = "Current_UserName";

        public void LoadProductDetails(bool deleted = false, string search = "")
        {
            var list = this._PurchaseService.GetProductDetails(deleted, search);
            this.GridViewProductDetails.DataSource = list;
            this.GridViewProductDetails.DataBind();
        }

        public void LoadDropdownWarehouses()
        {
            var list = this._PurchaseService.GetWarehousesForDropdowns();
            this.ddlstWarehouses.DataSource = list;
            this.ddlstWarehouses.DataTextField = "Name";
            this.ddlstWarehouses.DataValueField = "Id";
            this.ddlstWarehouses.DataBind();

            this.ddlstWarehouses.Items.Insert(0, new ListItem("Seleccione una bodega", "0"));
        }

        public void LoadDropDownSuppliers()
        {
            var list = this._PurchaseService.GetSuppliersForDropDowns();
            this.ddlstSuppliers.DataSource = list;
            this.ddlstSuppliers.DataTextField = "Name";
            this.ddlstSuppliers.DataValueField = "Id";
            this.ddlstSuppliers.DataBind();

            this.ddlstSuppliers.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
        }

        public void LoadGridViewForTempList(List<TempPurchaseList> list = null)
        {
            List<TempPurchaseList> EmptyList = new List<TempPurchaseList>();
            if (list != null)
            {
                this.GridViewPurchaseDetails.DataSource = list;
                this.GridViewPurchaseDetails.DataBind();
            }
            else
            {
                if (Session[TempListKey] != null)
                {
                    this.TempList = Session[TempListKey] as List<TempPurchaseList>;
                    this.GridViewPurchaseDetails.DataSource = TempList;
                    this.GridViewPurchaseDetails.DataBind();
                }
                else
                {
                    this.GridViewPurchaseDetails.DataSource = EmptyList;
                    this.GridViewPurchaseDetails.DataBind();
                }
            }
        }

        public void LoadDropdownForMeasureUnits(int TypeId)
        {
            List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();
            list = this._PurchaseService.ListMeasureUnitForDropdownsByType(TypeId);
            this.DropDownListUnitsMeasure.DataSource = list;
            this.DropDownListUnitsMeasure.DataTextField = "Name";
            this.DropDownListUnitsMeasure.DataValueField = "Id";
            this.DropDownListUnitsMeasure.DataBind();

            this.DropDownListUnitsMeasure.Items.Insert(0, new ListItem("Unidades de medida", "0"));
        }

        public void LoadGridVewInvoces(DateTime? StartDate, DateTime? EndDate, string Search = "")
        {
            DateTime Start, End;
            List<InvoicesDto> Invoices = new List<InvoicesDto>();
            if (StartDate != null && EndDate != null)
            {
                Start = (DateTime)StartDate;
                End = (DateTime)EndDate;
                Invoices = this._PurchaseService.GetPurhaseInvoices(Start, End, Search);
            }
            else
            {
                Start = Convert.ToDateTime("1998-10-01");
                End = DateTime.Now.AddDays(1);
                Invoices = this._PurchaseService.GetPurhaseInvoices(Start, End, Search);
            }

            this.GridViewInvoices.DataSource = Invoices;
            this.GridViewInvoices.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadProductDetails();
                this.LoadDropdownWarehouses();
                this.LoadDropDownSuppliers();
                this.LoadGridVewInvoces(null, null);
            }

            Session[UserKey] = "01dlopezs98@gmail.com";
            this.LoadGridViewForTempList();
        }

        protected void GridViewProductDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int index = Row.RowIndex;
            string Code = GridViewProductDetails.DataKeys[index]["Code"].ToString();

            switch (e.CommandName)
            {
                case "cmdSelect":
                    this.ResetInputsForPurchaseDetail();
                    this.SendProductDetailToTextbox(Code);
                    break;
                default:
                    break;
            }
        }

        private void SendProductDetailToTextbox(string code)
        {
            var prod = this._PurchaseService.GetAProductDetail(code);
            this.LoadDropdownForMeasureUnits(prod.UnitTypeId);
            txtMeasureUnitId.Text = prod.MeasureUnitId.ToString(); txtMeasureUnitTypeId.Text = prod.UnitTypeId.ToString();
            txtProductName.Text = prod.ProductName; txtProductDetailCode.Text = prod.Code; txtBrandName.Text = prod.BrandName;
            txtCategoryName.Text = prod.CategoryName; txtMaterialName.Text = prod.MaterialName; txtDimensions.Text = prod.Dimensions;
            txtUnitMeasureBase.Text = prod.MeasureUnit; DropDownListUnitsMeasure.SelectedValue = prod.MeasureUnitId.ToString();

        }

        public void ResetInputsForPurchaseDetail()
        {
            btnAddToPurchaseDetailList.Text = "Agregar"; txtWarehouseId.Text = "";
            ddlstWarehouses.SelectedIndex = 0; txtTaxDetail.Text = ""; txtDetailDiscount.Text = ""; txtBrandName.Text = "";
            txtPurchasePrice.Text = ""; ddlistValidateSalePrice.SelectedValue = "1"; txtMaterialName.Text = ""; txtProductCodeForDelete.Text = "";
            txtUnitMeasureBase.Text = ""; txtQuantity.Text = ""; txtSalePrice.Text = ""; txtMeasureUnitId.Text = ""; txtCategoryName.Text = "";
            txtProductName.Text = ""; txtProductDetailCode.Text = ""; txtDimensions.Text = ""; txtMeasureUnitTypeId.Text = "";
            pickerExpiryDate.Text = "";
        }

        protected void btnAddToPurchaseDetailList_Click(object sender, EventArgs e)
        {
            string Option = btnAddToPurchaseDetailList.Text;
            string ShowToaster;
            switch (Option)
            {
                case "Agregar":
                    ShowToaster = "launch_Toast_ItemAddedToTempList()";
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

        private void AddItemToTempList()
        {
            bool AlreadyExist;
            string ShowToaster = "Toast_ItemAlreadyExists()";
            int warehouseId = Convert.ToInt32(ddlstWarehouses.SelectedValue);
            TempPurchaseList Temp = this.CreateObjectForTempList();
            if (Session[TempListKey] == null)
            {
                TempList = new List<TempPurchaseList>();
                TempList.Add(Temp); Session[TempListKey] = TempList;
                this.ResetInputsForPurchaseDetail();
            }
            else
            {
                TempList = Session[TempListKey] as List<TempPurchaseList>;
                AlreadyExist = TempList.Exists(x => x.Code == Temp.Code && x.WarehouseId == warehouseId);
                if (!AlreadyExist) { TempList.Add(Temp); this.ResetInputsForPurchaseDetail(); } else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true); }
            }

            this.LoadGridViewForTempList(TempList);
            this.calculateTotalAmount();
        }


        private void EditItemFromTempList()
        {
            bool AlreadyExist;
            string ShowModal;
            string Code = txtProductDetailCode.Text;
            int newWarehouseid = Convert.ToInt32(ddlstWarehouses.SelectedValue);
            int WarehouseId = Convert.ToInt32(txtWarehouseId.Text);

            this.TempList = Session[TempListKey] as List<TempPurchaseList>;
            if (WarehouseId != newWarehouseid)
            {
                AlreadyExist = TempList.Exists(x => x.Code == Code && x.WarehouseId == newWarehouseid);
                if (AlreadyExist)
                {
                    btnConfirmDeleteProduct.Text = "Confirmar";
                    ShowModal = "ShowAlertInfo('Ya existe el mismo producto en la bodega seleccionada, desea sobreescribir este registro?')";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModal, true);
                }
                else
                {
                    this.ConfirmUpdateProductOnTheList();
                }
            }
            else
            {
                this.ConfirmUpdateProductOnTheList();
            }
        }

        public void ConfirmUpdateProductOnTheList()
        {
            string ShowToaster;
            DateTime expirydate;
            string Code = txtProductDetailCode.Text;
            int newWarehouseid = Convert.ToInt32(ddlstWarehouses.SelectedValue);
            int WarehouseId = Convert.ToInt32(txtWarehouseId.Text);

            this.TempList = Session[TempListKey] as List<TempPurchaseList>;
            TempPurchaseList temp = this.TempList.FirstOrDefault(x => x.Code == Code && x.WarehouseId == WarehouseId);
            temp.TargetUnitId = Convert.ToInt32(DropDownListUnitsMeasure.SelectedValue);
            temp.TargetUnitName = DropDownListUnitsMeasure.SelectedItem.Text;
            temp.WarehouseName = ddlstWarehouses.SelectedItem.Text;
            temp.WarehouseId = newWarehouseid;
            temp.Quantity = Convert.ToInt32(txtQuantity.Text);
            temp.PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text);
            temp.Discount = Convert.ToInt32(txtDetailDiscount.Text);
            temp.Tax = Convert.ToDouble(txtTaxDetail.Text);
            temp.SalePrice = Convert.ToDouble(txtSalePrice.Text);
            if (pickerExpiryDate.Text != "")
            {
                expirydate = Convert.ToDateTime(pickerExpiryDate.Text);
                if (expirydate > DateTime.Now)
                    temp.ExpirationDate = expirydate;
                else
                    temp.ExpirationDate = DateTime.Now;
            }
            else
            {
                temp.ExpirationDate = DateTime.Now;
            }
            //temp.SalePriceByUnitBase = this.CalculateSalePriceByUnitBase(temp.TargetUnitId, temp.MeasureUnitBaseId, temp.SalePrice);

            ShowToaster = "Toaster_ProductUpdated()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true);

            this.LoadGridViewForTempList(TempList);
            this.ResetInputsForPurchaseDetail();
            this.calculateTotalAmount();
        }

        private void calculateTotalAmount()
        {
            double Total, Subtotal; int Discount;
            Subtotal = this.CalculateSubTotalAmount();
            Total = Subtotal;
            if (txtTotalTax.Text != "")
                Total = Total + Convert.ToDouble(txtTotalTax.Text);

            if (txtTotalDiscount.Text != "")
            {
                Discount = Convert.ToInt32(txtTotalDiscount.Text);
                Total = Total - (((double)Discount / 100) * Total);
            }

            txtTotal.Text = Total.ToString();
        }

        private double CalculateSubTotalAmount()
        {
            double SubtotalAmount = 0;
            TempList = Session[TempListKey] as List<TempPurchaseList>;
            if (TempList != null)
            {
                foreach (TempPurchaseList temp in TempList)
                {
                    SubtotalAmount = SubtotalAmount + temp.Total;
                }

                txtSubtotal.Value = SubtotalAmount.ToString();
            }

            return SubtotalAmount;
        }

        private TempPurchaseList CreateObjectForTempList()
        {
            DateTime expirydate;
            double purchaseprice = Convert.ToDouble(txtPurchasePrice.Text);
            TempPurchaseList Temp = new TempPurchaseList();
            Temp.Code = txtProductDetailCode.Text;
            Temp.ProductName = txtProductName.Text;
            Temp.BrandName = txtBrandName.Text;
            Temp.MeasureUnitBaseId = Convert.ToInt32(txtMeasureUnitId.Text);
            Temp.TargetUnitId = Convert.ToInt32(DropDownListUnitsMeasure.SelectedValue);
            Temp.UnitTypeId = Convert.ToInt32(txtMeasureUnitTypeId.Text);
            Temp.WarehouseName = ddlstWarehouses.SelectedItem.Text;
            Temp.WarehouseId = Convert.ToInt32(ddlstWarehouses.SelectedValue);
            Temp.MaterialName = txtMaterialName.Text;
            Temp.MeasureUnitBase = txtUnitMeasureBase.Text;
            Temp.TargetUnitName = DropDownListUnitsMeasure.SelectedItem.Text;
            Temp.Quantity = Convert.ToInt32(txtQuantity.Text);
            Temp.PurchasePrice = purchaseprice;
            Temp.Discount = Convert.ToInt32(txtDetailDiscount.Text);
            Temp.Tax = Convert.ToDouble(txtTaxDetail.Text);
            if (txtSalePrice.Text != "") { Temp.SalePrice = Convert.ToDouble(txtSalePrice.Text); } else { Temp.SalePrice = purchaseprice + (((double)40 / 100) * purchaseprice); }
            Temp.Dimensions = txtDimensions.Text;
            Temp.CategoryName = txtCategoryName.Text;
            if (pickerExpiryDate.Text != "")
            {
                expirydate = Convert.ToDateTime(pickerExpiryDate.Text);
                if (expirydate > DateTime.Now)
                    Temp.ExpirationDate = expirydate;
                else
                    Temp.ExpirationDate = DateTime.Now;
            }
            else
            {
                Temp.ExpirationDate = DateTime.Now;
            }
            //Temp.SalePriceByUnitBase = this.CalculateSalePriceByUnitBase(Temp.TargetUnitId, Temp.MeasureUnitBaseId, Temp.SalePrice);
            return Temp;
        }

        //private double CalculateSalePriceByUnitBase(int IdConvertFrom, int IdConvertTo, double? saleprice)
        //{
        //    double Result;
        //    double conversion = this._CommonServices.GetConversionValue(IdConvertFrom, IdConvertTo, null);
        //    Result = (double)saleprice / conversion;
        //    return Result;
        //}
        protected void btnCancelOrClearDetailForm_Click(object sender, EventArgs e)
        {
            this.ResetInputsForPurchaseDetail();
        }

        protected void ddlistValidateSalePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(ddlistValidateSalePrice.SelectedValue);
            if (value == 1) { this.txtSalePrice.ReadOnly = true; } else if (value == 2) { this.txtSalePrice.ReadOnly = false; }
        }

        protected void btnRecalculatePurchaseTotal_Click(object sender, EventArgs e)
        {
            this.calculateTotalAmount();
        }

        protected void btnGeneratePurchase_Click(object sender, EventArgs e)
        {
            string showAlert;
            this.TempList = Session[TempListKey] as List<TempPurchaseList>;
            this.UserName = Session[UserKey] as string;
            this.calculateTotalAmount();
            double totalAmount = Convert.ToDouble(txtTotal.Text);
            PurchaseTransacDto Invoice = new PurchaseTransacDto()
            {
                SupplierId = Convert.ToInt32(ddlstSuppliers.SelectedValue),
                SupplierInvoiceNumber = txtSupplierInvoiceNumber.Text,
                TotalProducts = this.TempList.Count,
                Tax = Convert.ToDouble(txtTotalTax.Text),
                Subtotal = Convert.ToDouble(txtSubtotal.Value),
                Discount = Convert.ToInt32(txtTotalDiscount.Text),
                UserName = this.UserName,
                TotalAmount = totalAmount,
                Details = this.TempList
            };

            Response res = this._PurchaseService.RegisterPurchaseTransaction(Invoice);
            
            if (res.Success) { showAlert = string.Format("ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
            else { showAlert = string.Format("ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
            this.ResetAllForm();
            this.DeleteAllProductsFromList();
            this.LoadGridVewInvoces(null, null);
        }

        protected void btnPurchaseCancel_Click(object sender, EventArgs e)
        {
            this.ResetAllForm();
            this.DeleteAllProductsFromList();
        }

        private void ResetAllForm()
        {
            this.txtSupplierInvoiceNumber.Text = ""; txtTotalTax.Text = "";
            this.txtTotal.Text = ""; txtSubtotal.Value = ""; txtTotalDiscount.Text = "";
            this.ResetInputsForPurchaseDetail();
        }

        protected void GridViewPurchaseDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int Index = Row.RowIndex;
            string Code = Convert.ToString(GridViewPurchaseDetails.DataKeys[Index]["Code"]);
            int WarehouseId = Convert.ToInt32(GridViewPurchaseDetails.DataKeys[Index]["WarehouseId"]);
            string showmodal = string.Format("ShowAlertInfo('Estás seguro de eliminar el producto de la lista?')");
            switch (e.CommandName)
            {
                case "cmdEdit":
                    btnConfirmDeleteProduct.Text = "Confirmar";
                    this.SendElementsToTextboxFromTempList(Code, WarehouseId);
                    this.btnAddToPurchaseDetailList.Text = "Editar";
                    break;
                case "cmdDelete":
                    btnConfirmDeleteProduct.Text = "Eliminar";
                    txtProductCodeForDelete.Text = Code;
                    txtWarehouseId.Text = WarehouseId.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showmodal, true);
                    break;
                default:
                    break;
            }
        }


        protected void btnConfirmDeleteProduct_Click(object sender, EventArgs e)
        {
            string Code;
            int WarehouseId;
            string option = btnConfirmDeleteProduct.Text;
            switch (option)
            {
                case "Eliminar":
                    Code = txtProductCodeForDelete.Text;
                    WarehouseId = Convert.ToInt32(txtWarehouseId.Text);
                    this.DeleteProductFromTempList(Code, WarehouseId);
                    this.LoadGridViewForTempList(TempList);
                    this.ResetInputsForPurchaseDetail();
                    this.calculateTotalAmount();
                    break;
                case "Confirmar":
                    Code = txtProductDetailCode.Text;
                    WarehouseId = Convert.ToInt32(ddlstWarehouses.SelectedValue);
                    this.DeleteProductFromTempList(Code, WarehouseId);
                    this.ConfirmUpdateProductOnTheList();
                    break;
                default:
                    break;
            }
        }

        private void DeleteProductFromTempList(string Code, int WarehouseId)
        {
            this.TempList = Session[TempListKey] as List<TempPurchaseList>;
            TempPurchaseList temp = this.TempList.FirstOrDefault(x => x.Code == Code && x.WarehouseId == WarehouseId);
            TempList.Remove(temp);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('#ConfirmDeletions').modal('hide')", true);
        }

        private void SendElementsToTextboxFromTempList(string Code, int WarehouseId)
        {

            this.TempList = Session[TempListKey] as List<TempPurchaseList>;
            TempPurchaseList temp = this.TempList.FirstOrDefault(x => x.Code == Code && x.WarehouseId == WarehouseId);
            this.LoadDropdownForMeasureUnits(temp.UnitTypeId);
            txtMeasureUnitId.Text = temp.MeasureUnitBaseId.ToString();
            txtProductDetailCode.Text = temp.Code;
            txtWarehouseId.Text = temp.WarehouseId.ToString();
            txtProductName.Text = temp.ProductName;
            txtBrandName.Text = temp.BrandName;
            txtCategoryName.Text = temp.CategoryName;
            txtMaterialName.Text = temp.MaterialName;
            txtUnitMeasureBase.Text = temp.MeasureUnitBase;
            txtQuantity.Text = temp.Quantity.ToString();
            txtPurchasePrice.Text = temp.PurchasePrice.ToString();
            txtDetailDiscount.Text = temp.Discount.ToString();
            txtTaxDetail.Text = temp.Tax.ToString();
            txtSalePrice.Text = temp.SalePrice.ToString();
            txtDimensions.Text = temp.Dimensions;
            txtMeasureUnitTypeId.Text = temp.UnitTypeId.ToString();
            ddlstWarehouses.SelectedValue = temp.WarehouseId.ToString();
            DropDownListUnitsMeasure.SelectedValue = temp.TargetUnitId.ToString();
            if (temp.ExpirationDate > DateTime.Now)
                pickerExpiryDate.Text = temp.ExpirationDate.ToString("yyyy-MM-dd");
            else
                pickerExpiryDate.Text = "";
        }

        public void DeleteAllProductsFromList()
        {
            Session.Remove(TempListKey);
            this.LoadGridViewForTempList();
        }

        protected void GridViewInvoices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow Row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int Index = Row.RowIndex;
            int Id = Convert.ToInt32(GridViewInvoices.DataKeys[Index]["Id"]);
            string InvoiceNumber = Convert.ToString(GridViewInvoices.DataKeys[Index]["InvoiceNumber"]);
            string ShowModalDetails = string.Format("ShowModal_InvoiceDetails('{0}')", InvoiceNumber);
            switch (e.CommandName)
            {
                case "cmdDetails":
                    this.LoadGridviewforInvoiceDetails(Id);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModalDetails, true);
                    break;
                default:
                    break;
            }
        }

        private void LoadGridviewforInvoiceDetails(int id)
        {
            List<InvoiceDetailsDto> Details = new List<InvoiceDetailsDto>();
            Details = this._PurchaseService.GetPurchaseInvoiceDetails(id);
            this.GridviewInvoiceDetails.DataSource = Details;
            this.GridviewInvoiceDetails.DataBind();
        }

        protected void btnInvoiceFilter_Click(object sender, EventArgs e)
        {
            string Invoice, ShowToastDate, StartDateString, EndDateString;

            Invoice = txtSearchInvoiceRecords.Text;
            ShowToastDate = "ToastDate()";
            StartDateString = PickerStartDateInvoceFilter.Text;
            EndDateString = PickerEndDateInvoiceFilter.Text;
            if (StartDateString != "" && EndDateString != "")
            {
                DateTime Start = Convert.ToDateTime(StartDateString);
                DateTime End = Convert.ToDateTime(EndDateString);
                if (Start >= End) { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToastDate, true); } else { this.LoadGridVewInvoces(Start, End, Invoice); }
            }
            else
            {
                this.LoadGridVewInvoces(null, null, Invoice);
            }
        }

        protected void btnSearchProductDetails_Click(object sender, EventArgs e)
        {
            string Search = txtSearchProductDetails.Value;
            this.LoadProductDetails(search: Search);
        }

        protected void btnCreateNewWarehouse_Click(object sender, EventArgs e)
        {
            string ShowAlert;
            this.UserName = Session[UserKey] as string;
            WarehousesDto dto = new WarehousesDto()
            {
                Name = txtFormWhsWarehouseName.Text,
                Description = txtFormWhsDescription.Text,
                Location = txtFormWhsLocation.Text,
                CreatedBy = this.UserName,
                UpdatedBy = this.UserName
            };

            Response res = this._PurchaseService.CreateWarehouse(dto);

            this.LoadDropdownWarehouses();
            this.ClearModalForms();

            if (res.Success) { ShowAlert = string.Format("ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
            else { ShowAlert = string.Format("ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowAlert, true);
        }

        protected void btnCreateNewSupplier_Click(object sender, EventArgs e)
        {
            string ShowAlert;
            this.UserName = Session[UserKey] as string;
            SuppliersDto dto = new SuppliersDto()
            {
                Name = txtFormSpSupplierName.Text,
                Email = txtFormSpEmailAddres.Text,
                Address = txtFormSpAddress.Text,
                CreatedBy = this.UserName,
                UpdatedBy = this.UserName,
            };

            Response res = this._PurchaseService.CreateSupplier(dto);
            this.LoadDropDownSuppliers();
            this.ClearModalForms();

            if (res.Success) { ShowAlert = string.Format("ShowAlert('{0}', '{1}', 'success')", res.Title, res.Message); }
            else { ShowAlert = string.Format("ShowAlert('{0}', '{1}', 'danger')", res.Title, res.Message); }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowAlert, true);
        }

        public void ClearModalForms()
        {
            txtFormSpSupplierName.Text = "";
            txtFormSpEmailAddres.Text = "";
            txtFormSpAddress.Text = "";

            txtFormWhsWarehouseName.Text = "";
            txtFormWhsDescription.Text = "";
            txtFormWhsLocation.Text = "";
        }
    }
}