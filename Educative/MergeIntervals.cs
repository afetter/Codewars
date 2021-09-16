using System;
using System.Collections.Generic;
using System.Linq;

namespace Educative
{
    public class MergeIntervals
    {
        public static List<Interval> FindIntersections(IList<Interval> intervals)
        {
            var result = new List<Interval>();
            for (int i = 0; i < intervals.Count - 1; i++)
            {
                if (i == intervals.Count) break;

                if (intervals[i].start <= intervals[i + 1].end && intervals[i].end >= intervals[i + 1].start)
                {
                    result.Add(new Interval(intervals[i].start, intervals[i].end));
                    result.Add(new Interval(intervals[i + 1].start, intervals[i + 1].end));
                }
            }
            return result;

        }
        /// <summary>
        /// Given a list of intervals, merge all the overlapping intervals to produce a 
        /// list that has only mutually exclusive intervals.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static List<Interval> Merge(IList<Interval> intervals)
        {
            var result = new List<Interval>();
            intervals = intervals.OrderBy(n => n.start).ToList();

            int start = intervals[0].start;
            int end = intervals[0].end;

            foreach (var item in intervals)
            {
                if (item.start <= end)
                {
                    end = Math.Max(item.end, end);
                }
                else
                {
                    result.Add(new Interval(start, end));
                    start = item.start;
                    end = item.end;
                }
            }
            result.Add(new Interval(start, end));
            return result;
        }
    }

    public class Interval
    {
        public int start;
        public int end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    };
}
