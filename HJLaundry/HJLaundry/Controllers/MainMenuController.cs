using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HJLaundry.Controllers
{
    public class MainMenuController : Controller
    {
        // GET: MainMenu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuAdmin()
        {
            return View();
        }
        public ActionResult MenuManager()
        {
            return View();
        }
        public ActionResult MenuKaryawan()
        {
            return View();
        }
    }
}