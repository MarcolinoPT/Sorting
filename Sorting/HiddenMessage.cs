namespace Sorting
{
    using System;

    public interface IHiddenMessage
    {
        string DecodeMessage(string text);
    }

    public class HiddenMessage : IHiddenMessage
    {
        private readonly IFilterText filterText;
        private readonly ISort sort;

        public HiddenMessage(IFilterText filterText, ISort sort)
        {
            this.filterText = filterText;
            this.sort = sort;
        }

        public string DecodeMessage(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var textWithoutWhiteSpace = this.filterText.RemoveAllWhiteSpace(message);
            var textWithoutWhiteSpaceAndInLowerCase = this.filterText.ConvertToLowerCase(string.Concat(textWithoutWhiteSpace));
            var sortedText = this.sort.SortChars(textWithoutWhiteSpaceAndInLowerCase);
            return string.Concat(sortedText);
        }
    }
}