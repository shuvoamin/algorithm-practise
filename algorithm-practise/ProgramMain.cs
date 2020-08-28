// C# program to find smallest 
// and second smallest elements 

using System;
using static algorithm_practise.ReverseLinkedList;
using static algorithm_practise.SecondSmallestNumber;

namespace algorithm_practise
{
    public class ProgramMain
    {
        public static void Main()
        {
            int[] arr = {12, 13, 1, 10, 34, 11};

            Print2Smallest(arr);

            Console.WriteLine("\n---REVERSING LINKED LIST");

            var linkedList = ReverseRecursively(CreateLinkedList(arr));
            PrintRecursively(linkedList);

            Console.WriteLine("\n--- GRAPH (DFS) / (BFS)");

            var graph = new Graph();
            Graph.GraphNode node;

            foreach (var item in arr)
            {
                node = new Graph.GraphNode(item);

                graph.AddNode(node.Id);
            }

            graph.AddEdge(12, 13);
            graph.AddEdge(12, 1);

            Console.WriteLine($"DFS => {graph.HasPathDfs(12, 13)}");
            Console.WriteLine($"BFS => {graph.HasPathBfs(12, 1)}");
            
            Console.WriteLine("\n--- Brackets Matching");
            Console.WriteLine(BracketMatching.IsBalanced("{{{}}}"));
            
            Console.WriteLine("\n--- Queue using two stacks");
            var queue = new MyQueue();
            Console.WriteLine("Inserting 1, 2, 3");
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            Console.WriteLine($"Dequeue => {queue.DeQueue()}");
            
            Console.WriteLine("\n--- Array left rotation");
            ArrayLeftRotation.PrintArray(ArrayLeftRotation.LeftRotation(arr, 2));
            
            Console.WriteLine("\n--- Ice cream Parlor Problem");

            foreach (var costIndices in HashAndMap.IceCreamParlorOn2(12, arr))
            {
                Console.Write($"{costIndices}, ");
            }
            
            Console.WriteLine("\n--- Binary Search Tree");
            
            BinarySearchTree tree = new BinarySearchTree(4); 
            tree.Left = new BinarySearchTree(3); 
            tree.Right = new BinarySearchTree(5);
            // tree.Left.Left = new BinarySearchTree(2); 
            // tree.Left.Right = new BinarySearchTree(6);

            if (BinarySearchTree.IsBinarySearchTree(tree)) 
            { 
                Console.WriteLine("IS BST"); 
            } 
            else
            { 
                Console.WriteLine("Not a BST"); 
            } 
        }
    }
}