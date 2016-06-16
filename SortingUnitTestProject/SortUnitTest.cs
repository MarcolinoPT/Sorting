using Sorting;
using System;
using Xunit;

namespace SortingUnitTestProject
{
    public class When_we_work_with_the_Sort_type : IDisposable
    {
        private ISort sort;

        public When_we_work_with_the_Sort_type()
        {
            this.sort = new Sort();
        }

        public void Dispose()
        {
            this.sort = null;
        }

        public abstract class Base : IDisposable
        {
            protected When_we_work_with_the_Sort_type instance;

            protected Base()
            {
                this.instance = new When_we_work_with_the_Sort_type();
            }

            public void Dispose()
            {
                this.instance.Dispose();
                this.instance = null;
            }
        }

        public class And_we_want_to_sort_an_array_of_integers : Base, IDisposable
        {
            private int[] actual;
            private int[] expected;

            [Theory(DisplayName = "It should return a sorted array")]
            [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
            [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
            [InlineData(new int[] { 20, 8, 54, 120, 0, 12, 4, 3, 2, 111 }, new int[] { 0, 2, 3, 4, 8, 12, 20, 54, 111, 120 })]
            public void It_should_return_a_sorted_array(int[] toSort, int[] expected)
            {
                this.expected = expected;
                this.actual = this.instance.sort.SortCollection(toSort);
                Assert.Equal(this.expected, this.actual);
            }

            public new void Dispose()
            {
                base.Dispose();
                this.actual = null;
                this.expected = null;
            }
        }

        public class And_we_want_to_sort_a_string : Base, IDisposable
        {
            private string actual;
            private string expected;

            [Theory(DisplayName = "It should return a block of text with only letters and all sorted")]
            [InlineData("whennotstudyingnuclearphysicsbambilikestoplaybeachvolleyball", "aaaaabbbbcccdeeeeeghhhiiiiklllllllmnnnnooopprsssstttuuvwyyyy")]
            public void It_should_return_a_block_of_text_with_only_letters_and_all_sorted(string textToSort, string expected)
            {
                this.expected = expected;
                this.actual = base.instance.sort.SortCollection(textToSort.ToCharArray());
                Assert.Equal(this.expected, this.actual);
            }

            public new void Dispose()
            {
                base.Dispose();
                this.actual = null;
                this.expected = null;
            }
        }
    }
}