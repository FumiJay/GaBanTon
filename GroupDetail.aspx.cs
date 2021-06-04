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
        static int carTotalPrice = 0;
        static int totalPrice;
        static List<OrderModel> TempCar = new List<OrderModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int GroupSid = Convert.ToInt32(Request.QueryString["GroupSid"]);

                //抓該團的資訊
                var model = GroupDB.GetGroupModel(GroupSid);

                this.GroupImg.Src = model.GroupImg;
                this.GroupTital.Text = model.GroupTital;
                this.GroupLider.Text = model.MemberName;
                this.Shop.Text = model.ShopName;

                if (!LoginHelper.Haslogined())
                {
                    this.GroupStaus.Enabled = false;
                    this.Rep_MenuList.EnableViewState = false;
                    this.ErrMess.Visible = true;
                    this.ErrMess.Text = "沒登入還想點餐R";
                }
                else if (model.MemberID != Convert.ToInt32(HttpContext.Current.Session["Sid"]))
                {

                    this.GroupStaus.Enabled = false;
                }

                var dt = DetailDB.RowMenu(model.ShopID);

                this.Rep_MenuList.DataSource = dt;
                this.Rep_MenuList.DataBind();

                this.WhoBuy.DataSource = DetailDB.GetOrder(GroupSid);
                this.WhoBuy.DataBind();

                DataTable subdt = DetailDB.SubTotal(GroupSid);
                List<OrderModel> submodel = new List<OrderModel>();

                foreach (DataRow item in subdt.Rows)
                {
                    totalPrice += Convert.ToInt32(item["Qty"]) * Convert.ToInt32(item["Price"]);

                    if (submodel.FindIndex(obj => obj.MenuName == item["MenuName"].ToString()) == -1)
                    {
                        OrderModel orderModel = new OrderModel();
                        orderModel.MenuName = item["MenuName"].ToString();
                        orderModel.Qty = Convert.ToInt32(item["Qty"]);
                        orderModel.Price += Convert.ToDecimal(totalPrice);
                        submodel.Add(orderModel);
                    }
                    else
                    {
                        submodel[submodel.FindIndex(obj => obj.MenuName == item["MenuName"].ToString())].Qty += Convert.ToInt32(item["Qty"]);
                    }
                }

                this.SubTotal.DataSource = submodel;
                this.SubTotal.DataBind();
            }
        }

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

            Qty.SelectedIndex = 0;
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            DetailDB.TakeOrder(TempCar);
            carTotalPrice = 0;
            this.Menu_Total.Text = string.Empty;
            this.Price_Total.Text = string.Empty;
            TempCar.Clear();

            Response.Redirect($"GroupDetail.aspx?GroupSid={Request.QueryString["GroupSid"]}");
        }

        protected void WhoBuy_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dataRow = e.Item.DataItem as DataRowView;
                var result = e.Item.FindControl("Food") as Repeater;

                int GroupSid = Convert.ToInt32(Request.QueryString["GroupSid"]);
                DataTable dt = DetailDB.GetOrderDetail(GroupSid, (int)dataRow["MemberID"]);

                List<OrderModel> model = new List<OrderModel>();

                foreach (DataRow item in dt.Rows)
                {
                    if (model.FindIndex(obj => obj.MenuName == item["MenuName"].ToString()) == -1)
                    {
                        OrderModel orderModel = new OrderModel();
                        orderModel.MenuName = item["MenuName"].ToString();
                        orderModel.Qty = Convert.ToInt32(item["Qty"]);
                        model.Add(orderModel);
                    }
                    else
                    {
                        model[model.FindIndex(obj => obj.MenuName == item["MenuName"].ToString())].Qty += Convert.ToInt32(item["Qty"]);
                    }
                }

                result.DataSource = model;
                result.DataBind();
            }
        }

        protected void WhoBuy_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string cmdName = e.CommandName;
            string cmdArgu = e.CommandArgument.ToString();

            if ("DeleteItem" == cmdName)
            {
                DetailDB.Delete(Convert.ToInt32(cmdArgu));
                Response.Redirect($"GroupDetail.aspx?GroupSid={Request.QueryString["GroupSid"]}");
            }
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            if (this.GroupStaus.SelectedIndex == 1)
            {
                DetailDB.GroupEnd(Convert.ToInt32(Request.QueryString["GroupSid"]));

                this.Rep_MenuList.EnableViewState = false;
                this.ErrMess.Text = "抱歉,已經結團。　下次請早。";
            }
        }

        
        protected void SubTotal_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    DataRowView dr = e.Item.DataItem as DataRowView;
            //    totalPrice += Convert.ToInt32(dr["Qty"]) * Convert.ToInt32(dr["Price"]);
            //}

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label Label = (Label)e.Item.FindControl("Price");
                Label.Text = $"總計:NT$ {totalPrice}元";
            }
        }
    }
}