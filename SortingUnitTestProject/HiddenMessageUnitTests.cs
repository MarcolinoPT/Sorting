namespace SortingUnitTestProject
{
    using FluentAssertions;
    using Moq;
    using Sorting;
    using System;
    using Xunit;

    public class When_we_work_with_the_HiddenMessage_type
    {
        public class And_we_want_to_DecodeMessage
        {
            [Theory(DisplayName = "It should return the expected message")]
            [InlineData("When not studying nuclear physics, Bambi likes to play beach volleyball.", "aaaaabbbbcccdeeeeeghhhiiiiklllllllmnnnnooopprsssstttuuvwyyyy")]
            [InlineData("abcd", "Hello world!")]
            public void It_should_return_the_expected_message(string messageToDecode, string expectedMessage)
            {
                var filterTextDummy = new Mock<IFilterText>();
                var sortFilteredMessageStub = new Mock<ISort>();
                sortFilteredMessageStub.Setup(foo => foo.SortChars(It.IsAny<char[]>())).Returns(expectedMessage.ToCharArray());
                var sut = new HiddenMessage(filterTextDummy.Object, sortFilteredMessageStub.Object);
                var actual = sut.DecodeMessage(messageToDecode);
                actual.Should().Be(expectedMessage, "because it should return a message");
            }

            [Fact(DisplayName = "It should throw ArgumentNullException when message to decode is null")]
            public void It_should_throw_ArgumentNullException_when_message_to_decode_is_null()
            {
                var filterTextDummy = new Mock<IFilterText>();
                var sortFilteredMessagesStub = new Mock<ISort>();
                var sut = new HiddenMessage(filterTextDummy.Object, sortFilteredMessagesStub.Object);
                Action actual = () => sut.DecodeMessage(null);
                actual.ShouldThrow<ArgumentNullException>("because message to decode is null");
            }
        }
    }
}