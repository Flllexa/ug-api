using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ug;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var subscription = await UgApi.Iugu.Shortcut.Subscription(
                       "John Galt",
                       "jonhgalt@live.com",
                       "557.579.638-83",
                       30,
                       "Doação",
                       24);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
