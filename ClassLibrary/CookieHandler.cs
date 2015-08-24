using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;


namespace ClassLibrary
{
    public class CookieHandler
    {

        public void writeCookie(string key, string value)
        {
            var cookie = new HttpCookie(key, value);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }


        public string readCookie(String key)
        {
            if (HttpContext.Current.Response.Cookies.AllKeys.Contains(key))
            {
                var cookie = HttpContext.Current.Response.Cookies[key];
                return cookie.Value;
            }

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
            {
                var cookie = HttpContext.Current.Request.Cookies[key];
                return cookie.Value;
            }

            return null;
        }

        public bool deleteCookie(string key)
        {
            bool deleted = false;
            if (readCookie(key) != null)
            {
                HttpCookie myCookie = new HttpCookie(key);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(myCookie);
                deleted = true;
            }
            return deleted;
        }

    }
}
