// C# program to find smallest 
// and second smallest elements 

using System;
using System.Collections.Generic;
using static algorithm_practise.ReverseLinkedList;
using static algorithm_practise.SecondSmallestNumber;

namespace algorithm_practise
{
    public class ProgramMain
    {
        public static void Main()
        {
            int[] arr = { 12, 13, 1, 10, 34, 11 };

            //Console.WriteLine("--FIND LONGEST OCCURRED DIAGRAM");
            //Console.WriteLine(LeetCodeProblems.FindLongestDiagram("codility"));

            //Console.WriteLine("--FIND LONGEST POSSIBLE DIVERSE STRING");
            //Console.WriteLine(LeetCodeProblems.FindLongestPossibleDiverseString(6, 1, 1));

            Console.WriteLine("--FIND HAS PAIRS IN ARRAY");
            Console.WriteLine(LeetCodeProblems.HasPairsInArray(new int[] { 1, 2, 2, 1 }));

            Console.WriteLine("--FIND SMALLEST MISSING INTEGER");
            var smallestMissingInt = LeetCodeProblems.FindSmallestIntegerInArray(new int[] { -1, -3});
            Console.WriteLine(smallestMissingInt);

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
            tree.Left.Left = new BinarySearchTree(2);
            tree.Left.Right = new BinarySearchTree(6);

            if (BinarySearchTree.IsBinarySearchTree(tree))
            {
                Console.WriteLine("IS BST");
            }
            else
            {
                Console.WriteLine("Not a BST");
            }

            Console.WriteLine("\n--- Median of Two Sorted Array");
            Console.WriteLine(LeetCodeProblems.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));

            Console.WriteLine("\n--- Smallest Missing Positive Integer in a Unsorted Array");

            Console.WriteLine(LeetCodeProblems.FirstMissingPositive(new[] { 3, 4, -1, 1 }));

            Console.WriteLine("\n--- Most common word in a paragraph");
            Console.WriteLine(LeetCodeProblems.GetMostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new[] { "hit" }));

            Console.WriteLine("\n--- Longest prefix in string arrays");
            Console.WriteLine(LeetCodeProblems.GetLongestCommonPrefix(new[] { "flower", "flight", "flow" }));

            Console.WriteLine("\n--- Popular feature requested by users");
            var result = LeetCodeProblems.PopularNFeatures(
                5,
                2,
                new List<string> { "anacell", "betacellular", "flow" },
                3,
                new List<string> { "Best Services provided by anacell", "betacellular has greate services", "anacell provides much better services than all other" }
            );
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

            // TODO :: fix binary search
            //Console.WriteLine("\n--- Binary Search in an Array");
            //Console.WriteLine(BinarySearchTree.BinarySearchIterative(arr, 13));

            Console.ReadKey();

            Console.WriteLine(LeetCodeProblems.FirstMissingPositive(new[] {1000, -1}));

            Console.WriteLine("\n--- Are two arrays equal");
            Console.WriteLine(LeetCodeProblems.AreTheyEqual(new[] { 1, 2, 3, 5 }, new[] { 1, 4, 3, 2 }));
        }
    }
}