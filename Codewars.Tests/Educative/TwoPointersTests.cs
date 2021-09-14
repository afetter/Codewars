using System;
using Educative;
using Xunit;

namespace Tests.Educative
{
    public class TwoPointersTests
    {
        [Fact]
        public void BackspaceCompare()
        {
            Assert.True(TwoPointers.BackspaceCompare("xy#z", "xzz#"));
            Assert.False(TwoPointers.BackspaceCompare("xy#z","xyz#"));
            Assert.True(TwoPointers.BackspaceCompare("xp#", "xyz##"));
            Assert.True(TwoPointers.BackspaceCompare("xywrrmp", "xywrrmu#p"));
        }

        [Fact]
        public void QuadrupleSumToTarget()
        {
            var x = TwoPointers.QuadrupleSumToTarget(new int[] { 4, 1, 2, -1, 1, -3 }, 1);

            Assert.Equal("-3,-1,1,4", string.Join(",", x[0]));
            Assert.Equal("-3,1,1,2", string.Join(",", x[1]));

            var x1 = TwoPointers.QuadrupleSumToTarget(new int[] { 2, 0, -1, 1, -2, 2 }, 2);

            Assert.Equal("-2,0,2,2", string.Join(",", x1[0]));
            Assert.Equal("-1,0,1,2", string.Join(",", x1[1]));


        }

        [Fact]
        public void DutchFlag()
        {
            Assert.Equal("0 0 1 1 2", string.Join(" ",TwoPointers.DutchFlag(new int[] { 1, 0, 2, 1, 0 })));
            Assert.Equal("0 0 1 2 2 2", string.Join(" ", TwoPointers.DutchFlag(new int[] { 2, 2, 0, 1, 2, 0 })));

        }


        [Fact]
        public void TripletWithSmallerSum()
        {
            Assert.Equal(2, TwoPointers.TripletWithSmallerSum(new int[] { -1, 0, 2, 3 }, 3));
            Assert.Equal(4, TwoPointers.TripletWithSmallerSum(new int[] { -1, 4, 2, 1, 3 }, 5));

        }


        [Fact]
        public void TripletSumCloseToTarget()
        {
            Assert.Equal(1,TwoPointers.TripletSumCloseToTarget(new int[] { -2, 0, 1, 2 }, 2));
            Assert.Equal(0, TwoPointers.TripletSumCloseToTarget(new int[] { -3, -1, 1, 2 }, 1));
            Assert.Equal(3, TwoPointers.TripletSumCloseToTarget(new int[] { 1, 0, 1, 1 }, 100));

        }

        [Fact]
        public void TripletSumToZero()
        {
            var result1 = TwoPointers.TripletSumToZero(new int[] { -3, 0, 1, 2, -1, 1, -2 });

            Assert.Equal("-3,1,2", string.Join(",", result1[0]));
            Assert.Equal("-2,0,2", string.Join(",", result1[1]));
            Assert.Equal("-2,1,1", string.Join(",", result1[2]));
            Assert.Equal("-1,0,1", string.Join(",", result1[3]));

            var result2 = TwoPointers.TripletSumToZero(new int[] { -5, 2, -1, -2, 3 });

            Assert.Equal("-5,2,3", string.Join(",", result2[0]));
            Assert.Equal("-2,-1,3", string.Join(",", result2[1]));
        }


        [Fact]
        public void SortedArraySquares()
        {
            Assert.Equal("0,1,4,4,9", string.Join(",", TwoPointers.SortedArraySquares(new int[] { -2, -1, 0, 2, 3 })));
            Assert.Equal("0,1,1,4,9", string.Join(",", TwoPointers.SortedArraySquares(new int[] { -3, -1, 0, 1, 2 })));
        }

        [Fact]
        public void RemoveElement()
        {
            Assert.Equal(4, TwoPointers.RemoveElement(new int[] { 3, 2, 3, 6, 3, 10, 9, 3 }, 3));
            Assert.Equal(2, TwoPointers.RemoveElement(new int[] { 2, 11, 2, 2, 1 }, 2));
        }

        [Fact]
        public void RemoveDuplicates()
        {
            Assert.Equal(4, TwoPointers.RemoveDuplicates(new int[] { 2, 3, 3, 3, 6, 9, 9 }));
            Assert.Equal(2, TwoPointers.RemoveDuplicates(new int[] { 2, 2, 2, 11 }));
        }

        [Fact]
        public void PairWithTargetSumWithDic()
        {
            Assert.Equal(new int[] { 1, 3 }, TwoPointers.PairWithTargetSumWithDic(new int[] { 1, 2, 3, 4, 6 }, 6));
            Assert.Equal(new int[] { 0, 2 }, TwoPointers.PairWithTargetSumWithDic(new int[] { 2, 5, 9, 11 }, 11));
        }


        [Fact]
        public void PairWithTargetSum()
        {
            Assert.Equal(new int[] {1,3 }, TwoPointers.PairWithTargetSum(new int[] { 1, 2, 3, 4, 6 }, 6));
            Assert.Equal(new int[] { 0, 2 }, TwoPointers.PairWithTargetSum(new int[] { 2, 5, 9, 11 }, 11));
        }
    }
}
