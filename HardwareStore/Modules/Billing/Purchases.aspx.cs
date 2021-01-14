using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
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
    public partial class Purchases : PageBase
    {
        [Inject]
        public IPurchasesService _PurchaseService { get; set; }
        public List<TempPurchaseList> TempList = null;
        private string TempListKey = "PurchaseDetailList";
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

        public void LoadDropdownMeasureUnits(int Id)
        {
            var data = this._PurchaseService.ListMeasureUnitForDropdownsByType(Id);
            this.ddlistMeasureUnits.DataSource = data;
            this.ddlistMeasureUnits.DataValueField = "Id";
            this.ddlistMeasureUnits.DataTextField = "Name";
            this.ddlistMeasureUnits.DataBind();
            this.ddlistMeasureUnits.Items.Insert(0, new ListItem("Seleccione la unidad de medida", "0"));
        }

        public void LoadGridViewForTempList(List<TempPurchaseList> list = null)
        {
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
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadProductDetails();
                this.LoadDropdownWarehouses();
                this.LoadDropDownSuppliers();
            }

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
            this.LoadDropdownMeasureUnits(prod.UnitTypeId);
            txtMeasureUnitId.Text = prod.MeasureUnitId.ToString();
            txtProductName.Value = prod.ProductName; txtProductDetailCode.Text = prod.Code; txtBrandName.Text = prod.BrandName;
            txtCategoryName.Text = prod.CategoryName; txtMaterialName.Text = prod.MaterialName; txtDimensions.Text = prod.Dimensions;
            txtUnitMeasureBase.Text = prod.MeasureUnit; SpanUnitMeasureAbbreviation.InnerHtml = prod.Abbreviation; txtDefaultCode.Text = prod.DefaultCode;

        }

        public void ResetInputsForPurchaseDetail()
        {
            ddlstWarehouses.SelectedIndex = 0; txtTaxDetail.Text = ""; txtDetailDiscount.Text = ""; txtBrandName.Text = "";
            ddlstSuppliers.SelectedIndex = 0; txtPurchasePrice.Text = ""; ddlistValidateSalePrice.SelectedIndex = 0; txtMaterialName.Text = "";
            txtUnitMeasureBase.Text = ""; txtQuantity.Text = ""; txtSalePrice.Text = ""; txtMeasureUnitId.Text = ""; txtCategoryName.Text = "";
            txtUnitConversion.Text = ""; SpanUnitMeasureAbbreviation.InnerHtml = "U"; txtProductName.Value = ""; txtProductDetailCode.Text = "";
            txtDimensions.Text = ""; txtDefaultCode.Text = ""; txtMeasureUnitId.Text = ""; btnAddToPurchaseDetailList.Text = "Agregar";
            ddlistMeasureUnits.Enabled = false; ddlistMeasureUnits.SelectedIndex = 0;
        }

        protected void ddlistMeasureUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ConvertTo = Convert.ToInt32(ddlistMeasureUnits.SelectedValue);
                int ConvertFrom = Convert.ToInt32(txtMeasureUnitId.Text);
                double value = this._PurchaseService.GetConversionValueById(ConvertFrom, ConvertTo);
                int quantiy = Convert.ToInt32(txtQuantity.Text);
                double result = (quantiy * value);
                txtUnitConversion.Text = result.ToString();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        protected void btnAddToPurchaseDetailList_Click(object sender, EventArgs e)
        {
            string Option = btnAddToPurchaseDetailList.Text;
            string ShowToaster;
            switch (btnAddToPurchaseDetailList.Text)
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

        public void AddItemToTempList()
        {
            bool AlreadyExist;
            string ShowToaster = "Toast_ItemAlreadyExists()";
            TempPurchaseList Temp = this.CreateObjectForTempList();
            if (Session[TempListKey] == null)
            {
                TempList = new List<TempPurchaseList>();
                TempList.Add(Temp); Session[TempListKey] = TempList;
            }
            else
            {
                TempList = Session[TempListKey] as List<TempPurchaseList>;
                AlreadyExist = TempList.Exists(x => x.Code == Temp.Code);
                if (!AlreadyExist) { TempList.Add(Temp); } else { ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowToaster, true); }
            }

            this.LoadGridViewForTempList(TempList);
            this.ResetInputsForPurchaseDetail();
            this.calculateTotalAmount();
        }


        private void EditItemFromTempList()
        {
            TempList = Session[TempListKey] as List<TempPurchaseList>;

        }
        public void calculateTotalAmount()
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

        public double CalculateSubTotalAmount()
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
            TempPurchaseList Temp = new TempPurchaseList()
            {
                Code = txtProductDetailCode.Text,
                ProductName = txtProductName.Value,
                BrandName = txtBrandName.Text,
                WarehouseName = ddlstWarehouses.SelectedItem.Text,
                WarehouseId = Convert.ToInt32(ddlstWarehouses.SelectedValue),
                UnitPurchased = ddlistMeasureUnits.SelectedItem.Text,
                MaterialName = txtMaterialName.Text,
                MeasureUnitBase = txtUnitMeasureBase.Text,
                TargetUnitId = Convert.ToInt32(ddlistMeasureUnits.SelectedValue),
                UnitConversion = Convert.ToDouble(txtUnitConversion.Text),
                Quantity = Convert.ToInt32(txtQuantity.Text),
                PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text),
                Discount = Convert.ToInt32(txtDetailDiscount.Text),
                Tax = Convert.ToDouble(txtTaxDetail.Text),
                SalePrice = Convert.ToDouble(txtSalePrice.Text),
                Dimensions = txtDimensions.Text
            };

            return Temp;
        }

        protected void btnCancelOrClearDetailForm_Click(object sender, EventArgs e)
        {
            this.ResetInputsForPurchaseDetail();
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(this.txtQuantity.Text);
            if (quantity > 0)
            {
                ddlistMeasureUnits.Enabled = true;
            }
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

        }

        protected void btnPurchaseCancel_Click(object sender, EventArgs e)
        {
            this.ResetAllForm();
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
            string Code = Convert.ToString(GridViewPurchaseDetails.DataKeys[Index].Value);
            switch (e.CommandName)
            {
                case "cmdEdit":
                    this.SendElementsToTextboxFromTempList(Code);
                    this.btnAddToPurchaseDetailList.Text = "Editar";
                    break;
                case "cmdDelete":
                    break;
                default:
                    break;
            }
        }

        private void SendElementsToTextboxFromTempList(string Code)
        {
            this.TempList = Session[TempListKey] as List<TempPurchaseList>;
            TempPurchaseList temp = this.TempList.FirstOrDefault(x => x.Code == Code);
            txtProductDetailCode.Text = temp.Code;
            txtProductName.Value = temp.ProductName;
        }
    }
}