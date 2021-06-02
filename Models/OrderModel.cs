using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaBanTon.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int GroupID { get; set; }
        public int MenuID { get; set; }
        public int Qty { get; set; }
    }
}