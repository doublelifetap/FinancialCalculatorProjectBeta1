using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers {
    public class HomeController : Controller {
        
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public ViewResult CalcHome()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CalcHom()
        {
            return View();
        }
         
    }
}
