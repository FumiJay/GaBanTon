using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GaBanTon.Models;
using System.Data;

namespace GaBanTon.DB
{
    public class GroupDB
    {
        public const string _ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=GayBanDou;Integrated Security=true";

        #region 新增
        public static void insert(GroupModel model)
        {
            string queryString =
                $@" INSERT INTO [Group]
                    (GroupImg,GroupTital,MemberName,MemberID,ShopID,ShopName,Status)
                    VALUES
                    (@GroupImg,@GroupTital,@MemberName,@MemberID,@ShopID,@ShopName,@Status)";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter ("@GroupImg",model.GroupImg),
                new SqlParameter ("@GroupTital",model.GroupTital),
                new SqlParameter ("MemberName",model.MemberName),
                new SqlParameter ("@MemberID",model.MemberID),
                new SqlParameter ("@ShopID",model.ShopID),
                new SqlParameter ("@ShopName",model.ShopName),
                new SqlParameter ("@Status",model.Status = "未結團")
            };

            DBbase.ExecuteNonQuery(queryString, parameters);
        }
        #endregion

        #region GroupView
        public static MainPageModel GetGroupModel(int Sid)
        {
            string queryString = $@" SELECT
                                     GroupImg, GroupTital, MemberName, ShopID, ShopName, Status
                                     FROM [Group]
                                     WHERE Sid = @Sid";

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Sid", Sid);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    MainPageModel model = null;

                    while (reader.Read())
                    {
                        model = new MainPageModel();
                        model.GroupImg = (string)reader["GroupImg"];
                        model.GroupTital = (string)reader["GroupTital"];
                        model.MemberName = (string)reader["MemberName"];
                        model.ShopID = (int)reader["ShopID"];
                        model.ShopName = (string)reader["ShopName"];
                        model.Status = (string)reader["Status"];
                    }

                    reader.Close();

                    return model;
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