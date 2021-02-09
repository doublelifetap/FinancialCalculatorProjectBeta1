using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{

    public class RefinanceModel
    {

        [Required(ErrorMessage = "Please enter first value")]
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