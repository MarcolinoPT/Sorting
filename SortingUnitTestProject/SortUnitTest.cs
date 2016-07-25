namespace SortingUnitTestProject
{
    using FluentAssertions;
    using Sorting;
    using Xunit;

    public class When_we_work_with_the_Sort_type
    {
        public class And_we_want_to_sort_an_array_of_integers
        {
            [Theory(DisplayName = "It should return a sorted array")]
            [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
            [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
            [InlineData(new int[] { 20, 8, 54, 120, 0, 12, 4, 3, 2, 111 }, new int[] { 0, 2, 3, 4, 8, 12, 20, 54, 111, 120 })]
            public void It_should_return_a_sorted_array(int[] toSort, int[] expected)
            {
                var sut = new Sort();
                var actual = sut.SortNumbers(toSort);
                actual.Should().Equal(expected, "because all numbers should be sorted in ascending order");
            }
        }

        public class And_we_want_to_sort_a_string
        {
            [Theory(DisplayName = "It should return a block of text with only letters and all sorted")]
            [InlineData("whennotstudyingnuclearphysicsbambilikestoplaybeachvolleyball", "aaaaabbbbcccdeeeeeghhhiiiiklllllllmnnnnooopprsssstttuuvwyyyy")]
            public void It_should_return_a_block_of_text_with_only_letters_and_all_sorted(string textToSort, string expected)
            {
                var sut = new Sort();
                var actual = sut.SortChars(textToSort.ToCharArray());
                actual.Should().Equal(expected, "because all characters should be sorted in ascending order");
            }
        }
    }
}