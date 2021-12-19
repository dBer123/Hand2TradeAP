using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    class Item
    {
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Desrciption { get; set; }
        public virtual User User { get; set; }
    }
}
