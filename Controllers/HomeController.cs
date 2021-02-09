using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers {
    public class HomeController : Controller {
        
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public ViewResult RefinanceCalc()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult RefinanceCalc(RefinanceModel RefinancingModel, string calculate)
        {
            if (calculate == "refinance")
            {
                RefinancingModel.RefinanceResult = RefinancingModel.Value1 + RefinancingModel.Value2 + RefinancingModel.Value3;
            }
            else
            {
                RefinancingModel.RefinanceResult = RefinancingModel.Value1 + RefinancingModel.Value2 - RefinancingModel.Value3;
            }

            ViewBag.RefinanceResultOne = RefinancingModel.RefinanceResult;

            return View(RefinancingModel);

            /* if (calculate == "refinance")
            {
                RefinancingModel.CalculateResult();
            }
            else
            {
                RefinancingModel.RefinanceResult = RefinancingModel.Value1 + RefinancingModel.Value2 - RefinancingModel.Value3;
            }

            return View(RefinancingModel);
            */

            /*FOR VIEW: @{ if (@Model.RefinanceResult != null)
                        {
            @Model.RefinanceResult.ToString() } }*/
        }
         
        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse) {
            if (ModelState.IsValid) {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else {
                return View();
            }
        }

        public ViewResult ListResponses() {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
