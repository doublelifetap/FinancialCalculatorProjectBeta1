using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PartyInvites.Controllers
{
    public class LeasingController : Controller
    {
        [HttpGet]
        public IActionResult LeaseCalc()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Index(LeasingModel LeasingModel, string calculate)
        public IActionResult LeaseCalc(string LeaseAmount, string InitialPayment, string LeasePeriodMonths, string MonthlyPayments, string InitialFilingFee, bool FlatOrPercent)
        {
            try
            {
                /* verifies all inputs are positive */
                if (int.Parse(LeaseAmount) < 0 || int.Parse(InitialPayment) < 0 || int.Parse(LeasePeriodMonths) < 0 || int.Parse(MonthlyPayments) < 0 || int.Parse(InitialFilingFee) < 0)
                {
                    ViewBag.NegNumError = "Please input positive numbers";
                }

                else {
                    
                        double leaseAmountDouble = double.Parse(LeaseAmount);
                        double initialPaymentDouble = double.Parse(InitialPayment);
                        double leasePeriodMonthsDouble = double.Parse(LeasePeriodMonths);
                        double monthlyPaymentsDouble = double.Parse(MonthlyPayments);
                        double initialFilingFeeDouble = double.Parse(InitialFilingFee);
                        
                        double Tax = initialFilingFeeDouble;
                        double totalTaxes = initialFilingFeeDouble;

                        decimal GPR;

                    /*Taxes calc %:*/
                    //double totalTaxes = leaseAmountDouble * (initialFilingFeeDouble / 100);

                    if (!FlatOrPercent)
                    {
                        totalTaxes = leaseAmountDouble * (initialFilingFeeDouble / 100);
                    }

                    double totalPaid = totalTaxes + initialPaymentDouble + (monthlyPaymentsDouble * leasePeriodMonthsDouble);

                        double interestGPR = Microsoft.VisualBasic.Financial.Rate(leasePeriodMonthsDouble, -monthlyPaymentsDouble, (double)(leaseAmountDouble - initialPaymentDouble - totalTaxes)) * 12;
                        GPR = (decimal)Math.Pow((interestGPR / 12) + 1.0, 12) - 1;

                        ViewBag.GPR = Math.Round(GPR * 100, 2, MidpointRounding.AwayFromZero);
                        ViewBag.totalPaidWithTaxes = totalPaid;
                        ViewBag.totalTaxes = totalTaxes;

                        /*Изчислявам го като процен оскъпяване спрямо цената на стоката*/


                        return View();
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
        }

    }
}
