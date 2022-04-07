using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuDD4_MorckProject.Models
{
    public partial class CartProduct
    {
        public string cart_id { get; set; }
        public int Product_id { get; set; }
        public Nullable<int> Product_number { get; set; }
        public string Product_img { get; set; }
        public Nullable<decimal> Product_price { get; set; }
        public string Product_name { get; set; }
    }
}