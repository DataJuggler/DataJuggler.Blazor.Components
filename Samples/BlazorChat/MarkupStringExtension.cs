using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Ganss.XSS;

namespace BlazorChat
{
    public static class MarkupStringExtensions
    {
        public static MarkupString Sanitize(this MarkupString markupString)
        {
            return new MarkupString(SanitizeInput(markupString.Value));
        }

        private static string SanitizeInput(string value)
        {
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(value);
        }
    }
}
