using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GaBanTon.LoginManager;
using GaBanTon.DB;
using GaBanTon.Models;
using System.Data;

namespace GaBanTon
{
    public partial class GroupDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!LoginHelper.Haslogined())
                {
                    this.GroupStaus1.Enabled = false;
                    this.Rep_MenuList.EnableViewState = false;
                    this.ErrMess.Visible = true;
                    this.ErrMess.Text = "沒登入還想點餐R";
                }
                else if (this.GroupLider.Text != HttpContext.Current.Session["Account"] as string)
                {
                    this.GroupStaus1.Enabled = false;
                }

                int GroupSid = Convert.ToInt32(Request.QueryString["GroupSid"]);

                //抓該團的資訊
                var model = GroupDB.GetGroupModel(GroupSid);

                this.GroupImg.Src = model.GroupImg;
                this.GroupTital.Text = model.GroupTital;
                this.GroupLider.Text = model.MemberName;
                this.Shop.Text = model.ShopName;

                var dt = DetailDB.RowMenu(model.ShopID);

                this.Rep_MenuList.DataSource = dt;
                this.Rep_MenuList.DataBind();
                

                this.WhoBuy.DataSource = DetailDB.GetOrder(GroupSid);
                this.WhoBuy.DataBind();
            }
        }

        static int carTotalPrice = 0;

        static List<OrderModel> TempCar = new List<OrderModel>();

        protected void MenuBar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList Qty = (DropDownList)sender; //此sender就是DropDownList
            int GroupSid = Convert.ToInt32(Request.QueryString["GroupSid"]);
            string[] tempcar = Qty.ToolTip.Split(',');//以逗號做切片,做成陣列

            carTotalPrice += Convert.ToInt32(Qty.SelectedValue) * Convert.ToInt32(tempcar[1]);
            //要設定全域靜態變數，才可以在記憶體內做別的MENU總數相加
            
            this.Menu_Total.Text += $" {tempcar[0]} {Qty.SelectedValue}個 {tempcar[1]} " + Environment.NewLine;
            this.Menu_Total.Text += $"加總為: {Convert.ToInt32(Qty.SelectedValue) * Convert.ToInt32(tempcar[1])} " + Environment.NewLine;
            this.Price_Total.Text = $"總金額為: {carTotalPrice}";

            var model = new OrderModel();
            model.GroupID = GroupSid;
            model.MemberID = Convert.ToInt32(HttpContext.Current.Session["Sid"]);
            model.MenuID = Convert.ToInt32(tempcar[2]);
            model.Qty = Convert.ToInt32(Qty.SelectedValue);

            TempCar.Add(model);
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            DetailDB.TakeOrder(TempCar);
            TempCar.Clear();
            carTotalPrice = 0;
        }

        protected void WhoBuy_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dataRow = e.Item.DataItem as DataRowView;

                var result = e.Item.FindControl("Food") as Repeater;
                int GroupSid = Convert.ToInt32(Request.QueryString["GroupSid"]);

                result.DataSource = DetailDB.GetOrderDetail(GroupSid, (int)dataRow["MemberID"]);
                result.DataBind();
            }
        }
    }
}