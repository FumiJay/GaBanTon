using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GaBanTon.LoginManager
{
    public class LoginHelper
    {
        private const string _SessionKey = "Logined";
        private const string _SessionAccount = "Account";
        private const string _SessionSid = "Sid";

        public static bool Haslogined()
        {
            bool? val = HttpContext.Current.Session[_SessionKey] as bool?;

            if (val.HasValue && val.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool tryLogin(string Account, string Password )
        {
            if (Haslogined())
            {
                return true;
            }

            DataTable dt = DBAccount.AccountCheck(Account);

            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            string DBpwd = dt.Rows[0].Field<string>("Password");
            string DBName = dt.Rows[0].Field<string>("Name");
            string DBsid = dt.Rows[0].Field<int>("Sid").ToString();

            bool isPasswordRight = string.Compare(DBpwd, Password.Trim()) == 0;

            if (isPasswordRight)
            {
                HttpContext.Current.Session[_SessionKey] = true;
                HttpContext.Current.Session[_SessionAccount] = DBName;
                HttpContext.Current.Session[_SessionSid] = DBsid;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Logout()
        {
            if (!Haslogined())
            {
                return;
            }
            else
            {
                HttpContext.Current.Session.Remove(_SessionKey);
                HttpContext.Current.Session.Remove(_SessionAccount);
            }
        }
        public static string GetUserName()
        {
            if (!Haslogined())
            {
                return string.Empty;
            }
            else
            {
                return HttpContext.Current.Session[_SessionAccount] as string;
            }
        }
    }
}