using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public class TradeChat
    {
        public int ChatId { get; set; }
        public int ItemId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public bool IsTradeAgreed { get; set; }
        public virtual User Buyer { get; set; }
        public virtual Item Item { get; set; }
        public virtual User Seller { get; set; }
        public virtual ICollection<TextMessage> TextMessages { get; set; }

        // added
        public TextMessage LastMessage { get; set; }
    }
}
