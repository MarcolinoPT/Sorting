using Sorting;
using System;
using Xunit;

namespace RackIntegrationTestProject
{
    public class When_we_integrate_the_Rack_type : IDisposable
    {
        private IRack rack;

        public When_we_integrate_the_Rack_type()
        {
            this.rack = new Rack(new Sort());
        }

        public void Dispose()
        {
            this.rack = null;
        }

        public class And_we_Add_a_number : IDisposable
        {
            private When_we_integrate_the_Rack_type instance;

            public And_we_Add_a_number()
            {
                this.instance = new When_we_integrate_the_Rack_type();
            }

            public void Dispose()
            {
                this.instance.Dispose();
                this.instance = null;
            }

            [Fact(DisplayName = "It should add the new number and sort all numbers stored")]
            public void It_should_add_and_sort_all_numbers_stored()
            {
                Assert.Equal(new int[0], this.instance.rack.Balls);
                this.instance.rack.Add(20);
                Assert.Equal(new int[] { 20 }, this.instance.rack.Balls);
                this.instance.rack.Add(10);
                Assert.Equal(new int[] { 10, 20 }, this.instance.rack.Balls);
                this.instance.rack.Add(30);
                Assert.Equal(new int[] { 10, 20, 30 }, this.instance.rack.Balls);
            }
        }
    }
}