using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaBanTon.Models
{
    public class BuyMember
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int GroupID { get; set; }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string Qty { get; set; }
    }
}