using System;

namespace Others
{
    public class CsDojo
    {
        public static int CountNodes(Node head)
        {
            Node slow = head;
            int lenght = 1;
            do
            {
                slow = slow.Next;
                lenght++;

            } while (slow.Next != null);

            return lenght;
        }
    }
}
