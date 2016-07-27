namespace SortingUnitTestProject
{
    using FluentAssertions;
    using Moq;
    using Sorting;
    using Xunit;

    public class When_we_work_with_the_Rack_type
    {
        public class And_we_wish_to_Add_a_new_ball
        {
            [Theory(DisplayName = "It should add the ball")]
            [Trait("Category", "Unit")]
            [InlineData(20, new int[] { 20 })]
            public void It_should_add_the_ball(int ballToAdd, int[] finalBallsCollection)
            {
                var sortDummy = new Mock<ISort>();
                var sut = new Rack(sortDummy.Object);
                sut.Add(ballToAdd);
                sut.Balls.Should().Equal(finalBallsCollection, "because the new ball should be added and present in the collection");
            }
        }

        public class And_we_wish_to_SortBalls
        {
            [Theory(DisplayName = "It should return the balls collection")]
            [Trait("Category", "Unit")]
            [InlineData(new int[0])]
            [InlineData(new int[] { 20 })]
            [InlineData(new int[] { 20, 100, int.MaxValue })]
            [InlineData(new int[] { 20, 100, int.MaxValue, int.MinValue, 0 })]
            public void It_should_return_the_balls_collection(int[] ballsCollectionToReturn)
            {
                var sortStub = new Mock<ISort>();
                sortStub.Setup(foo => foo.SortNumbers(It.IsAny<int[]>())).Returns(ballsCollectionToReturn);
                var sut = new Rack(sortStub.Object);
                sut.SortBalls();
                sut.Balls.Should().Equal(ballsCollectionToReturn, "because sort dependency should return the balls collection");
            }
        }
    }
}