using OneDice.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneDice.Controllers
{
    public class ValidateController : Controller
    {
        public string Email(FormCollection form)
        {
            string email = form["email"];
            try
            {
                if (new UserDAO().Table.Any(x => x.EMail == email))
                {
                    return "false";
                }
                else return "true";
            }
            catch
            {
                return "true";
            }
        }
    }
}