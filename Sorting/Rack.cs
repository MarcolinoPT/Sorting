using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public interface IRack
    {
        int[] Balls { get; }
        void Add(int number);
    }

    public class Rack : IRack
    {
        private ISort sort;

        public Rack(ISort sort)
        {
            this.sort = sort;
            this.balls = new int[0];
        }

        private int[] balls;

        public int[] Balls
        {
            get { return this.balls; }
        }

        public void Add(int number)
        {
            Array.Resize(ref this.balls, this.balls.Length + 1);
            this.balls[this.balls.Length - 1] = number;
            this.balls = this.sort.SortCollection(this.balls);
        }
    }
}