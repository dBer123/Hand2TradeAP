using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public class HourlyReport
    {
        public int HourlyReportId { get; set; }
        public DateTime HourTime { get; set; }
        public int NewSubs { get; set; }
        public int ItemsDraded { get; set; }
        public int LoansTaken { get; set; }
        public int LoansDeptPaid { get; set; }
        public int ReportsNum { get; set; }
    }
}
