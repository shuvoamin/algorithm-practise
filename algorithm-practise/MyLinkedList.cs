using System;

namespace algorithm_practise
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node()
        {
        }
        
        public Node(int v, Node n)
        {
            Data = v;
            Next = n;
        }
    }
    public class MyLinkedList
    {
        public bool HasCycle(Node head) 
        {
            if (head == null)
                return false;
    
            Node slow = head; // moves 1 Node at a time
            Node fast = head; // moves 2 Nodes at a time
    
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
        
        public Node InsertNth(Node head, int data, int position) {
            Node newNode = new Node();
            newNode.Data = data;
            if (position == 0) {
                newNode.Next = head;
                return newNode;
            } else {
                /* Get Node one element before desired position */
                Node n = head;
                for (int i = 0; i < position - 1; i++)
                {
                    n = n.Next;
                }

                /* Insert our new Node */
                newNode.Next = n.Next;
                n.Next = newNode;

                return head;
            }
        }
    }
    public class ReverseLinkedList
    {
        public static Node ReverseRecursively(Node cell)
        {
            if (cell == null)
                return null;
            else if (cell.Next == null)
                return cell;
            else
            {
                Node second_segment = ReverseRecursively(cell.Next);
                //cell.next points to the last item in the second segment
                cell.Next.Next = cell;
                //the next of cell.next now points to cell
                cell.Next = null;
                //cell is now the last item in the list
                return second_segment;
            }
        }

        public static Node ReverseIteratively(Node node)
        {
            Node prev = null;
            Node current = node;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            node = prev;

            return node;
        }

        public static void PrintIteratively(Node cell)
        {
            while (cell != null)
            {
                Console.WriteLine(cell.Data);
                cell = cell.Next;
            }
        }

        public static void PrintRecursively(Node cell)
        {
            if (cell != null)
            {
                Console.WriteLine(cell.Data);
                PrintRecursively(cell.Next);
            }
        }

        public static Node CreateLinkedList(int[] array)
        {
            Node list = null;
            foreach (int i in array)
            {
                list = new Node(i, list);
            }

            return list;
        }
    }
}