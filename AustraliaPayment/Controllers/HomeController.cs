using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AustraliaPayment.Models;
using System.Text.RegularExpressions;

namespace AustraliaPayment.Controllers
{
    public class HomeController : Controller
    {
        //GET
        public ActionResult Index()
        {            
            return PartialView("~/Views/Partials/_IndexForm.cshtml");
        }        

        // POST
        [HttpPost]        
        public ActionResult Index([Bind(Include = "BSB,AccountNumber,AccountName,Reference,Amount")] Payment payment, string amountAux)
        {
            try
            {
                payment.Amount = Convert.ToDecimal(amountAux.Replace(",", "").Replace(".", ","));
            }
            catch
            {}
            if (ModelState.IsValid)
            {
                if (payment.Amount <= 0)
                    ModelState.AddModelError("Amount", "Amount value is mandatory. The value has to be greater then zero.");
                else if (payment.BSB.Length < 7)
                    ModelState.AddModelError("BSB", "Invalid BSB.");
                else if (payment.AccountNumber.Length < 6)
                    ModelState.AddModelError("AccountNumber", "Invalid account number.");
                else if (!Regex.IsMatch(payment.AccountName, @"^[\p{L} \.\-]+$"))
                    ModelState.AddModelError("AccountName", "Invalid account name.");                
                else
                {
                    payment.AccountName = payment.AccountName.ToUpper();
                    if (!string.IsNullOrEmpty(payment.Reference))
                        payment.Reference = payment.Reference.Replace(";", "").ToUpper();
                    string LogText = DateTime.Now.ToString("HH:mm:ss") + ";" + payment.BSB + ";" + payment.AccountNumber + ";" + payment.AccountName + ";" + payment.Reference + ";" + payment.Amount.ToString().Replace(",",".");
                    string fileName = Util.Log(LogText);
                    if (!string.IsNullOrEmpty(fileName))
                        return PartialView("~/Views/Partials/_IndexMessage.cshtml",fileName);
                }
            }
            return PartialView("~/Views/Partials/_IndexForm.cshtml");
        }
    }
}