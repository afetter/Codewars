using System;
using Educative;
using Xunit;

namespace Tests.Educative
{
    public class FastSlowPointersTests
    {
        [Fact]
        public void LinkedListCycleLength()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = head.next.next;
            Assert.Equal(4, FastSlowPointers.LinkedListCycleLength(head));

            head.next.next.next.next.next.next = head.next.next.next;
            Assert.Equal(3,FastSlowPointers.LinkedListCycleLength(head));
        }

        [Fact]
        public void LinkedListCycle()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            Assert.False(FastSlowPointers.LinkedListCycle(head));

            head.next.next.next.next.next.next = head.next.next;
            Assert.True(FastSlowPointers.LinkedListCycle(head));

            head.next.next.next.next.next.next = head.next.next.next;
            Assert.True(FastSlowPointers.LinkedListCycle(head));
        }
    }
}
