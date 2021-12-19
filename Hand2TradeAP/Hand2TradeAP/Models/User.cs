using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Hand2TradeAP.Models
{
    public partial class User
    {
        public string Email { get; set; }
        public string Passwrd { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public int Coins { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public bool IsBlocked { get; set; }
        public string CreditNum { get; set; }
        public string CVV { get; set; }
        public DateTime CardDate { get; set; }
        public int SumRanks { get; set; }
        public int CountRanked { get; set; }
        public virtual ICollection<Item> Items { get; set; }




    }
}
