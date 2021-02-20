using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace PartyInvites.Controllers
{
    public class CreditController : Controller
    {
        [HttpGet]
        public IActionResult CreditCalc()
        {
            return View();
        }

        [HttpPost]
        /*TODO: Set float point precision for outputs; Go over validation and required fields; Fix calc algorythm*/
        //public IActionResult Index(LeasingModel LeasingModel, string calculate)
        public IActionResult CreditCalc(string CreditAmount, string CreditTermMonths, string InterestRatePercentage, bool AnualOrDecreasingInstallments, string PromotionalPeriodMonths, string PromotionalInterestPercentage,
            string GratisPeriodMonths, string ApplicationFee, bool ApplicationFeeFlatOrPercentage, string FilingFee, bool FilingFeeFlatOrPercentage, string OtherFee,
            bool OtherFeeFlatOrPercentage, string AnnualAdminFee, bool AnnualAdminFeeFlatOrPercentage, string OtherAnnualFee, bool OtherAnnualFeeFlatOrPercentage, string MonthlyAdminFee, string OtherMonthlyFee,
            bool MonthlyAdminFeeFlatOrPercentage, bool OtherMonthlyFeeFlatOrPercentage, double monthlyInterest, double monthlyTax, double yearlyTax, double paidBackAlready, double montlyInterest)
        {
            try
            {
                /* verifies all inputs are positive */
                if (int.Parse(CreditAmount) < 0 || int.Parse(CreditTermMonths) < 0 || int.Parse(InterestRatePercentage) < 0 || int.Parse(PromotionalPeriodMonths) < 0 || int.Parse(PromotionalInterestPercentage) < 0
                    || int.Parse(GratisPeriodMonths) < 0 || int.Parse(ApplicationFee) < 0 || int.Parse(FilingFee) < 0 || int.Parse(OtherFee) < 0 || int.Parse(AnnualAdminFee) < 0 || int.Parse(OtherAnnualFee) < 0
                    || int.Parse(MonthlyAdminFee) < 0 || int.Parse(OtherMonthlyFee) < 0)

                { 
                    ViewBag.NegNumError = "Моля въведете позитивни стойности";
                }

                else
                {

                    double creditAmount = double.Parse(CreditAmount);
                    int creditTermMonths = int.Parse(CreditTermMonths);
                    int interestRatePercent = int.Parse(InterestRatePercentage);
                    double promotionalPeriodMonths = double.Parse(PromotionalPeriodMonths);
                    int promotionalInterestPercentage = int.Parse(PromotionalInterestPercentage);

                    double gratisPeriodMonths = double.Parse(GratisPeriodMonths);
                    double applicationFee = double.Parse(ApplicationFee);
                    double filingFee = double.Parse(FilingFee);
                    double otherFee = double.Parse(OtherFee);

                    double annualAdminFee = double.Parse(AnnualAdminFee);
                    double otherAnnualFee = double.Parse(OtherAnnualFee);

                    double monthlyAdminFee = double.Parse(MonthlyAdminFee);
                    double otherMonthlyFee = double.Parse(OtherMonthlyFee);


                    /* calculates if InitialFee has been selected as a percentage */

                    /* If installments are Annual */
                    if (AnualOrDecreasingInstallments == true)
                    {
                        interestRatePercent /= 100;
                        double remainingDueAmount = creditAmount;
                        int promotionalInterestPercent = int.Parse(PromotionalInterestPercentage);
                        promotionalInterestPercentage /= 100;
                        /*int InterestRatePercent = int.Parse(InterestRatePercentage);*/
                        /*double monthlyInterest;*/

                        /*Първоначални такси = Такса кандидатстване + Такса обработка + Други такси*/
                        double initialTax = applicationFee + filingFee + otherFee;

                        /*Такса кандидатстване = Размера на кредита * Такса кандидатстване/100 (ако е в проценти)*/
                        if (ApplicationFeeFlatOrPercentage == false) {
                            applicationFee = creditAmount * applicationFee / 100;
                        }
                        /*Такса обработка = Размера на кредита * Такса обработка/100 (ако е в проценти)*/
                        if (FilingFeeFlatOrPercentage == false)
                        {
                            filingFee = creditAmount * filingFee / 100;
                        }
                        /*Други такси = Размера на кредита * Други такси/100 (ако е в проценти)*/
                        if (OtherFeeFlatOrPercentage == false)
                        {
                            otherFee = creditAmount * otherFee / 100;
                        }

                        /*========================================================================================================================*/
                        /*==============================================probl relocate============================================================*/
                        /*========================================================================================================================*/

                        /*Годишни такси = Годишна такса управление + Други годишни такси (таксуват се при първа вносна главница от следващата година)*/
                        double realAnnualTax = annualAdminFee + otherAnnualFee;

                        /*Годишна такса управление = входа (ако е във валута)*/
                        /*Годишна такса управление = Първата вносна главница на следващата година * входа/100 (ако е в проценти)*/
                        if (AnnualAdminFeeFlatOrPercentage == false)
                        {
                            /*TODO ot sledvashta godina*/
                            annualAdminFee = creditAmount * annualAdminFee / 100;
                        }

                        /*Други годишни такси = Първата вносна главница на следващата година * входа/100 (ако е в проценти)*/
                        if (OtherAnnualFeeFlatOrPercentage == false)
                        {
                            /*TODO ot sledvashta godina*/
                            otherAnnualFee = creditAmount * annualAdminFee / 100;
                        }

                        /*Месечни такси = Месечна такса управление + Други месечни такси (таксуват се всеки месец)*/
                        double realMonthlyTax = monthlyAdminFee + otherMonthlyFee;

                        if (MonthlyAdminFeeFlatOrPercentage == false)
                        {
                            /*TODO creditAmount/creditTermMonths =SHOULD BE= VnosnaGlavnitsa/monthlyPayback*/
                            monthlyAdminFee = (creditAmount/creditTermMonths) * monthlyAdminFee / 100;
                        }

                        if (OtherMonthlyFeeFlatOrPercentage == false)
                        {
                            /*TODO creditAmount/creditTermMonths == VnosnaGlavnitsa/monthlyPayback*/
                            otherMonthlyFee = (creditAmount / creditTermMonths) * otherMonthlyFee / 100;
                        }

                        /*========================================================================================================================*/
                        /*========================================================================================================================*/
                        /*========================================================================================================================*/

                        while (creditTermMonths > 0)
                        {
                            /*if still in Gratis Period*/
                            while (gratisPeriodMonths > 0)
                            {
                                /*TODO check if gratis period does not surpass credit term as validation*/

                                gratisPeriodMonths--;
                                creditTermMonths--;
                            }
                            
                            /*Ако все още планът е в промоционалния период, то:*/
                            if (promotionalPeriodMonths != 0)
                            {
                                /*Месечната лихва = Остатъкът по главницата * Промоционалната лихва/12 */
                                monthlyInterest = remainingDueAmount * promotionalInterestPercent / 12;

                                promotionalPeriodMonths--;
                            }
                            /*Ако планът вече не е в промоционален период, то:*/
                            else
                            {
                                /* Месечната лихва = Остатъкът по главницата * Лихвата / 12*/
                                montlyInterest = remainingDueAmount * interestRatePercent / 12;
                            }


                            /*Месечна вноска = Financial.Pmt(Промоционалната лихва / 12, Срокът месеци - текущия месец, -Остатъкът по главницата)(за анюитетни вноски)*/
                            double monthlyPayTotal = Financial.Pmt(promotionalInterestPercent / 12, creditTermMonths, -remainingDueAmount);
                            /*Вноската по главницата = Месечната вноска - Месечната лихва (за анюитетни вноски)*/
                            double monthlyPayback = monthlyPayTotal - monthlyInterest;
                            /* Остатъкът по главницата = Остатъкът по главницата -Вноската по главницата*/
                            remainingDueAmount -= monthlyPayback;

                            /*Месечната такса = Месечните такси за управление + Други месечни такси (анюитетни)*/
                            monthlyTax = monthlyAdminFee + otherMonthlyFee;

                            /*Годишната такса = Годишните такси за управление + Други годишни такси (анюитетни)*/
                            yearlyTax = annualAdminFee + otherAnnualFee;

                            paidBackAlready = monthlyPayTotal + monthlyTax + yearlyTax;

                            creditTermMonths--;
                        }

                        ViewBag.monthlyTax = 8000;
                        ViewBag.yearlyTax = yearlyTax;

                        ViewBag.interestRate = interestRatePercent;

                        ViewBag.paidBack = paidBackAlready;
                        ViewBag.MontlyInterest = montlyInterest;

                        return View();
                    }

                    /*If Decreasing*/
                    else if (AnualOrDecreasingInstallments == false) {

                        interestRatePercent /= 100;
                        double remainingDueAmount = creditAmount;
                        int promotionalInterestPercent = int.Parse(PromotionalInterestPercentage);
                        promotionalInterestPercentage /= 100;
                        /*int InterestRatePercent = int.Parse(InterestRatePercentage);*/
                        /*double monthlyInterest;*/

                        /*Такса кандидатстване = Размера на кредита * Такса кандидатстване/100 (ако е в проценти)*/
                        if (ApplicationFeeFlatOrPercentage == false)
                        {
                            applicationFee = creditAmount * applicationFee / 100;
                        }
                        /*Такса обработка = Размера на кредита * Такса обработка/100 (ако е в проценти)*/
                        if (FilingFeeFlatOrPercentage == false)
                        {
                            filingFee = creditAmount * filingFee / 100;
                        }
                        /*Други такси = Размера на кредита * Други такси/100 (ако е в проценти)*/
                        if (OtherFeeFlatOrPercentage == false)
                        {
                            otherFee = creditAmount * otherFee / 100;
                        }

                        while (creditTermMonths > 0)
                        {
                            /*if still in Gratis Period*/
                            while (gratisPeriodMonths > 0)
                            {
                                /*TODO check if gratis period does not surpass credit term as validation*/

                                gratisPeriodMonths--;
                                creditTermMonths--;
                            }

                            /* вноска по главницата за намаляващи вноски (гратисния период е приключил) - Вноската по главницата = Размера на кредита / (Срок месеци - Гратисен период) */
                            double monthlyPayback = creditAmount / (creditTermMonths);
                            /* Остатъкът по главницата = Остатъкът по главницата -Вноската по главницата*/
                            remainingDueAmount -= monthlyPayback;

                            /*Ако все още планът е в промоционалния период, то:*/
                            if (promotionalPeriodMonths != 0)
                            {
                                /*Месечната лихва = Остатъкът по главницата * Промоционалната лихва/12 */
                                monthlyInterest = remainingDueAmount * promotionalInterestPercent / 12;

                                promotionalPeriodMonths--;
                            }
                            /*Ако планът вече не е в промоционален период, то:*/
                            else
                            {
                                /*TEMP Fix, non 0 output*/
                                promotionalInterestPercent = 1;
                                /* Месечната лихва = Остатъкът по главницата * Лихвата / 12*/
                                montlyInterest = remainingDueAmount * interestRatePercent / 12;
                            }

                            /*Месечна вноска = Вноската по главницата + Месечната лихва (за намаляващи вноски)*/
                            double monthlyPayTotal = monthlyPayback + monthlyInterest;

                            /*Месечните такси*/
                            monthlyTax = remainingDueAmount * monthlyAdminFee + remainingDueAmount * otherMonthlyFee;

                            /*Годишните такси*/
                            /*!!!!! ЗАДАДЕНО КАТО - Годишната такса = Остатъкът по главницата * Месечните такси за управление + Остатъкът по главницата * Други месечни такси (намаляващи)*/
                            yearlyTax = remainingDueAmount * annualAdminFee + remainingDueAmount * otherAnnualFee;

                            paidBackAlready = monthlyPayTotal + monthlyTax + yearlyTax;

                            creditTermMonths--;
                        }

                        ViewBag.monthlyTax = monthlyTax;
                        ViewBag.yearlyTax = yearlyTax;

                        ViewBag.paidBack = paidBackAlready;
                        ViewBag.MontlyInterest = montlyInterest;

                        return View();
                    }
                }

            }

            /* Not all fields are required?*/
            catch (ArgumentNullException ex)
            {
                string emptyValueError = ex.Message;
                ViewBag.ErrorMessageEmpty = "Моля въведете числени стойности и опитайте отново!";
            }

            catch (FormatException ex)
            {
                string formatError = ex.Message;
                ViewBag.ErrorFormat = "Моля въведете числени стойности и опитайте отново!";
            }


            return View();
            /* if (lease == "calculate")
            {
                //LeasingModel.LeasingTotalResult = LeasingModel.LeasingValue1 + LeasingModel.LeasingValue2 + LeasingModel.LeasingValue3;
            }
            else
            {
               // LeasingModel.LeasingTotalResult = LeasingModel.LeasingValue1 + LeasingModel.LeasingValue2 - LeasingModel.LeasingValue3;
            }

            return View(LeasingModel);*/

        }

    }
}