using Sorting;
using System;
using Xunit;

namespace SortingUnitTestProject
{
    public class When_we_want_to_work_with_the_FilterText_type : IDisposable
    {
        private IFilterText filterText;

        public When_we_want_to_work_with_the_FilterText_type()
        {
            this.filterText = new FilterText();
        }

        public void Dispose()
        {
            this.filterText = null;
        }

        public class And_we_want_to_RemoveAllWhiteSpaceAndConvertToLowerCase : IDisposable
        {
            private string actual;
            private string expected;
            private When_we_want_to_work_with_the_FilterText_type instance;

            public And_we_want_to_RemoveAllWhiteSpaceAndConvertToLowerCase()
            {
                this.instance = new When_we_want_to_work_with_the_FilterText_type();
            }

            public void Dispose()
            {
                this.instance.Dispose();
                this.instance = null;
            }

            [Theory(DisplayName = "It should return a string with only letters in lower case and no white spaces")]
            [InlineData("When not studying nuclear physics, Bambi likes to play beach volleyball.", "whennotstudyingnuclearphysicsbambilikestoplaybeachvolleyball")]
            public void It_should_return_a_string_with_only_letters_in_lower_case_and_no_white_spaces(string textToFilter, string expected)
            {
                this.expected = expected;
                this.actual = string.Concat(this.instance.filterText.RemoveAllWhiteSpaceAndConvertToLowerCase(textToFilter));
                Assert.Equal(this.expected, this.actual);
            }
        }
    }
}