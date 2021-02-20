using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{

    public class RefinancingModel
    {
        /*Current Credit*/
        public double CreditAmount { get; set; }
        public double InterestRatePercent { get; set; }
        public double CreditTermMonths { get; set; }
        public double NumberOfPaymentsMade { get; set; }
        public double EarlyRepaymentTax { get; set; }

        /*New Credit*/
        public double NewCreditInterest { get; set; }
        public double NewCreditInitialTaxesPecent { get; set; }
        public double NewCreditInitialTaxesFlat { get; set; }




       /* [Required(ErrorMessage = "Please enter first value")]
        public int Value1 { get; set; }
        [Required(ErrorMessage = "Please enter second value")]
        public int Value2 { get; set; }
        [Required(ErrorMessage = "Please enter third value")]
        public int Value3 { get; set; }
        public int RefinanceResult { get; set; }
        public bool? AddOrSubstract { get; set; }

        /*public void CalculateResult(){
            RefinanceResult = Value1 + Value2 + Value3;
        }*/



    }
}
//<div asp-validation-summary="All"></div> to Ref Calc Top Body