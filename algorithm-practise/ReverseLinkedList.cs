using System;

namespace algorithm_practise
{
    public class ReverseLinkedList
    {
        public class Node{
            public int value;
            public Node next;
            public Node(int v , Node n){
                value = v;
                next = n;
            }
        }
        public static Node ReverseRecursively(Node cell) {
            if (cell == null)
                return null;
            else if(cell.next == null)
                return cell;
            else {
                Node second_segment = ReverseRecursively(cell.next);
                //cell.next points to the last item in the second segment
                cell.next.next = cell;
                //the next of cell.next now points to cell
                cell.next = null;
                //cell is now the last item in the list
                return second_segment;
            }
        }
        
        public static void PrintIteratively(Node cell) {
            while (cell != null) {
                Console.WriteLine(cell.value);
                cell = cell.next;
            }
        }
        
        public static void PrintRecursively(Node cell) {
            if (cell != null) {
                Console.WriteLine(cell.value);
                PrintRecursively(cell.next);
            }
        }
        
        public static Node CreateLinkedList(int[] array){
            Node list = null;
            foreach (int i in array)
            {
                list = new Node(i, list);
            }
            return list;
        }
    }
}