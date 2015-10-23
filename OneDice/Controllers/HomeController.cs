using Newtonsoft.Json.Linq;
using OneDice.Core;
using OneDice.Core.Contracts;
using OneDice.EntityFramework;
using OneDice.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OneDice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string userId = AppCookies.getCookie(AppCookies.UserId);
            if(userId == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                IUser user = UserLogic.VerifyUser(userId);
                if(user != null)
                {
                    ViewBag.User = user;
                    return View();
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }
        public ActionResult Reminder()
        {
            return View();
        }

        public ActionResult Login(string redirect, FormCollection form)
        {
            if(form == null)
            {
                return View();
            }
            else if(form.AllKeys.Count() < 1)
            {
                return View();
            }
            else
            {
                string email = form["login-email"], password = form["login-password"];
                if(!UserLogic.VerifyLoginDetails(email, AppSecurity.SHA1Encrypt(password)))
                {
                    return Json(new { action = "" });
                }
                if (string.IsNullOrWhiteSpace(redirect))
                {
                    return Json(new { action = "/" });
                }
                else
                {
                    return Json(new { action = redirect });
                }
            }
        }

        public ActionResult Register(FormCollection form)
        {
            if (form == null)
            {
                return View();
            }
            else if (form.AllKeys.Count() < 1)
            {
                return View();
            }
            else
            {
                if(form.AllKeys.Contains("id_token")) //google sign in
                {
                    HttpClient client = new HttpClient();
                    string tokenResponse = client.GetAsync("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + form["id_token"]).Result.Content.ReadAsStringAsync().Result;
                    dynamic data = JObject.Parse(tokenResponse);
                    if(data.email_verified == "true")
                    {
                        if(UserLogic.IsRegisteredGoogleUser("google-" + data.sub))
                        {
                            AppCookies.setCookie(AppCookies.UserId, "google-" + data.sub);
                            return Json(new { action = "/" });
                        }
                        else
                        {
                            //register new google user
                            GoogleUser user = new GoogleUser();
                            user.DateCreated = user.DateUpdated = DateTime.Now;
                            user.EmailVerified = true;
                            user.EMail = form["Email"];
                            user.UserName = user.Name = form["Name"];
                            user.ImageUrl = form["ImageURL"];
                            user.GoogleID = "google-" + data.sub;
                            new GoogleUserDAO().Save(user);
                            AppCookies.setCookie(AppCookies.UserId, "google-" + data.sub);
                            return Json(new { action = "/" });
                        }
                    }
                    else
                    {
                        //
                        return Json(new { action = "", error =  "OneDice could not verify your google information" });
                    }
                }
                else
                {
                    //register new user
                    OneDice.Core.User user = new User();
                    user.DateCreated = user.DateUpdated = DateTime.Now;
                    user.UserName = user.Name = form["register-username"];
                    user.EMail = form["register-email"];
                    user.Password = AppSecurity.SHA1Encrypt(form["register-password"]);
                    var userDao = new UserDAO();
                    userDao.Save(user);

                    AppCookies.setCookie(AppCookies.UserId, userDao.Table.Where(x => x.EMail == user.EMail).FirstOrDefault().ID.ToString());
                    return Json(new { action = "/" });
                }
            }
        }
    }
}