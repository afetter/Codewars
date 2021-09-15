using System;
namespace Educative
{
    public class FastSlowPointers
    {
        public static bool HappyNumber(int number)
        {
            int slow = number, fast = number;
            do
            {
                slow = findSquareSum(slow); // move one step
                fast = findSquareSum(findSquareSum(fast)); // move two steps
            } while (slow != fast); // found the cycle

            return slow == 1; // see if the cycle is stuck on the number '1'

            static int findSquareSum(int num)
            {
                int sum = 0, digit;
                while (num > 0)
                {
                    digit = num % 10;
                    sum += digit * digit;
                    num /= 10;
                }
                return sum;
            }
        }

        /// <summary>
        /// Given the head of a Singly LinkedList that contains a cycle, write a function to find the starting node of the cycle.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode FindCycleStart(ListNode head)
        {
            int cycleLength = 0;
            // find the LinkedList cycle
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (slow == fast)
                { // found the cycle
                    cycleLength = calculateCycleLength(slow);
                    break;
                }
            }

            return findStart(head, cycleLength);

            int calculateCycleLength(ListNode slow)
            {
                ListNode current = slow;
                int cycleLength = 0;
                do
                {
                    current = current.Next;
                    cycleLength++;
                } while (current != slow);

                return cycleLength;
            }

            ListNode findStart(ListNode head, int cycleLength)
            {
                ListNode pointer1 = head, pointer2 = head;
                // move pointer2 ahead 'cycleLength' nodes
                while (cycleLength > 0)
                {
                    pointer2 = pointer2.Next;
                    cycleLength--;
                }

                // increment both pointers until they meet at the start of the cycle
                while (pointer1 != pointer2)
                {
                    pointer1 = pointer1.Next;
                    pointer2 = pointer2.Next;
                }

                return pointer1;
            }
        }

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
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
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
                    current = current.Next;
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
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (slow == fast)
                    return true; // found the cycle
            }
            return false;
        }
    }

    public class ListNode
    {
        public int Value;
        public ListNode Next;

        public ListNode(int value)
        {
            this.Value = value;
        }
    }
}
