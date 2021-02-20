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

        //public IActionResult Index(LeasingModel LeasingModel, string calculate)
        [HttpPost]
        
        public IActionResult LeaseCalc(string LeaseAmount, string InitialPayment, string LeasePeriodMonths, string MonthlyPayments, bool FlatOrPercent, string InitialFilingFee)
        {
            try
            {
                /* verifies all inputs are positive */
                if (int.Parse(LeaseAmount) < 0 || int.Parse(InitialPayment) < 0 || int.Parse(LeasePeriodMonths) < 0 || int.Parse(MonthlyPayments) < 0 || int.Parse(InitialFilingFee) < 0)
                {
                    ViewBag.NegNumError = "Please input positive numbers";
                }

                else {
                    /* calculates if InitialFee has been selected as a percentage */
                    if (FlatOrPercent == false)
                    {
                        double leaseAmountDouble = double.Parse(LeaseAmount);
                        double initialPaymentDouble = double.Parse(InitialPayment);
                        double leasePeriodMonthsDouble = double.Parse(LeasePeriodMonths);
                        double monthlyPaymentsDouble = double.Parse(MonthlyPayments);
                        double initialFilingFeeDouble = double.Parse(InitialFilingFee);

                        double totalTaxes = leaseAmountDouble * (initialFilingFeeDouble / 100);

                        ViewBag.totalPaidWithTaxes = totalTaxes + totalTaxes;
                        ViewBag.totalTaxes = totalTaxes;

                        double oneTooMany = ViewBag.totalPaidWithTaxes - leaseAmountDouble;
                        /*Изчислявам го като процен оскъпяване спрямо цената на стоката*/
                        ViewBag.totalYearlySpendingPercent = (oneTooMany / totalTaxes) * 100;


                        return View();
                    }

                /* calculates if InitialFee has been selected as a flat value */
                    else
                    {
                        double leaseAmountDouble = double.Parse(LeaseAmount);
                        double initialPaymentDouble = double.Parse(InitialPayment);
                        double leasePeriodMonthsDouble = double.Parse(LeasePeriodMonths);
                        double monthlyPaymentsDouble = double.Parse(MonthlyPayments);
                        double initialFilingFeeDouble = 250;

                        double totalTaxes =  initialFilingFeeDouble;
                        
                        double totalPaid = totalTaxes + initialPaymentDouble + monthlyPaymentsDouble * leasePeriodMonthsDouble;

                        ViewBag.totalPaidWithTaxes = totalPaid + totalTaxes;
                        ViewBag.totalTaxes = totalTaxes;

                        double oneTooMany = ViewBag.totalPaidWithTaxes - leaseAmountDouble;
                        /*Изчислявам го като процен оскъпяване спрямо цената на стоката*/
                        ViewBag.totalYearlySpendingPercent = (oneTooMany / totalPaid) * 100;


                        return View();
                    }
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
