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
        public double? PromotionalPeriodMonths { get; set; }
        public double? PromotionalInterestPercentage { get; set; }
        public double? GratisPeriodMonths { get; set; }
        
        /* Taxes Values */

        /* Initial Taxes Values */
        public double? ApplicationFee { get; set; }
        public bool? ApplicationFeeFlatOrPercentage { get; set; }
        public double? FilingFee { get; set; }
        public bool? FilingFeeFlatOrPercentage { get; set; }
        public double? OtherFee { get; set; }
        public bool? OtherFeeFlatOrPercentage { get; set; }
        /* Initial Taxes Values End*/

        /* Annual Taxes Values */
        public double? AnnualAdminFee { get; set; }
        public bool? AnnualAdminFeeFlatOrPercentage { get; set; }
        public double? OtherAnnualFee { get; set; }
        public bool? OtherAnnualFeeFlatOrPercentage { get; set; }
        /* Annual Taxes Values End*/

        /* Monthly Taxes Values */
        public double? MonthlyAdminFee { get; set; }
        public bool? MonthlyAdminFeeFlatOrPercentage { get; set; }
        public double? OtherMonthlyFee { get; set; }
        public bool? OtherMonthlyFeeFlatOrPercentage { get; set; }

        public CreditModel(double creditAmount,
                           double creditTermMonths,
                           double interestRatePercentage,
                           bool? anualOrDecreasingInstallments,
                           double? promotionalPeriodMonths,
                           double? promotionalInterestPercentage,
                           double? gratisPeriodMonths,
                           double? applicationFee,
                           bool? applicationFeeFlatOrPercentage,
                           double? filingFee,
                           bool? filingFeeFlatOrPercentage,
                           double? otherFee,
                           bool? otherFeeFlatOrPercentage,
                           double? annualAdminFee,
                           bool? annualAdminFeeFlatOrPercentage,
                           double? otherAnnualFee,
                           bool? otherAnnualFeeFlatOrPercentage,
                           double? monthlyAdminFee,
                           bool? monthlyAdminFeeFlatOrPercentage,
                           double? otherMonthlyFee,
                           bool? otherMonthlyFeeFlatOrPercentage)
        {
            CreditAmount = creditAmount;
            CreditTermMonths = creditTermMonths;
            InterestRatePercentage = interestRatePercentage;
            AnualOrDecreasingInstallments = anualOrDecreasingInstallments ?? true;
            PromotionalPeriodMonths = promotionalPeriodMonths ?? 0.0;
            PromotionalInterestPercentage = promotionalInterestPercentage ?? 0.0;
            GratisPeriodMonths = gratisPeriodMonths ?? 0.0;
            ApplicationFee = applicationFee ?? 0.0;
            ApplicationFeeFlatOrPercentage = applicationFeeFlatOrPercentage ?? true;
            FilingFee = filingFee ?? 0.0;
            FilingFeeFlatOrPercentage = filingFeeFlatOrPercentage ?? true;
            OtherFee = otherFee ?? 0.0;
            OtherFeeFlatOrPercentage = otherFeeFlatOrPercentage ?? true;
            AnnualAdminFee = annualAdminFee ?? 0.0;
            AnnualAdminFeeFlatOrPercentage = annualAdminFeeFlatOrPercentage ?? true;
            OtherAnnualFee = otherAnnualFee ?? 0.0;
            OtherAnnualFeeFlatOrPercentage = otherAnnualFeeFlatOrPercentage ?? true;
            MonthlyAdminFee = monthlyAdminFee ?? 0.0;
            MonthlyAdminFeeFlatOrPercentage = monthlyAdminFeeFlatOrPercentage ?? true;
            OtherMonthlyFee = otherMonthlyFee ?? 0.0;
            OtherMonthlyFeeFlatOrPercentage = otherMonthlyFeeFlatOrPercentage ?? true;
        }
        /* Monthly Taxes Values End*/



    }
}
