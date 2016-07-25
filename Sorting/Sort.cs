namespace Sorting
{
    using System;

    public interface ISort
    {
        int[] SortNumbers(int[] numbers);
        char[] SortChars(char[] chars);
    }

    public class Sort : ISort
    {
        public int[] SortNumbers(int[] numbers)
        {
            return SortType(ref numbers);
        }

        public char[] SortChars(char[] chars)
        {
            return SortType(ref chars);
        }

        private T[] SortType<T>(ref T[] collection) where T : IComparable
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            var sortAgain = false;
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

            return sortAgain ? SortType(ref collection) : collection;
        }
    }
}