using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public class MsgDTO
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string TextMessage1 { get; set; }
        public DateTime SentTime { get; set; }
        public virtual TradeChat Chat { get; set; }
        public virtual User Sender { get; set; }

        public MsgDTO(TextMessage message)
        {
            this.TextMessage1 = message.TextMessage1;
            this.MessageId = message.MessageId;
            this.SenderId = message.SenderId;
            this.Sender = message.Sender;
            this.Chat = message.Chat;
            this.SentTime = message.SentTime;
            this.ChatId = message.ChatId;
        }
    }
}
