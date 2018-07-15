using System;
using System.Web.Mvc;

namespace MyCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator

        public ActionResult Index(MyCalculator.Models.CalculatorModel c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.Message = string.Format("{0} {1}", c.GetResult(), c.GetTolerance());
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }                
            }
            return View(c);
        }
    }
}