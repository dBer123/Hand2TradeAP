using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public class TextMessage
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string TextMessage1 { get; set; }
        public DateTime SentTime { get; set; }
        public virtual TradeChat Chat { get; set; }
        public virtual User Sender { get; set; }
        public static int LoggedInAccountId { get => ((App)App.Current).CurrentUser.UserId; }

    }
}
