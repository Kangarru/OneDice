using OneDice.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneDice.Controllers
{
    public class TemplatesController : Controller
    {
        // GET: Templates
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        public ActionResult AddTournament()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        public ActionResult ViewTournaments()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        public ActionResult AddGame()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        public ActionResult ViewGames()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }
    }
}