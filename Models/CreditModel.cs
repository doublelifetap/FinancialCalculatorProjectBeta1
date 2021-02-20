using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class CreditModel
    {
        /* Credit Calculator Values */
        public double CreditAmount { get; set; }
        public double CreditTermMonths { get; set; }
        public double InterestRatePercentage { get; set; }
        public bool? AnualOrDecreasingInstallments { get; set; }

        /* Promotional Period Values */
        public double PromotionalPeriodMonths { get; set; }
        public double PromotionalInterestPercentage { get; set; }
        public double GratisPeriodMonths { get; set; }


        /* Taxes Values */
        
        /* Initial Taxes Values */
        public double ApplicationFee { get; set; }
        public bool? ApplicationFeeFlatOrPercentage { get; set; }
        public double FilingFee { get; set; }
        public bool? FilingFeeFlatOrPercentage { get; set; }
        public double OtherFee { get; set; }
        public bool? OtherFeeFlatOrPercentage { get; set; }
        /* Initial Taxes Values End*/
        
        /* Annual Taxes Values */
        public double AnnualAdminFee { get; set; }
        public bool? AnnualAdminFeeFlatOrPercentage { get; set; }
        public double OtherAnnualFee { get; set; }
        public bool? OtherAnnualFeeFlatOrPercentage { get; set; }
        /* Annual Taxes Values End*/
        
        /* Monthly Taxes Values */
        public double MonthlyAdminFee { get; set; }
        public bool? MonthlyAdminFeeFlatOrPercentage { get; set; }
        public double OtherMonthlyFee { get; set; }
        public bool? OtherMonthlyFeeFlatOrPercentage { get; set; }
        /* Monthly Taxes Values End*/

    }
}
