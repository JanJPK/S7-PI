using System.Text;

namespace Vehifleet.Helper.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Adds single space before every capital letter.
        /// </summary>
        /// <param name="text">Input text.</param>
        /// <returns>Text with spaces added.</returns>
        public static string AddSpaces(this string text)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    sb.Append(' ');
                }
                sb.Append(text[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Removes all spaces.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <returns>Text with all spaces removed.</returns>
        public static string RemoveSpaces(this string text)
        {
            return text.Replace(" ", string.Empty);
        }
    }
}