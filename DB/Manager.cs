using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GaBanTon.DB
{
    public class Manager
    {
        #region 資料庫連動下拉式選單

        public const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=GayBanDou;Integrated Security=true";

        public static void ShopName(ref DropDownList DDlist)
        {
            string queryString = $@"SELECT ShopID, ShopName
                                    FROM Shop";

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter(command);
                    ad.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DDlist.DataSource = dt;
                        DDlist.DataTextField = "ShopName";
                        DDlist.DataValueField = "ShopName";
                        DDlist.DataBind();

                        DDlist.Items.Insert(0, "請選擇");
                        DDlist.SelectedIndex = 0;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion
    }
}