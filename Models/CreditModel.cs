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

        // Добавете default стойности за всички (optional) полета,
        // За да може да не са null и да не се влиза в exception при изчисления

        public CreditModel(double creditAmount,
                           double creditTermMonths,
                           double interestRatePercentage,
                           bool? anualOrDecreasingInstallments,
                           double promotionalPeriodMonths,
                           double promotionalInterestPercentage,
                           double gratisPeriodMonths,
                           double applicationFee,
                           bool? applicationFeeFlatOrPercentage,
                           double filingFee,
                           bool? filingFeeFlatOrPercentage,
                           double otherFee,
                           bool? otherFeeFlatOrPercentage,
                           double annualAdminFee,
                           bool? annualAdminFeeFlatOrPercentage,
                           double otherAnnualFee,
                           bool? otherAnnualFeeFlatOrPercentage,
                           double monthlyAdminFee,
                           bool? monthlyAdminFeeFlatOrPercentage,
                           double otherMonthlyFee,
                           bool? otherMonthlyFeeFlatOrPercentage)
        {
            CreditAmount = creditAmount;
            CreditTermMonths = creditTermMonths;
            InterestRatePercentage = interestRatePercentage;
            AnualOrDecreasingInstallments = anualOrDecreasingInstallments;
            PromotionalPeriodMonths = promotionalPeriodMonths;
            PromotionalInterestPercentage = promotionalInterestPercentage;
            GratisPeriodMonths = gratisPeriodMonths;
            ApplicationFee = applicationFee;
            ApplicationFeeFlatOrPercentage = applicationFeeFlatOrPercentage;
            FilingFee = filingFee;
            FilingFeeFlatOrPercentage = filingFeeFlatOrPercentage;
            OtherFee = otherFee;
            OtherFeeFlatOrPercentage = otherFeeFlatOrPercentage;
            AnnualAdminFee = annualAdminFee;
            AnnualAdminFeeFlatOrPercentage = annualAdminFeeFlatOrPercentage;
            OtherAnnualFee = otherAnnualFee;
            OtherAnnualFeeFlatOrPercentage = otherAnnualFeeFlatOrPercentage;
            MonthlyAdminFee = monthlyAdminFee;
            MonthlyAdminFeeFlatOrPercentage = monthlyAdminFeeFlatOrPercentage;
            OtherMonthlyFee = otherMonthlyFee;
            OtherMonthlyFeeFlatOrPercentage = otherMonthlyFeeFlatOrPercentage;
        }
        /* Monthly Taxes Values End*/



    }
}
