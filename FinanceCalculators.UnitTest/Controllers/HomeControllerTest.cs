using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartyInvites.Controllers;

namespace PartyInvites.UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RefinanceCalc()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.RefinanceCalc() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
