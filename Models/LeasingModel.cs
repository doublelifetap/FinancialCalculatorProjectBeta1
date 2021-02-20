using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class LeasingModel
    {
        public double LeaseAmount { get; set; }
        public double InitialPayment { get; set; }
        public double LeasePeriodMonths { get; set; }
        public double MonthlyPayments { get; set; }
        public double InitialFilingFee { get; set; }

        public bool? FlatOrPercent { get; set; }

        /*public double LeasingValue3 { get; set; }
        public double LeasingTotalResult { get; set; }
        public string LeasingAdvice { get; set; }*/
    }
}
