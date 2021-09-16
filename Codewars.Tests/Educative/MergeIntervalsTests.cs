using Educative;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Educative
{
    public class MergeIntervalsTests
    {
        [Fact]
        public void FindIntersections()
        {
            List<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));
            input.Add(new Interval(7, 9));

            var resut = new List<Interval>();
            resut.Add(new Interval(1, 4));
            resut.Add(new Interval(2, 5));

            var obj1Str = JsonConvert.SerializeObject(resut);
            var obj2Str = JsonConvert.SerializeObject(MergeIntervals.FindIntersections(input));

            Assert.Equal(obj1Str, obj2Str);

        }
        [Fact]
        public void Merge()
        {
            List<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));
            input.Add(new Interval(7, 9));

            var resut = new List<Interval>();
            resut.Add(new Interval(1, 5));
            resut.Add(new Interval(7, 9));

            var obj1Str = JsonConvert.SerializeObject(resut);
            var obj2Str = JsonConvert.SerializeObject(MergeIntervals.Merge(input));

            Assert.Equal(obj1Str, obj2Str);

            input = new List<Interval>();
            input.Add(new Interval(6, 7));
            input.Add(new Interval(2, 4));
            input.Add(new Interval(5, 9));

            resut = new List<Interval>();
            resut.Add(new Interval(2, 4));
            resut.Add(new Interval(5, 9));

            obj1Str = JsonConvert.SerializeObject(resut);
            obj2Str = JsonConvert.SerializeObject(MergeIntervals.Merge(input));
            Assert.Equal(obj1Str, obj2Str);

            input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 6));
            input.Add(new Interval(3, 5));

            resut = new List<Interval>();
            resut.Add(new Interval(1, 6));

            obj1Str = JsonConvert.SerializeObject(resut);
            obj2Str = JsonConvert.SerializeObject(MergeIntervals.Merge(input));
            Assert.Equal(obj1Str, obj2Str);

        }
    }
}
