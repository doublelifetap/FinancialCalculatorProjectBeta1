using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{

    public class RefinanceModel
    {

        /* Credit Calculator Values */
        public double CreditAmount { get; set; }
        public double CreditTermMonths { get; set; }
        public double InterestRatePercentage { get; set; }
        public int NumberOfPaymentsMade { get; set; }

        /* Credit Calculator Values */
        public double EarlyRepaymentTax { get; set; }

        /* New Credit Values */
        public double InterestRate { get; set; }
        public double InitialTaxes { get; set; }
        public bool? InitialTaxesFlatOrPercentage { get; set; }

        public RefinanceModel(double creditAmount,
                              double creditTermMonths,
                              double interestRatePercentage,
                              int numberOfPaymentsMade,
                              double earlyRepaymentTax,
                              double interestRate,
                              double initialTaxes,
                              bool? initialTaxesFlatOrPercentage)
        {
            CreditAmount = creditAmount;
            CreditTermMonths = creditTermMonths;
            InterestRatePercentage = interestRatePercentage;
            NumberOfPaymentsMade = numberOfPaymentsMade;
            EarlyRepaymentTax = earlyRepaymentTax;
            InterestRate = interestRate;
            InitialTaxes = initialTaxes;
            InitialTaxesFlatOrPercentage = initialTaxesFlatOrPercentage ?? true;
        }
    }
}