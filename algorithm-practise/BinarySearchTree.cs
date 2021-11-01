using System;
using System.Collections;
using System.Collections.Generic;

namespace algorithm_practise
{
    public class BinarySearchTree
    {
        public int Data { get; set; }
        public BinarySearchTree Left { get; set; }
        public BinarySearchTree Right { get; set; }

        public BinarySearchTree(int data)
        {
            Data = data;
        }

        public void Insert(int value)
        {
            if (value <= Data)
            {
                if (Left == null)
                {
                    Left = new BinarySearchTree(value);
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchTree(value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }

        public bool Contains(int value)
        {
            if (value == Data)
            {
                return true;
            }
            else if (value < Data)
            {
                if (Left == null)
                {
                    return false;
                }
                else
                {
                    return Left.Contains(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    return false;
                }
                else
                {
                    return Right.Contains(value);
                }
            }
        }

        public void PrintInOrder()
        {
            if (Left != null)
            {
                Left.PrintInOrder();
            }

            Console.WriteLine(Data);

            if (Right != null)
            {
                Right.PrintInOrder();
            }
        }

        public static bool IsBinarySearchTree(BinarySearchTree root)
        {
            int prev = int.MinValue;

            return IsBinarySearchTree(root, prev);
        }

        public static bool BinarySearchIterative(int[] array, int valueToFind)
        {
            int left = 0;
            int right = array.Length - 1;

            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == valueToFind)
                {
                    return true;
                }
                else if (valueToFind < array[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }

        public static bool BinarySearchRecursive(int[] array, int valueToFind)
        {
            return BinarySearchRecursive(array, valueToFind, 0, array.Length - 1);
        }

        private static bool BinarySearchRecursive(int[] array, int valueToFind, int left, int right)
        {
            if (left > right)
                return false;

            int mid = (left + right) / 2;

            if (array[mid] == valueToFind)
            {
                return true;
            }
            else if (valueToFind < array[mid])
            {
                return BinarySearchRecursive(array, valueToFind, left, mid - 1);
            }
            else
            {
                return BinarySearchRecursive(array, valueToFind, mid + 1, right);
            }
        }

        private static bool IsBinarySearchTree(BinarySearchTree root, int prev)
        {
            // traverse the tree in in-order fashion and 
            // keep track of prev node
            if (root != null)
            {
                if (!IsBinarySearchTree(root.Left, prev))
                    return false;

                // Allows only distinct valued nodes 
                if (root.Data <= prev)
                    return false;

                // Initialize prev to current 
                prev = root.Data;

                return IsBinarySearchTree(root.Right, prev);
            }

            return true;
        }
    }
}