// C# program to find smallest 
// and second smallest elements 

using System;

namespace algorithm_practise
{
    public static class SecondSmallestNumber 
    { 
	
        /* Function to print first smallest 
        and second smallest elements */
        public static void print2Smallest(int []arr) 
        { 
            int first, second, arr_size = arr.Length; 

            /* There should be atleast two elements */
            if (arr_size < 2) 
            { 
                Console.Write(" Invalid Input "); 
                return; 
            } 

            first = second = int.MaxValue; 
		
            for (int i = 0; i < arr_size ; i ++) 
            { 
                /* If current element is smaller than first 
                then update both first and second */
                if (arr[i] < first) 
                { 
                    second = first; 
                    first = arr[i]; 
                } 

                /* If arr[i] is in between first and second 
                then update second */
                else if (arr[i] < second && arr[i] != first) 
                    second = arr[i]; 
            } 
            if (second == int.MaxValue) 
                Console.Write("There is no second" + 
                              "smallest element"); 
            else
                Console.Write("The smallest element is " + 
                              first + " and second Smallest" + 
                              " element is " + second); 
        } 

    }
} 