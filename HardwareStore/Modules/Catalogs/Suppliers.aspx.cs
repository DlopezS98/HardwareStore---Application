using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HardwareStore.Modules.Catalogs
{
    public partial class Suppliers : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnProTodos_Click(object sender, EventArgs e)
        {
            mtvContenedor.ActiveViewIndex = 1;
        }

        protected void BtnAtras_Click(object sender, EventArgs e)
        {
            mtvContenedor.ActiveViewIndex = 0;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/Catalogs.Module/MainCatalogs.aspx");
        }
    }
}