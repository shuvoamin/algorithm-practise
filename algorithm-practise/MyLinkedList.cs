using System;

namespace algorithm_practise
{
    public class LinkedListNode
    {
        public int Data;
        public LinkedListNode Next;

        public LinkedListNode()
        {
        }
        
        public LinkedListNode(int v, LinkedListNode n)
        {
            Data = v;
            Next = n;
        }
    }
    public class MyLinkedList
    {
        public bool HasCycle(LinkedListNode head) 
        {
            if (head == null)
                return false;
    
            LinkedListNode slow = head; // moves 1 Node at a time
            LinkedListNode fast = head; // moves 2 Nodes at a time
    
            while (fast != null && fast.Next != null) 
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                
                if (slow == fast) {
                    return true; // since "slow" and "fast" collided
                }
            }
            
            return false;
        }
        
        public LinkedListNode InsertNth(LinkedListNode head, int data, int position) {
            LinkedListNode newLinkedListNode = new LinkedListNode();
            newLinkedListNode.Data = data;
            if (position == 0) {
                newLinkedListNode.Next = head;
                return newLinkedListNode;
            } else {
                /* Get Node one element before desired position */
                LinkedListNode n = head;
                for (int i = 0; i < position - 1; i++)
                {
                    n = n.Next;
                }

                /* Insert our new Node */
                newLinkedListNode.Next = n.Next;
                n.Next = newLinkedListNode;

                return head;
            }
        }
    }
    public class ReverseLinkedList
    {
        public static LinkedListNode ReverseRecursively(LinkedListNode cell)
        {
            if (cell == null)
                return null;
            else if (cell.Next == null)
                return cell;
            else
            {
                LinkedListNode second_segment = ReverseRecursively(cell.Next);
                //cell.next points to the last item in the second segment
                cell.Next.Next = cell;
                //the next of cell.next now points to cell
                cell.Next = null;
                //cell is now the last item in the list
                return second_segment;
            }
        }

        public static LinkedListNode ReverseIteratively(LinkedListNode linkedListNode)
        {
            LinkedListNode prev = null;
            LinkedListNode current = linkedListNode;
            LinkedListNode next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            linkedListNode = prev;

            return linkedListNode;
        }

        public static void PrintIteratively(LinkedListNode cell)
        {
            while (cell != null)
            {
                Console.WriteLine(cell.Data);
                cell = cell.Next;
            }
        }

        public static void PrintRecursively(LinkedListNode cell)
        {
            if (cell != null)
            {
                Console.WriteLine(cell.Data);
                PrintRecursively(cell.Next);
            }
        }

        public static LinkedListNode CreateLinkedList(int[] array)
        {
            LinkedListNode list = null;
            foreach (int i in array)
            {
                list = new LinkedListNode(i, list);
            }

            return list;
        }
    }
}