using System;
using System.Diagnostics;
using System.Linq;

namespace algorithm_practise
{
    public class MedianOfTwoSortedArray
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = nums1.Concat(nums2).ToArray().OrderBy(n => n).ToArray();

            if (mergedArray.Length % 2 != 0) 
                return mergedArray[mergedArray.Length / 2];
            
            return (mergedArray[(mergedArray.Length - 1) / 2] + mergedArray[mergedArray.Length / 2]) / 2.0;
        }
    }
}