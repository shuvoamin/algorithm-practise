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
			int []arr = {12, 13, 1, 10, 34, 11}; 
			
			print2Smallest(arr);
			
			Console.WriteLine("\n---");
			
			var linkedList = ReverseRecursively(CreateLinkedList(arr));
			PrintRecursively(linkedList);
		} 
	}
}