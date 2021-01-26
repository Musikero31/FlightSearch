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
        private static readonly List<Language> _languages = new List<Language>
        {
            new Language
            {
                Name = "English",
                CultureCode = "en"
            },
            new Language
            {
                Name = "Malaysia",
                CultureCode = "ms"
            }
        };

        public string GetDefaultLanguage => _languages[0].CultureCode;

        public static List<Language> Languages => _languages;

        public void SetLanguage(string language)
        {
            if (!Languages.Any(lang => lang.CultureCode == language))
            {
                language = Languages[0].CultureCode;
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