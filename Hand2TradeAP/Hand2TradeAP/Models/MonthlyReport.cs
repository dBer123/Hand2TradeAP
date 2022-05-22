using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    public class MonthlyReport
    {
        public int MonthlyReportId { get; set; }
        public DateTime DateOfMonth { get; set; }
        public int NewSubs { get; set; }
        public int ItemsTraded { get; set; }
        public int LoansTaken { get; set; }
        public int LoansDeptPaid { get; set; }
        public int ReportsNum { get; set; }
    }
}
