using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Security;
using HardwareStore.Core.Interfaces.Security;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HardwareStore
{
    public partial class Login : PageBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            string showAlert;
            UserDto user = new UserDto()
            {
                UserName = txtUserName.Value,
                Password = txtPassword.Value
            };

            LoginResponse res = this.SecurityService.UserLogin(user);

            if (res.Success)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonData = js.Serialize(res.User);
                showAlert = string.Format("LoggedIn('{0}', 'success', '{1}');", res.Message, jsonData);
            }
            else { showAlert = string.Format("ShowLoader(false); ShowToaster('{0}', 'danger');", res.Message); }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", showAlert, true);
        }
    }
}