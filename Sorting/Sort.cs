using System;
using System.Text;

namespace Sorting
{
    public interface ISort
    {
        int[] SortCollection(int[] numbers);
        string SortCollection(char[] chars);
    }

    public class Sort : ISort
    {
        public int[] SortCollection(int[] numbers)
        {
            return SortType(ref numbers);
        }

        public string SortCollection(char[] chars)
        {
            return string.Concat(SortType(ref chars));
        }

        private T[] SortType<T>(ref T[] collection) where T : IComparable
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            bool sortAgain = false;
            T swapAux;

            for (int index = 0; index < collection.Length - 1; index++)
            {
                if (collection[index].CompareTo(collection[index + 1]) > 0)
                {
                    swapAux = collection[index];
                    collection[index] = collection[index + 1];
                    collection[index + 1] = swapAux;
                    sortAgain = true;
                }
            }

            if (sortAgain)
            {
                return SortType(ref collection);
            }
            else
            {
                return collection;
            }
        }
    }
}