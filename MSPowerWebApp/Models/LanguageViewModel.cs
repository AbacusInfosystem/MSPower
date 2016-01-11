using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPowerWebApp.Models
{
    public class LanguageViewModel
    {
        public LanguageViewModel()
        {
            Filter = new LanguageFilter();
        }

        public LanguageFilter Filter { get; set; }
    }

    public class LanguageFilter
    {
        public string Language { get; set; }
    }
}