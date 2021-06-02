using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaBanTon.Models
{
    public class GroupModel
    {
        public string GroupSid { get; set; }
        public string GroupImg { get; set; }
        public string GroupTital { get; set; }
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Status { get; set; }
    }
}