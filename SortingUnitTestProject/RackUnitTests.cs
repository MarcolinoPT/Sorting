using Moq;
using Sorting;
using System;
using Xunit;

namespace SortingUnitTestProject
{
    public class When_we_work_with_the_Rack_type : IDisposable
    {
        private IRack rack;

        public abstract class Base : IDisposable
        {
            protected When_we_work_with_the_Rack_type instance;

            protected Base()
            {
                this.instance = new When_we_work_with_the_Rack_type();
                var moqSort = new Mock<ISort>();
                this.instance.rack = new Rack(moqSort.Object);
            }

            public void Dispose()
            {
                this.instance.Dispose();
                this.instance = null;
            }
        }

        public void Dispose()
        {
            this.rack = null;
        }

        public class And_we_wish_to_add_a_new_number : Base
        {
            public And_we_wish_to_add_a_new_number() : base()
            {
                var moqSort = new Mock<ISort>();
                moqSort.Setup(foo => foo.SortCollection(It.IsAny<int[]>())).Returns(() => this.SortedCollection);
                base.instance.rack = new Rack(moqSort.Object);
            }

            private int[] SortedCollection
            {
                get; set;
            }

            [Fact(DisplayName = "It should add the number and sort all balls")]
            public void It_should_add_the_ball_and_sort_all_balls()
            {
                Assert.Equal(new int[0], this.instance.rack.Balls);
                this.SortedCollection = new int[] { 20 };
                this.instance.rack.Add(20);
                Assert.Equal(this.SortedCollection, this.instance.rack.Balls);
                this.SortedCollection = new int[] { 10, 20 };
                this.instance.rack.Add(10);
                Assert.Equal(this.SortedCollection, this.instance.rack.Balls);
                this.SortedCollection = new int[] { 10, 20, 30 };
                this.instance.rack.Add(30);
                Assert.Equal(this.SortedCollection, this.instance.rack.Balls);
            }
        }
    }
}