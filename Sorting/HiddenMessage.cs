using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface IHiddenMessage
    {
        string DecodeMessage(string text);
    }

    public class HiddenMessage : IHiddenMessage
    {
        private IFilterText filterText;
        private ISort sort;

        public HiddenMessage(IFilterText filterText, ISort sort)
        {
            this.filterText = filterText;
            this.sort = sort;
        }

        public string DecodeMessage(string text)
        {
            char[] filterTextApplied = this.filterText.RemoveAllWhiteSpaceAndConvertToLowerCase(text);
            string sortedText = this.sort.SortCollection(filterTextApplied);
            return sortedText;
        }
    }
}