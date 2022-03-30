using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Hand2TradeAP.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int RatedUserId { get; set; }
        public int SenderId { get; set; }
        public double Rate { get; set; }
    }
}
