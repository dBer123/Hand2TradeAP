using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public class DailyReport
    {
        public int DailyReportId { get; set; }
        public DateTime DayTime { get; set; }
        public int NewSubs { get; set; }
        public int ItemsDraded { get; set; }
        public int ReportsNum { get; set; }
    }
}
