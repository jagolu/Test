using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class RandomGenerator
    {
        public RandomGenerator() { }

        public List<Int32> GetRandomList(int count)
        {
            System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
            int half = (int)(count / 2);
            List<Int32> aList = Enumerable.Range(0, count + half).OrderBy(n => random.Next()).Take(count).ToList();

            return aList;
        }
    }
}
