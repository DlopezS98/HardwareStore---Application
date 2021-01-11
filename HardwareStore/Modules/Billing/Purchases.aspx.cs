using HardwareStore.Core.Interfaces;
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
        public IProductsRepository vProductsRepository { get; set; }

        public void LoadProductDetails(bool deleted = false, string search = "")
        {
            var list = this.vProductsRepository.ListAllProducts(deleted, search);
            this.GridViewProductDetails.DataSource = list;
            this.GridViewProductDetails.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadProductDetails();
        }
    }
}