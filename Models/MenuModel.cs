using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaBanTon.DB
{
    public class MenuModel
    {
        public int MenuID { get; set; }
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}