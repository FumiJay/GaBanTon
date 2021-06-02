using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GaBanTon.DB;
using GaBanTon.LoginManager;
using GaBanTon.Models;

namespace GaBanTon
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Manager.ShopName(ref Shop);
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Shop.SelectedValue == "請選擇")
            {
                this.Mess.Text = "店家沒選拉! 北七逆?";
                return;
            }

            var model = new GroupModel();

            model.GroupTital = this.GroupName.Text;
            model.ShopID = this.Shop.SelectedIndex;
            model.ShopName = this.Shop.SelectedValue;
            model.GroupImg = this.GroupImg.SelectedValue;
            model.MemberID = HttpContext.Current.Session["Sid"] as string;
            model.MemberName = HttpContext.Current.Session["Account"] as string;

            GroupDB.insert(model);
            this.Mess.Text = "新增成功";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.GroupName.Text = string.Empty;
            this.Shop.SelectedIndex = 0;
            this.GroupImg.SelectedIndex = 0;
        }

        protected void GroupImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ImgView.Src = this.GroupImg.SelectedValue;
        }
    }
}