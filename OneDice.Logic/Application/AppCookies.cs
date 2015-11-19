using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OneDice.Logic
{
    public class AppCookies
    {
        public static void setCookie(string cookie, string value)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookie)
            {
                Value = value,
                Expires = DateTime.Now.AddDays(3)
            });
        }
        public static string getCookie(string cookie)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(cookie))
            {
                return HttpContext.Current.Request.Cookies[cookie].Value;
            }
            else return null;
        }

        public const string UserId = "OneDiceUserId";
    }
}
