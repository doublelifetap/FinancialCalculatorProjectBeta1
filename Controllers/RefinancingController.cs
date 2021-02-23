using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PartyInvites.Controllers
{
    public class RefinancingController : Controller
    {
        [HttpGet]
        public IActionResult RefinanceCalc()
        {
            return View();
        }

        //public IActionResult Index(LeasingModel LeasingModel, string calculate)
        [HttpPost]

        public IActionResult RefinanceCalc(string CreditAmount, string InterestRatePercent, string CreditTermMonths, string NumberOfPaymentsMade, string EarlyRepaymentTax, string NewCreditInterest, string NewCreditInitialTaxesPecent)
        {
            try
            {
                /* verifies all inputs are positive */
                if (int.Parse(CreditAmount) < 0 || int.Parse(InterestRatePercent) < 0 || int.Parse(CreditTermMonths) < 0 || int.Parse(NumberOfPaymentsMade) < 0 || int.Parse(EarlyRepaymentTax) < 0 ||
                    int.Parse(NewCreditInterest) < 0 || int.Parse(NewCreditInitialTaxesPecent) < 0)
                {
                    ViewBag.NegNumError = "Please input positive numbers";
                }

                else
                {
                    /* calculates if InitialFee has been selected as a percentage */
                    /*if (FlatOrPercent == false)
                    {*/

                    double creditAmountDouble = double.Parse(CreditAmount);
                    double interestRateDouble = double.Parse(InterestRatePercent);
                    double creditTermMonthsDouble = double.Parse(CreditTermMonths);
                    double numberOfPaymentsMadeDouble = double.Parse(NumberOfPaymentsMade);
                    double earlyRepaymentTaxDouble = double.Parse(EarlyRepaymentTax);
                    double totalPaymentsMade = 0;

                    double newCreditInterestDouble = double.Parse(NewCreditInterest);
                    double newCreditInitialTaxesPecentDouble = double.Parse(NewCreditInitialTaxesPecent);
                    double newCreditPayment = 0;

                    double monthlyPayment = 0;
                    double realPayemnt = 0;

                    /*Лихви*/
                    double interestRate = interestRateDouble / 100;
                    double interesterRateNew = newCreditInterestDouble / 100;
                    double interestAmount = 0;

                    /*Оставащ срок*/
                    /* needs to be validated or NPer error */
                    double newTerm = creditTermMonthsDouble - numberOfPaymentsMadeDouble;

                    /*Такса за предсрочно погасяване*/
                    double remainingDueAmount = creditAmountDouble;

                    for (double i = 0; i <= numberOfPaymentsMadeDouble; i++)
                    {
                        remainingDueAmount -= realPayemnt;
                        interestAmount = remainingDueAmount * (interestRate / 12);
                        monthlyPayment = Microsoft.VisualBasic.Financial.Pmt(interestRate / 12, creditTermMonthsDouble, -creditAmountDouble);
                        realPayemnt = monthlyPayment - interestAmount;
                    }

                    earlyRepaymentTaxDouble = remainingDueAmount * (earlyRepaymentTaxDouble / 100);

                    /*Месечна вноска за текущ кредит*/
                    double monthlyPaymentCurrentCredit = Microsoft.VisualBasic.Financial.Pmt(interestRate / 12, creditTermMonthsDouble, -creditAmountDouble);

                    /*Общо изплатени за текущ кредит*/
                    totalPaymentsMade = monthlyPaymentCurrentCredit * numberOfPaymentsMadeDouble;

                    /*Месечна вноска за нов кредит*/
                    newCreditPayment = Microsoft.VisualBasic.Financial.Pmt(newCreditInterestDouble / 12, newTerm, -remainingDueAmount);

                    /*Общо изплатени за нов кредит*/
                    double newTotalPaymentsMade = (newCreditPayment * newTerm) + earlyRepaymentTaxDouble + (creditAmountDouble * (newCreditInitialTaxesPecentDouble / 100) + double.Parse(NewCreditInitialTaxesPecent));

                    /*Спестявания от вноски*/
                    double savingsPayments = monthlyPaymentCurrentCredit - newCreditPayment;

                    /*Спестявания от общо изплатени*/
                    double savingsTotal = totalPaymentsMade - newTotalPaymentsMade;

                    /*изходни*/
                    ViewBag.interestRate = Math.Round(interestRateDouble, 2, MidpointRounding.AwayFromZero);

                    //Math.Round(newTotalPaymentsMade, 2, MidpointRounding.AwayFromZero);

                    ViewBag.interestRateNew = Math.Round(newCreditInterestDouble, 2, MidpointRounding.AwayFromZero);

                    ViewBag.creditTermOld = Math.Round(creditTermMonthsDouble, 2, MidpointRounding.AwayFromZero);
                    ViewBag.creditTermNew = Math.Round(newTerm, 2, MidpointRounding.AwayFromZero);

                    ViewBag.earlyRepaymentTax = Math.Round(earlyRepaymentTaxDouble, 2, MidpointRounding.AwayFromZero);

                    ViewBag.monthlyPaymentOld = Math.Round(monthlyPaymentCurrentCredit, 2, MidpointRounding.AwayFromZero);
                    ViewBag.monthlyPaymentNew = Math.Round(newCreditPayment, 2, MidpointRounding.AwayFromZero);

                    ViewBag.monthlySavingsTotal = Math.Round((totalPaymentsMade - newTotalPaymentsMade), 2, MidpointRounding.AwayFromZero);

                    ViewBag.totalPaidOld = Math.Round(totalPaymentsMade, 2, MidpointRounding.AwayFromZero);
                    ViewBag.totalPaidNew = Math.Round(newTotalPaymentsMade, 2, MidpointRounding.AwayFromZero);

                    /* TODO: Спесявания - трета колона - да изчислява разликите между нов и стар за всяка стойност*/
                    ViewBag.savingsOnMonthly = monthlyPaymentCurrentCredit - newCreditPayment;

                    ViewBag.savingsOnTotal = Math.Round(totalPaymentsMade - newTotalPaymentsMade, 2, MidpointRounding.AwayFromZero); 


                    /*return View();*/

                    /* calculates if InitialFee has been selected as a flat value 
                    else
                    {
                        double leaseAmountDouble = double.Parse(LeaseAmount);
                        double initialPaymentDouble = double.Parse(InitialPayment);
                        double leasePeriodMonthsDouble = double.Parse(LeasePeriodMonths);
                        double monthlyPaymentsDouble = double.Parse(MonthlyPayments);
                        double initialFilingFeeDouble = 250;

                        double totalTaxes = initialFilingFeeDouble;

                        double totalPaid = totalTaxes + initialPaymentDouble + monthlyPaymentsDouble * leasePeriodMonthsDouble;

                        ViewBag.totalPaidWithTaxes = totalPaid + totalTaxes;
                        ViewBag.totalTaxes = totalTaxes;

                        double oneTooMany = ViewBag.totalPaidWithTaxes - leaseAmountDouble;
                        /*Изчислявам го като процен оскъпяване спрямо цената на стоката****
                        ViewBag.totalYearlySpendingPercent = (oneTooMany / totalPaid) * 100;


                        return View();
                    }*/
                }


            }
            catch (ArgumentNullException ex)
            {
                string emptyValueError = ex.Message;
                ViewBag.ErrorMessageEmpty = "Please input a number and try again";
            }
            catch (FormatException ex)
            {
                string formatError = ex.Message;
                ViewBag.ErrorFormat = "Please enter numeric values only and try again";
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
