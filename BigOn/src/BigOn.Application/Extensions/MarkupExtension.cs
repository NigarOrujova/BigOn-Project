using System.Text.RegularExpressions;

namespace BigOn.Application.Extensions
{
    public static partial class Extension
    {
        //<a>
        static public string ToPlainText(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            return Regex.Replace(value, @"(<[^>]*>)", "");
        }

        static public string ToSlug(this string context)
        {
            if (string.IsNullOrWhiteSpace(context))
                return null;

            //c#-and-------sql => csharp-and-sql
            context = context.Replace("Ü", "u").Replace("ü", "u")
                .Replace("İ", "i").Replace("I", "i").Replace("ı", "i")
                .Replace("Ş", "s").Replace("ş", "s")
                .Replace("Ö", "o").Replace("ö", "o")
                .Replace("Ç", "c").Replace("ç", "c")
                .Replace("Ğ", "g").Replace("ğ", "g")
                .Replace("Ə", "e").Replace("ə", "e")
                .Replace(" ", "-").Replace("?", "").Replace("/", "")
                .Replace("\\", "").Replace(".", "").Replace("'", "").Replace("#", "sharp").Replace("%", "")
                .Replace("*", "").Replace("!", "").Replace("@", "").Replace("+", "")
                .ToLower().Trim();

            context = Regex.Replace(context, @"\&+", "and");
            context = Regex.Replace(context, @"[^a-z0-9]+", "-");
            context = Regex.Replace(context, @"-+", "-");
            context = context.Trim('-');

            return context;
        }

        static public string ToJsonArray(this int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return "[]";
            }

            return $"[{string.Join(",", array)}]";
        }
    }
}
