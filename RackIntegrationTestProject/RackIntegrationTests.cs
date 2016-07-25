namespace RackIntegrationTestProject
{
    using Sorting;
    using Xunit;

    public class When_we_integrate_the_Rack_type
    {
        public class And_we_Add_a_number
        {
            [Fact(DisplayName = "It should add the new number and sort all numbers stored")]
            public void It_should_add_and_sort_all_numbers_stored()
            {
                var sut = new Rack(new Sort());
                Assert.Equal(new int[0], sut.Balls);
                sut.Add(20);
                sut.SortBalls();
                Assert.Equal(new int[] { 20 }, sut.Balls);
                sut.Add(10);
                sut.SortBalls();
                Assert.Equal(new int[] { 10, 20 }, sut.Balls);
                sut.Add(30);
                sut.SortBalls();
                Assert.Equal(new int[] { 10, 20, 30 }, sut.Balls);
            }
        }
    }
}