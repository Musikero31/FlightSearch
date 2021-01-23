using FlightSearch.Web.Configuration;
using System;
using System.Web;
using System.Web.Mvc;

namespace FlightSearch.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            LanguageManager manager = new LanguageManager();

            string lang = null;

            HttpCookie cookieLang = Request.Cookies["culture"];
            if (cookieLang != null)
            {
                lang = cookieLang.Value;
                //drucre
            }
            else
            {   
                var userLang = Request.UserLanguages;
                var usrLang = userLang != null ? userLang[0] : string.Empty;

                if (!string.IsNullOrEmpty(usrLang))
                {
                    lang = usrLang;
                }
                else
                {
                    lang = manager.GetDefaultLanguage;
                }
            }

            manager.SetLanguage(lang);

            return base.BeginExecuteCore(callback, state);
        }
    }
}