using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Level.Application.Extension
{
    public static class StringExtension
    {
        public static string GetOnlyNumbers(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Regex regex = new Regex(@"\D");
                return regex.Replace(text, string.Empty);
            }

            return text;
        }

        public static string GetEnumDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static string CompleteCreditCardNumbers(this string str, string brand = "mastercard")
        {
            const int cardNumber = 16;

            switch (brand.ToLower())
            {
                case "mastercard":
                case "visa":
                    return str.PadLeft(cardNumber, '0');
            }

            throw new NotImplementedException("This brand does not exist or has not yet been implemented");
        }

        public static string RemoveNonNumbers(this string text) => new string(text.Where(c => char.IsDigit(c)).ToArray());
    }
}
