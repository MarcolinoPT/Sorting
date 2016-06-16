using Sorting;
using System;
using Xunit;
using Moq;

namespace SortingUnitTestProject
{
    public class When_we_work_with_the_HiddenMessage_type : IDisposable
    {
        private IHiddenMessage hiddenMessage;

        public void Dispose()
        {
            this.hiddenMessage = null;
        }

        public class And_we_want_to_decode_a_message : IDisposable
        {
            private When_we_work_with_the_HiddenMessage_type instance;
            private Mock<IFilterText> filterTextMoq;
            private Mock<ISort> sortMoq;

            public void Dispose()
            {
                this.instance.Dispose();
                this.instance = null;
                this.sortMoq = null;
                this.filterTextMoq = null;
            }

            [Theory(DisplayName = "It should decode a message correctly")]
            [InlineData("When not studying nuclear physics, Bambi likes to play beach volleyball.", "whennotstudyingnuclearphysicsbambilikestoplaybeachvolleyball", "aaaaabbbbcccdeeeeeghhhiiiiklllllllmnnnnooopprsssstttuuvwyyyy")]
            public void It_should_decode_a_message_correctly(string message, string filteredMessage, string expectedSortedMessage)
            {
                this.instance = new When_we_work_with_the_HiddenMessage_type();
                this.filterTextMoq = new Mock<IFilterText>();
                var filteredMessageCharArray = filteredMessage.ToCharArray();
                this.filterTextMoq.Setup(foo => foo.RemoveAllWhiteSpaceAndConvertToLowerCase(message)).Returns(filteredMessageCharArray);
                this.sortMoq = new Mock<ISort>();
                this.sortMoq.Setup(foo => foo.SortCollection(filteredMessageCharArray)).Returns(expectedSortedMessage);
                this.instance.hiddenMessage = new HiddenMessage(this.filterTextMoq.Object, this.sortMoq.Object);
                var expected = expectedSortedMessage;
                var actual = this.instance.hiddenMessage.DecodeMessage(message);
                Assert.Equal(expected, actual);
                this.filterTextMoq.Verify(foo => foo.RemoveAllWhiteSpaceAndConvertToLowerCase(message), Times.Once);
                this.sortMoq.Verify(foo => foo.SortCollection(filteredMessageCharArray), Times.Once);
            }
        }
    }
}