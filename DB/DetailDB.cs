using GaBanTon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GaBanTon.DB
{
    public class DetailDB
    {
        public const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=GayBanDou;Integrated Security=true";

        #region VeiwMenu
        public static DataTable RowMenu(int ShopID)
        {
            string queryString =
                $@" SELECT * FROM Menu
                    WHERE ShopID = @ShopID
                  ";

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ShopID", ShopID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion

        #region Insert to Order

        public static void TakeOrder(List<OrderModel> model)
        {
            string queryString =
                $@" INSERT INTO [Order]
                    (MemberID,GroupID,MenuID,Qty)
                    VALUES
                    (@MemberID,@GroupID,@MenuID,@Qty)
                  ";

            foreach (var item in model)
            {
                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter ("@MemberID",item.MemberID),
                    new SqlParameter ("@GroupID",item.GroupID),
                    new SqlParameter ("@MenuID",item.MenuID),
                    new SqlParameter ("@Qty",item.Qty)
                };

                DBbase.ExecuteNonQuery(queryString, parameters);
            }
        }

        #endregion

        #region BuyerView

        public static DataTable GetOrder(int GroupID)
        {
            string queryString = $@"SELECT  MemberID, [Name] 
                                    FROM [Order]
                                    JOIN [User] ON [Order].MemberID = [User].Sid
                                    JOIN [Menu] ON [Order].MenuID = [Menu].MenuID
                                    Where GroupID = @GroupID
                                    Group By MemberID, [Name];";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
               new SqlParameter("@GroupID", GroupID)
            };

            var dt = DBbase.GetDataTable(queryString, parameters);
            return dt;
        }

        #endregion

        #region BuyerViewDetail

        public static DataTable GetOrderDetail(int GroupID, int UserID)
        {
            string queryString = $@"SELECT GroupID, MemberID, [Name], MenuName, Qty
                                    FROM [Order]
                                    JOIN [User] ON [Order].MemberID = [User].Sid
                                    JOIN [Menu] ON [Order].MenuID = [Menu].MenuID
                                    Where GroupID = @GroupID AND Sid = @Sid
                                   ";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
               new SqlParameter("@GroupID", GroupID),
               new SqlParameter("@Sid", UserID)
            };

            var dt = DBbase.GetDataTable(queryString, parameters);
            return dt;
        }

        #endregion

        #region MyRegion

        public static void  Delete(int MemberID)
        {
            string queryString =
                $@" DELETE [Order]
                    WHERE MemberID = @MemberID
                  ";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MemberID", MemberID)
            };

            DBbase.ExecuteNonQuery(queryString, parameters);
        }

        #endregion


        #region GroupEnd

        public static DataTable GroupEnd(int GroupID)
        {
            string queryString = $@"UPDATE [Group]
                                    SET [Status] = '已結團'
                                    WHERE Sid = @GroupID
                                    ";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
               new SqlParameter("@GroupID", GroupID)
            };

            var dt = DBbase.GetDataTable(queryString, parameters);
            return dt;
        }

        #endregion

        #region SubTotal

        public static DataTable SubTotal(int GroupID)
        {
            string queryString = $@"SELECT  GroupID, MenuName, Price, Qty
                                    FROM [Order]
                                    JOIN [Menu] ON [Order].MenuID = [Menu].MenuID
                                    Where GroupID = @GroupID;";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
               new SqlParameter("@GroupID", GroupID)
            };

            var dt = DBbase.GetDataTable(queryString, parameters);
            return dt;
        }

        #endregion
    }
}
