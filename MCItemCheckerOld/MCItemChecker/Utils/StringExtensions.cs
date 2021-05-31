using System.Globalization;
using System.Text.RegularExpressions;

namespace MCItemChecker.Utils
{
    internal static class StringExtensions
    {
        public static bool ToInt(this string text, out int value)
        {
            value = 0;
            try
            {
                int temp = 0;
                for (int i = 0; i < text.Length; i++)
                    temp = temp * 10 + (text[i] - '0');

                value = temp;
            }
            catch { return false; }

            return true;
        }

        public static bool FractionToDouble(this string fraction, out double result)
        {
            if (double.TryParse(fraction, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-US"), out result))
                return true;

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {

                if (int.TryParse(split[0], out int a) && int.TryParse(split[1], out int b))
                {
                    if (split.Length == 2)
                    {
                        result = (double)a / b;
                        return true;
                    }


                    if (int.TryParse(split[2], out int c))
                    {
                        result = a + (double)b / c;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsInteger(this string value)
        {
            return int.TryParse(value, out _);
        }

        public static string ToFirstLetterUpperCase(this string value)
        {
            string name = Regex.Replace(value, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            return Regex.Replace(name, @"\s+", " ", RegexOptions.Multiline);
        }
    }
}
