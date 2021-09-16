using System;
using Educative;
using Xunit;

namespace Tests.Educative
{
    public class FastSlowPointersTests
    {
        [Fact]
        public void Middle()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            Assert.Equal(3, FastSlowPointers.MiddleOfLinkedList(head).Value);

            head.Next.Next.Next.Next.Next = new ListNode(6);
            Assert.Equal(4, FastSlowPointers.MiddleOfLinkedList(head).Value);

            head.Next.Next.Next.Next.Next.Next = new ListNode(7);
            Assert.Equal(4, FastSlowPointers.MiddleOfLinkedList(head).Value);
        }

        [Fact]
        public void FindHappyNumber()
        {
            Assert.True(FastSlowPointers.HappyNumber(23));
            Assert.False(FastSlowPointers.HappyNumber(12));
        }

        [Fact]
        public void LinkedListCicleStart()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next;
            Assert.Equal(3, FastSlowPointers.FindCycleStart(head).Value);

            head.Next.Next.Next.Next.Next.Next = head.Next.Next.Next;
            Assert.Equal(4, FastSlowPointers.FindCycleStart(head).Value);

            head.Next.Next.Next.Next.Next.Next = head;
            Assert.Equal(1, FastSlowPointers.FindCycleStart(head).Value);
        }

        [Fact]
        public void LinkedListCycleLength()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);
            head.Next.Next.Next.Next.Next.Next = head.Next.Next;
            Assert.Equal(4, FastSlowPointers.LinkedListCycleLength(head));

            head.Next.Next.Next.Next.Next.Next = head.Next.Next.Next;
            Assert.Equal(3,FastSlowPointers.LinkedListCycleLength(head));
        }

        [Fact]
        public void LinkedListCycle()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);
            Assert.False(FastSlowPointers.LinkedListCycle(head));

            head.Next.Next.Next.Next.Next.Next = head.Next.Next;
            Assert.True(FastSlowPointers.LinkedListCycle(head));

            head.Next.Next.Next.Next.Next.Next = head.Next.Next.Next;
            Assert.True(FastSlowPointers.LinkedListCycle(head));
        }
    }
}
