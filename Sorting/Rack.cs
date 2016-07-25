namespace Sorting
{
    using System;

    public interface IRack
    {
        int[] Balls { get; }
        void Add(int number);
        void SortBalls();
    }

    public class Rack : IRack
    {
        private readonly ISort sort;

        public Rack(ISort sort)
        {
            this.sort = sort;
        }

        private int[] balls = new int[0];

        public int[] Balls => this.balls;

        public void Add(int number)
        {
            Array.Resize(ref this.balls, this.balls.Length + 1);
            this.balls[this.balls.Length - 1] = number;
        }

        public void SortBalls()
        {
            this.balls = this.sort.SortNumbers(this.balls);
        }
    }
}