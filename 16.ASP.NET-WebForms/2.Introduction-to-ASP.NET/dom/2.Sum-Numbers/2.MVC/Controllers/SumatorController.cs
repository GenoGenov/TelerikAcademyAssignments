namespace _2.MVC.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class SumatorController : Controller
    {
        // GET: Summator
        [HttpGet]
        public ActionResult DisplayForm()
        {
            return this.View("index");
        }

        [HttpPost]
        public ActionResult Calculate(FormCollection collection)
        {
            try
            {
                var a = (int)collection.GetValue("a").ConvertTo(typeof(int));
                var b = (int)collection.GetValue("b").ConvertTo(typeof(int));
                ViewBag.result = a + b;

                return this.View("index");
            }
            catch (Exception)
            {
                ViewBag.error = @"Both 'a' and 'b' are mandatory and must be numbers!";
                return this.View("index");
            }
            
        }
    }
}