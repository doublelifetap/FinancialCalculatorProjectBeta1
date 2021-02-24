using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PartyInvites.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PartyInvites.UnitTest.Controllers
{
    [TestClass]
    public class LeasingControllerTest
    {
        [TestMethod]
        public void LeaseCalc()
        {
            //Arrange
            LeasingController controller = new LeasingController();

            //Act
            ViewResult result = controller.LeaseCalc() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


        //public IActionResult LeaseCalc(string LeaseAmount, string InitialPayment, string LeasePeriodMonths, string MonthlyPayments, string InitialFilingFee, bool FlatOrPercent)
        [TestMethod]
        public void LeaseCalcFlat()
        {
            //Arrange
            string LeaseAmount = "10000";
            string InitialPayment = "1000";
            string LeasePeriodMonths = "60";
            string MonthlyPayments = "200";
            string InitialFilingFee = "100";
            bool FlatOrPercent = true;

            decimal expectedResultGPR = 13.18m;
            double expectedResultTotalPaidWithTaxes = 13100;
            double expectedResultTotalTaxes = 100;

            LeasingController controller = new LeasingController();

            //Act
            ViewResult result = controller.LeaseCalc(LeaseAmount, InitialPayment, LeasePeriodMonths, MonthlyPayments, 
                InitialFilingFee, FlatOrPercent) as ViewResult;

            //Assert
            Assert.AreEqual(expectedResultGPR, result.ViewData["GPR"]);
            Assert.AreEqual(expectedResultTotalPaidWithTaxes, result.ViewData["totalPaidWithTaxes"]);
            Assert.AreEqual(expectedResultTotalTaxes, result.ViewData["totalTaxes"]);
        }

        [TestMethod]
        public void LeaseCalcPercent()
        {
            //Arrange
            string LeaseAmount = "10000";
            string InitialPayment = "1000";
            string LeasePeriodMonths = "60";
            string MonthlyPayments = "200";
            string InitialFilingFee = "1";
            bool FlatOrPercent = false;

            decimal expectedResultGPR = 13.18m;
            double expectedResultTotalPaidWithTaxes = 13100;
            double expectedResultTotalTaxes = 100;

            LeasingController controller = new LeasingController();

            //Act
            ViewResult result = controller.LeaseCalc(LeaseAmount, InitialPayment, LeasePeriodMonths, MonthlyPayments,
                InitialFilingFee, FlatOrPercent) as ViewResult;

            //Assert
            Assert.AreEqual(expectedResultGPR, result.ViewData["GPR"]);
            Assert.AreEqual(expectedResultTotalPaidWithTaxes, result.ViewData["totalPaidWithTaxes"]);
            Assert.AreEqual(expectedResultTotalTaxes, result.ViewData["totalTaxes"]);
        }
    }
}
