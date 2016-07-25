namespace Sorting
{
    using System;
    using System.Text;

    public interface IFilterText
    {
        char[] RemoveAllWhiteSpace(string text);
        char[] ConvertToLowerCase(string text);
    }

    public class FilterText : IFilterText
    {
        public char[] ConvertToLowerCase(string text)
        {
            ThrowArgumentNullExceptionIfTextIsNull(text);

            return text.ToLowerInvariant().ToCharArray();
        }

        public char[] RemoveAllWhiteSpace(string text)
        {
            ThrowArgumentNullExceptionIfTextIsNull(text);

            var filteredText = new StringBuilder();

            foreach (char c in text)
            {
                if (!char.IsWhiteSpace(c))
                {
                    filteredText.Append(c);
                }
            }

            return filteredText.ToString().ToCharArray();
        }

        private static void ThrowArgumentNullExceptionIfTextIsNull(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
        }
    }
}