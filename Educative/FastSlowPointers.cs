using System;
namespace Educative
{
    public class FastSlowPointers
    {
        /// <summary>
        /// Given the head of a LinkedList with a cycle, find the length of
        /// the cycle.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static int LinkedListCycleLength(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast) // found the cycle
                    return calculateLength(slow);
            }
            return 0;

            int calculateLength(ListNode slow)
            {
                ListNode current = slow;
                int cycleLength = 0;
                do
                {
                    current = current.next;
                    cycleLength++;
                } while (current != slow);
                return cycleLength;
            }

        }



        /// <summary>
        /// Given the head of a Singly LinkedList, write a function to
        /// determine if the LinkedList has a cycle in it or not.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool LinkedListCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast)
                    return true; // found the cycle
            }
            return false;
        }
    }

    public class ListNode
    {
        int value = 0;
        public ListNode next;

        public ListNode(int value)
        {
            this.value = value;
        }
    }
}
