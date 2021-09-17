using System;
using System.Collections.Generic;
using System.Linq;

namespace Educative
{
    public class MergeIntervals
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static int MinimumMeetingRooms(List<Interval> intervals)
        {
            intervals = intervals.OrderBy(n => n.start).ToList();
            var rooms = 1;
            for (int i = 0; i < intervals.Count - 1; i++)
            {
                if (intervals[i].end > intervals[i + 1].start)
                    rooms++;
            }

            return rooms;

        }

        /// <summary>
        /// Given an array of intervals representing ‘N’ appointments, find out if a person can attend 
        /// all the appointments.
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static bool ConflictingAppointments(List<Interval> intervals)
        {
            intervals = intervals.OrderBy(n => n.start).ToList();

            for (int i = 0; i < intervals.Count - 1; i++)
            {
                if (intervals[i].end > intervals[i + 1].start)
                    return false;
            }

            return true;
        
        }

        /// <summary>
        /// Given a list of non-overlapping intervals sorted by their start time, insert a given interval at 
        /// the correct position and merge all necessary intervals to produce a list that has only mutually
        /// exclusive intervals.
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public static List<Interval> Insert(List<Interval> intervals, Interval newInterval)
        {
            List<Interval> mergedIntervals = new List<Interval>();
            int i = 0;
            //skip and add to output all intervals that come before the 'newinterval'
            while (i < intervals.Count && intervals[i].end < newInterval.start)
                mergedIntervals.Add(intervals[i++]);

            // merge all intervals that overlap with 'newInterval'
            while (i < intervals.Count && intervals[i].start <= newInterval.end)
            {
                newInterval.start = Math.Min(intervals[i].start, newInterval.start);
                newInterval.end = Math.Max(intervals[i].end, newInterval.end);
                i++;
            }

            mergedIntervals.Add(newInterval);

            // add all the remaining intervals to the output
            while (i < intervals.Count)
                mergedIntervals.Add(intervals[i++]);


            return mergedIntervals;
        }

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
