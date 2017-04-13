using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPLForFun.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectPlayer(int playerId, int matchId)
        {
            ModelState.AddModelError("CustomError", "What The fuck just happened");
            return View("Index");
        }
    }
}