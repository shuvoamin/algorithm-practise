using System;
using System.Collections;
using System.Collections.Generic;

namespace algorithm_practise
{
    public static class ArrayLeftRotation
    {
        public static int[] LeftRotation(int[] a, int d) 
        {
            var leftQueue = new Queue();
            var rightQueue = new Queue();

            for(var i = 0; i < d; i++)
            {
                leftQueue.Enqueue(a[i]);
            }

            for(var i = d; i < a.Length; i++)
            {
                rightQueue.Enqueue(a[i]);
            }

            var list = new List<int>();

            while (rightQueue.Count > 0)
            {    
                list.Add((int)rightQueue.Dequeue());
            }
            
            while (leftQueue.Count > 0)
            {    
                list.Add((int)leftQueue.Dequeue());
            }

            return list.ToArray();
        }
        
        public static void PrintArray(int[] arr)
        {
            foreach (var i in arr)
                Console.Write(i + ", ");
        } 
    }
}