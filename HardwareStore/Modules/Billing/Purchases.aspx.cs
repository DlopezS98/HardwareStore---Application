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
    public partial class Purchases : PageBase
    {
        [Inject]
        public IPurchasesService _PurchaseService { get; set; }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadProductDetails();
            this.LoadDropdownWarehouses();
            this.LoadDropDownSuppliers();
        }
    }
}