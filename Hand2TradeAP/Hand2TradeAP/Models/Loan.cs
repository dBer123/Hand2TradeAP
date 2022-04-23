using System;
using System.Collections.Generic;
using System.Text;

namespace Hand2TradeAP.Models
{
    internal class Loan
    {
        public int LoanId { get; set; }
        public int LoanerId { get; set; }
        public int Debt { get; set; }
        public bool IsDebtPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
