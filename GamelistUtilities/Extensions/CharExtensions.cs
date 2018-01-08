using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GamelistUtilities.Extensions
{
    public static class CharExtensions
    {
        public static string ToHexadecimalReference(this char c)
        {
            int numericValue = (int)c;
            return string.Format("&#x{0:X};", numericValue);
        }

        public static string ToDecimalReference(this char c)
        {
            int numericValue = (int)c;
            return string.Format("&#{0};", numericValue);
        }

        public static string ToHtmlEncoded(this char c)
        {
            return WebUtility.HtmlEncode(c.ToString());
        }
    }
}
