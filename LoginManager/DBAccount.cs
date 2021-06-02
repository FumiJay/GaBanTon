using GaBanTon.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GaBanTon.LoginManager
{
    public class DBAccount
    {
        public static DataTable AccountCheck(string account)
        {
            string connectionstring = "Data Source=localhost\\SQLExpress;Initial Catalog=GayBanDou;Integrated Security=true";

            string querystring = @"SELECT  * from [User] where Account = @Account;";

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(querystring, con);
                command.Parameters.AddWithValue("@Account", account);

                try
                {
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    reader.Close();

                    return dt;
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write(ex);

                    return null;
                }
            }
        }

        //public AccountModel GetAccount()
        //{
        //    string connectionstring = "Data Source=localhost\\SQLExpress;Initial Catalog=GayBanDou;Integrated Security=true";

        //    string querystring = @"SELECT  * from [User] where Account = @Account;";

        //    using (SqlConnection con = new SqlConnection(connectionstring))
        //    {
        //        SqlCommand command = new SqlCommand(querystring, con);
        //        command.Parameters.AddWithValue("@Account", account);

        //        try
        //        {
        //            con.Open();

        //            SqlDataReader reader = command.ExecuteReader();

        //            DataTable dt = new DataTable();

        //            dt.Load(reader);

        //            reader.Close();

        //            return dt;
        //        }
        //        catch (Exception ex)
        //        {
        //            HttpContext.Current.Response.Write(ex);

        //            return null;
        //        }
        //    }
        //}
    }
}