namespace SortingUnitTestProject
{
    using FluentAssertions;
    using Sorting;
    using System;
    using Xunit;

    public class When_we_want_to_work_with_the_FilterText_type
    {
        public class And_we_want_to_RemoveAllWhiteSpace
        {
            [Theory(DisplayName = "It should return an array of characters with no white spaces")]
            [InlineData("When not studying nuclear physics, Bambi likes to play beach volleyball.", "Whennotstudyingnuclearphysics,Bambilikestoplaybeachvolleyball.")]
            public void It_should_return_a_string_with_only_letters_in_lower_case_and_no_white_spaces(string textToRemoveWhiteSpaces, string expected)
            {
                var sut = new FilterText();
                var actual = string.Concat(sut.RemoveAllWhiteSpace(textToRemoveWhiteSpaces));
                actual.Should().Be(expected, "because all text should have no white spaces");
            }

            [Fact(DisplayName = "It should throw ArgumentNullException when text to convert is null")]
            public void It_should_throw_ArgumentNullException_when_text_to_convert_is_null()
            {
                var sut = new FilterText();
                Action actual = () => sut.RemoveAllWhiteSpace(null);
                actual.ShouldThrow<ArgumentNullException>("because argument is null");
            }
        }

        public class And_we_want_to_ConvertToLowerCase
        {
            [Theory(DisplayName = "It should return an array of low case characters")]
            [InlineData("When not studying nuclear physics, Bambi likes to play beach volleyball.", "when not studying nuclear physics, bambi likes to play beach volleyball.")]
            public void It_should_return_an_array_of_low_case_characters(string textToConvertToLowerCase, string expected)
            {
                var sut = new FilterText();
                var actual = sut.ConvertToLowerCase(textToConvertToLowerCase);
                actual.Should().Equal(expected.ToCharArray(), "because all chars should be converted to lower case");
            }

            [Fact(DisplayName = "It should throw ArgumentNullException when text to convert is null")]
            public void It_should_throw_ArgumentNullException_when_text_to_convert_is_null()
            {
                var sut = new FilterText();
                Action actual = () => sut.ConvertToLowerCase(null);
                actual.ShouldThrow<ArgumentNullException>("because argument is null");
            }
        }
    }
}