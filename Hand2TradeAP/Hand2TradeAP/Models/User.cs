using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public partial class User
    {
        public string Email { get; set; }
        public string Passwrd { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public int Coins { get; set; }
        public int Reports { get; set; }       
        public int TotalRank { get; set; }
        public DateTime BearthDate { get; set; }
        public string Adress { get; set; }
        public bool IsBlocked { get; set; }
        
    }
}
