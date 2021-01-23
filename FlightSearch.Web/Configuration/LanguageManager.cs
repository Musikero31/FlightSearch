using FlightSearch.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace FlightSearch.Web.Configuration
{
    public class LanguageManager
    {
        public string GetDefaultLanguage
        {
            get
            {
                return _languages[0].CultureCode;
            }
        }

        public static List<Language> _languages = new List<Language>
        {
            new Language
            {
                Name = "English",
                CultureCode = "EN"
            }
        };

        public void SetLanguage(string language)
        {
            if (!_languages.Any(lang => lang.Name == language))
            {
                language = _languages[0].CultureCode;
            }

            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);

            HttpCookie langCookie = new HttpCookie("culture", language);
            langCookie.Expires = DateTime.Now.AddHours(3);
            HttpContext.Current.Response.Cookies.Add(langCookie);

        }
    }
}