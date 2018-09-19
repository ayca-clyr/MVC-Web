using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MhrsWeb.Helper
{
    public static class LinkExtension
    {
        public static string SeoReplace(string item)
        {
            return item.ToLower()
                .Replace(".", "-")
                .Replace(" ", "-")
                .Replace("ı", "i")
                .Replace("İ", "I")
                .Replace("ğ", "g")
                .Replace("ç", "c")
                .Replace("Ç", "C")
                .Replace("ü", "u")
                .Replace("ö", "o")
                .Replace("ş", "s")
                .Replace("'", "")
                .Replace(":", "")
                .Replace(",", "")
                .Replace(";", "")
                .Replace("!", "")
                .Replace("?", "")
                .Replace("\"", "")
                .Replace("/", "");
        }
    }
}