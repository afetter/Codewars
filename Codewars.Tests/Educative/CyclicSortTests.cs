using Educative;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Educative
{
    public class CyclicSortTests
    {
        [Fact]
        public void AllMissingNumbers()
        {
            int[] arr = new int[] { 2, 3, 1, 8, 2, 3, 5, 1 };
            Assert.Equal(2, CyclicSort.MissingNumber(arr));

            Assert.Equal(2, CyclicSort.MissingNumber(arr));
        }
        [Fact]
        public void MissingNumber()
        {
            int[] arr = new int[] { 4, 0, 3, 1 };
            Assert.Equal(2, CyclicSort.MissingNumber(arr));

            arr = new int[] { 8, 3, 5, 2, 4, 6, 0, 1 };
            Assert.Equal(7, CyclicSort.MissingNumber(arr));
        }

        [Fact]
        public void Sort()
        {
            int[] arr = new int[] { 3, 1, 5, 4, 2 };
            int[] result = new int[] { 1, 2, 3, 4, 5 };

            var obj1Str = JsonConvert.SerializeObject(result);
            var obj2Str = JsonConvert.SerializeObject(CyclicSort.Sort(arr));

            Assert.Equal(obj1Str, obj2Str);


            arr = new int[] { 2, 6, 4, 3, 1, 5 };
            result = new int[] { 1, 2, 3, 4, 5, 6 };

            obj1Str = JsonConvert.SerializeObject(result);
            obj2Str = JsonConvert.SerializeObject(CyclicSort.Sort(arr));

            Assert.Equal(obj1Str, obj2Str);

            arr = new int[] { 1, 5, 6, 4, 3, 2 };
            result = new int[] { 1, 2, 3, 4, 5, 6 };

            obj1Str = JsonConvert.SerializeObject(result);
            obj2Str = JsonConvert.SerializeObject(CyclicSort.Sort(arr));

            Assert.Equal(obj1Str, obj2Str);
        }
    }
}
