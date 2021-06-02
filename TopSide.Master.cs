using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GaBanTon.LoginManager;

namespace GaBanTon
{
    public partial class TopSide : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginHelper.Haslogined())
            {
                this.LoginInfo.Text = "歡迎 : " + HttpContext.Current.Session["Account"] as string;
                this.Login.Visible = false;
                this.Logout.Visible = true;
                this.BtnCreate.Visible = true;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            LoginHelper.Logout();
            Response.Redirect("MainPage.aspx");
        }
    }
}
