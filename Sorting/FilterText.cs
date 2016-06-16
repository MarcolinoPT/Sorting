using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface IFilterText
    {
        char[] RemoveAllWhiteSpaceAndConvertToLowerCase(string text);
    }

    public class FilterText : IFilterText
    {
        public char[] RemoveAllWhiteSpaceAndConvertToLowerCase(string text)
        {
            StringBuilder filteredText = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    filteredText.Append(char.ToLowerInvariant(c));
                }
            }

            return filteredText.ToString().ToCharArray();
        }
    }
}