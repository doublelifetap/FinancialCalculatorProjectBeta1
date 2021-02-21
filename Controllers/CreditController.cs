using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.VisualBasic;
using PartyInvites.Models;

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
        public IActionResult CreditCalc(double CreditAmount, double CreditTermMonths, double InterestRatePercentage, bool? AnualOrDecreasingInstallments, double? PromotionalPeriodMonths, double? PromotionalInterestPercentage,
            double? GratisPeriodMonths, double? ApplicationFee, bool? ApplicationFeeFlatOrPercentage, double? FilingFee, bool? FilingFeeFlatOrPercentage, double? OtherFee,
            bool? OtherFeeFlatOrPercentage, double? AnnualAdminFee, bool? AnnualAdminFeeFlatOrPercentage, double? OtherAnnualFee, bool? OtherAnnualFeeFlatOrPercentage, double? MonthlyAdminFee, double? OtherMonthlyFee,
            bool? MonthlyAdminFeeFlatOrPercentage, bool? OtherMonthlyFeeFlatOrPercentage, double monthlyInterest, double monthlyTax, double yearlyTax, double paidBackAlready, double montlyInterest)
        {
            try
            {
                CreditModel cm = new CreditModel(
                        creditAmount: CreditAmount,
                        creditTermMonths: CreditTermMonths,
                        interestRatePercentage: InterestRatePercentage,
                        anualOrDecreasingInstallments: AnualOrDecreasingInstallments,
                        promotionalPeriodMonths: PromotionalPeriodMonths,
                        promotionalInterestPercentage: PromotionalInterestPercentage,
                        gratisPeriodMonths: GratisPeriodMonths,
                        applicationFee: ApplicationFee,
                        applicationFeeFlatOrPercentage: ApplicationFeeFlatOrPercentage,
                        filingFee: FilingFee,
                        filingFeeFlatOrPercentage: FilingFeeFlatOrPercentage,
                        otherFee: OtherFee,
                        otherFeeFlatOrPercentage: OtherFeeFlatOrPercentage,
                        annualAdminFee: AnnualAdminFee,
                        annualAdminFeeFlatOrPercentage: AnnualAdminFeeFlatOrPercentage,
                        otherAnnualFee: OtherAnnualFee,
                        otherAnnualFeeFlatOrPercentage: OtherAnnualFeeFlatOrPercentage,
                        monthlyAdminFee: MonthlyAdminFee,
                        monthlyAdminFeeFlatOrPercentage: MonthlyAdminFeeFlatOrPercentage,
                        otherMonthlyFee: OtherMonthlyFee,
                        otherMonthlyFeeFlatOrPercentage: OtherMonthlyFeeFlatOrPercentage
                  );

                // Проверката не е нужна, всички числа се валидират през HTML, при въвеждане на негативно ще бъде показан popup глася
                // че това е невъзможно

                /* verifies all inputs are positive */
                //if (cm.CreditAmount < 0 || int.Parse(CreditTermMonths) < 0 || int.Parse(InterestRatePercentage) < 0 || int.Parse(PromotionalPeriodMonths) < 0 || int.Parse(PromotionalInterestPercentage) < 0
                //    || int.Parse(GratisPeriodMonths) < 0 || int.Parse(ApplicationFee) < 0 || int.Parse(FilingFee) < 0 || int.Parse(OtherFee) < 0 || int.Parse(AnnualAdminFee) < 0 || int.Parse(OtherAnnualFee) < 0
                //    || int.Parse(MonthlyAdminFee) < 0 || int.Parse(OtherMonthlyFee) < 0)
                //{
                //    ViewBag.NegNumError = "Моля въведете позитивни стойности";
                //}

                    
                    /* calculates if InitialFee has been selected as a percentage */

                    /* If installments are Annual */
                    if (cm.AnualOrDecreasingInstallments == true)
                    {
                        cm.InterestRatePercentage /= 100;
                        double remainingDueAmount = cm.CreditAmount;
                        cm.PromotionalInterestPercentage /= 100;

                    /*int InterestRatePercent = int.Parse(InterestRatePercentage);*/
                    /*double monthlyInterest;*/

                    /*Първоначални такси = Такса кандидатстване + Такса обработка + Други такси*/
                    double initialTax = (double)(cm.ApplicationFee + cm.FilingFee + cm.OtherFee);

                        /*Такса кандидатстване = Размера на кредита * Такса кандидатстване/100 (ако е в проценти)*/
                        if (cm.ApplicationFeeFlatOrPercentage == false)
                        {
                            cm.ApplicationFee = cm.CreditAmount * cm.ApplicationFee / 100;
                        }
                        /*Такса обработка = Размера на кредита * Такса обработка/100 (ако е в проценти)*/
                        if (FilingFeeFlatOrPercentage == false)
                        {
                            cm.FilingFee = cm.CreditAmount * cm.FilingFee / 100;
                        }
                        /*Други такси = Размера на кредита * Други такси/100 (ако е в проценти)*/
                        if (OtherFeeFlatOrPercentage == false)
                        {
                            cm.OtherFee = cm.CreditAmount * cm.OtherFee / 100;
                        }

                        /*========================================================================================================================*/
                        /*==============================================probl relocate============================================================*/
                        /*========================================================================================================================*/

                        /*Годишни такси = Годишна такса управление + Други годишни такси (таксуват се при първа вносна главница от следващата година)*/
                        double realAnnualTax = (double)(cm.AnnualAdminFee + cm.OtherAnnualFee);

                        /*Годишна такса управление = входа (ако е във валута)*/
                        /*Годишна такса управление = Първата вносна главница на следващата година * входа/100 (ако е в проценти)*/
                        if (AnnualAdminFeeFlatOrPercentage == false)
                        {
                            /*TODO ot sledvashta godina*/
                            cm.AnnualAdminFee = cm.CreditAmount * cm.AnnualAdminFee / 100;
                        }

                        /*Други годишни такси = Първата вносна главница на следващата година * входа/100 (ако е в проценти)*/
                        if (OtherAnnualFeeFlatOrPercentage == false)
                        {
                            /*TODO ot sledvashta godina*/
                            cm.OtherAnnualFee = cm.CreditAmount * cm.AnnualAdminFee / 100;
                        }

                        /*Месечни такси = Месечна такса управление + Други месечни такси (таксуват се всеки месец)*/
                        double realMonthlyTax = (double)(cm.MonthlyAdminFee + cm.OtherMonthlyFee);

                        if (MonthlyAdminFeeFlatOrPercentage == false)
                        {
                            /*TODO creditAmount/creditTermMonths =SHOULD BE= VnosnaGlavnitsa/monthlyPayback*/
                            cm.MonthlyAdminFee = (cm.CreditAmount / cm.CreditTermMonths) * cm.MonthlyAdminFee / 100;
                        }

                        if (OtherMonthlyFeeFlatOrPercentage == false)
                        {
                            /*TODO creditAmount/creditTermMonths == VnosnaGlavnitsa/monthlyPayback*/
                            cm.OtherMonthlyFee = (cm.CreditAmount / cm.CreditTermMonths) * cm.OtherMonthlyFee / 100;
                        }

                        /*========================================================================================================================*/
                        /*========================================================================================================================*/
                        /*========================================================================================================================*/

                        while (cm.CreditTermMonths > 0)
                        {
                            /*if still in Gratis Period*/
                            while (cm.GratisPeriodMonths > 0)
                            {
                                /*TODO check if gratis period does not surpass credit term as validation*/

                                cm.GratisPeriodMonths--;
                                cm.CreditTermMonths--;
                            }

                            /*Ако все още планът е в промоционалния период, то:*/
                            if (cm.PromotionalPeriodMonths != 0)
                            {
                                /*Месечната лихва = Остатъкът по главницата * Промоционалната лихва/12 */
                                monthlyInterest = (double)(remainingDueAmount * cm.PromotionalInterestPercentage / 12);

                                cm.PromotionalPeriodMonths--;
                            }
                            /*Ако планът вече не е в промоционален период, то:*/
                            else
                            {
                                /* Месечната лихва = Остатъкът по главницата * Лихвата / 12*/
                                montlyInterest = remainingDueAmount * cm.InterestRatePercentage / 12;
                            }


                            /*Месечна вноска = Financial.Pmt(Промоционалната лихва / 12, Срокът месеци - текущия месец, -Остатъкът по главницата)(за анюитетни вноски)*/
                            double monthlyPayTotal = Financial.Pmt((double)(cm.PromotionalInterestPercentage / 12), cm.CreditTermMonths, -remainingDueAmount);
                            /*Вноската по главницата = Месечната вноска - Месечната лихва (за анюитетни вноски)*/
                            double monthlyPayback = monthlyPayTotal - monthlyInterest;
                            /* Остатъкът по главницата = Остатъкът по главницата -Вноската по главницата*/
                            remainingDueAmount -= monthlyPayback;

                            /*Месечната такса = Месечните такси за управление + Други месечни такси (анюитетни)*/
                            monthlyTax = (double)(cm.MonthlyAdminFee + cm.OtherMonthlyFee);

                            /*Годишната такса = Годишните такси за управление + Други годишни такси (анюитетни)*/
                            yearlyTax = (double)(cm.AnnualAdminFee + cm.OtherAnnualFee);

                            paidBackAlready = monthlyPayTotal + monthlyTax + yearlyTax;

                            cm.CreditTermMonths--;
                        }

                        ViewBag.monthlyTax = monthlyTax;
                        ViewBag.yearlyTax = yearlyTax;

                        ViewBag.interestRate = cm.InterestRatePercentage;

                        ViewBag.paidBack = paidBackAlready;
                        ViewBag.montlyInterest = montlyInterest;

                        return View();
                    }

                    /*If Decreasing*/
                    else if (AnualOrDecreasingInstallments == false)
                    {

                        cm.InterestRatePercentage /= 100;
                        double remainingDueAmount = cm.CreditAmount;
                        //int promotionalInterestPercent = int.Parse(PromotionalInterestPercentage);
                        cm.PromotionalInterestPercentage /= 100;
                        /*int InterestRatePercent = int.Parse(InterestRatePercentage);*/
                        /*double monthlyInterest;*/

                        /*Такса кандидатстване = Размера на кредита * Такса кандидатстване/100 (ако е в проценти)*/
                        if (ApplicationFeeFlatOrPercentage == false)
                        {
                            cm.ApplicationFee = cm.CreditAmount * cm.ApplicationFee / 100;
                        }
                        /*Такса обработка = Размера на кредита * Такса обработка/100 (ако е в проценти)*/
                        if (FilingFeeFlatOrPercentage == false)
                        {
                            cm.FilingFee = cm.CreditAmount * cm.FilingFee / 100;
                        }
                        /*Други такси = Размера на кредита * Други такси/100 (ако е в проценти)*/
                        if (OtherFeeFlatOrPercentage == false)
                        {
                            cm.OtherFee = cm.CreditAmount * cm.OtherFee / 100;
                        }

                        if (cm.CreditTermMonths > 0)
                        {
                            /*if still in Gratis Period*/
                            if (cm.GratisPeriodMonths > 0)
                            {
                                /*TODO check if gratis period does not surpass credit term as validation*/

                                cm.GratisPeriodMonths--;
                                cm.CreditTermMonths--;
                            }

                            /* вноска по главницата за намаляващи вноски (гратисния период е приключил) - Вноската по главницата = Размера на кредита / (Срок месеци - Гратисен период) */
                            double monthlyPayback = cm.CreditAmount / (cm.CreditTermMonths);
                            /* Остатъкът по главницата = Остатъкът по главницата -Вноската по главницата*/
                            remainingDueAmount -= monthlyPayback;

                            /*Ако все още планът е в промоционалния период, то:*/
                            if (cm.PromotionalPeriodMonths != 0)
                            {
                                /*Месечната лихва = Остатъкът по главницата * Промоционалната лихва/12 */
                                monthlyInterest = (double)(remainingDueAmount * cm.PromotionalInterestPercentage / 12);

                                cm.PromotionalPeriodMonths--;
                            }
                            /*Ако планът вече не е в промоционален период, то:*/
                            else
                            {
                                /*TEMP Fix, non 0 output*/
                                cm.PromotionalInterestPercentage = 1;
                                /* Месечната лихва = Остатъкът по главницата * Лихвата / 12*/
                                montlyInterest = remainingDueAmount * cm.InterestRatePercentage / 12;
                            }

                            /*Месечна вноска = Вноската по главницата + Месечната лихва (за намаляващи вноски)*/
                            double monthlyPayTotal = monthlyPayback + monthlyInterest;

                            /*Месечните такси*/
                            monthlyTax = (double)(remainingDueAmount * cm.MonthlyAdminFee + remainingDueAmount * cm.OtherMonthlyFee);

                            /*Годишните такси*/
                            /*!!!!! ЗАДАДЕНО КАТО - Годишната такса = Остатъкът по главницата * Месечните такси за управление + Остатъкът по главницата * Други месечни такси (намаляващи)*/
                            yearlyTax = (double)(remainingDueAmount * cm.AnnualAdminFee + remainingDueAmount * cm.OtherAnnualFee);

                            paidBackAlready = monthlyPayTotal + monthlyTax + yearlyTax;

                            cm.CreditTermMonths--;
                        }

                        ViewBag.monthlyTax = monthlyTax;
                        ViewBag.yearlyTax = yearlyTax;

                        ViewBag.paidBack = paidBackAlready;
                        ViewBag.MontlyInterest = montlyInterest;

                        return View();
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