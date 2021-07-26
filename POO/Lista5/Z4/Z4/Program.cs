using System;
using System.Collections;


namespace Z4
{
    class Z4
    {

        static void Main(string[] args)
        {
            ArrayList a = new ArrayList() { 1, 5, 3, 3, 2, 4, 3 };
            Comparison<int> cmp = (x, y) => x.CompareTo(y);

            /* the ArrayList's Sort method accepts ONLY an IComparer */
            a.Sort(new ComparisonToComparerAdapter<int>(cmp));
            foreach(int i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
        }
        public class ComparisonToComparerAdapter<T> : IComparer
        {
            Comparison<T> compare;

            public ComparisonToComparerAdapter(Comparison<T> compare)
            {
                this.compare = compare;
            }

            public int Compare(object x, object y)
            {
                return compare((T)x, (T)y);
            }
        }
        
    }
}