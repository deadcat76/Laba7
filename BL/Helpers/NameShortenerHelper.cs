using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Helpers
{
    public static class NameShortenerHelper
    {
        public static string GetShortName(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return string.Empty;
            }
            else
            {
                string[] results = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return results[0] + " " + results[1][0]+"." + " " + results[2][0]+".";
            }
        }
    }
}
