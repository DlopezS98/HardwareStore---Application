using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HardwareStore.Modules.ProductsAdmin
{
    public partial class AdministrationIndex : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnProductWarehouse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/ProductsAdmin/WarehouseProducts.aspx");
        }

        protected void btntransferencies_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/ProductsAdmin/TranfersAdministration.aspx");
        }

        protected void btnDamage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/ProductsAdmin/RemovedProducts.aspx");
        }
    }
}