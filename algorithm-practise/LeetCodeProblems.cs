using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace algorithm_practise
{
    public class LeetCodeProblems
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = nums1.Concat(nums2).ToArray().OrderBy(n => n).ToArray();

            if (mergedArray.Length % 2 != 0)
                return mergedArray[mergedArray.Length / 2];

            return (mergedArray[(mergedArray.Length - 1) / 2] + mergedArray[mergedArray.Length / 2]) / 2.0;
        }

        public static int FirstMissingPositive(int[] nums)
        {
            Array.Sort(nums);
            int length = nums.Length;

            if (length == 0 || nums[length - 1] <= 0) 
                return 1;
            
            int target = 1;
            
            for (int i = 0; i < length; i++)
            {
                if (nums[i] == target)
                    target++;
            }

            return target;
        }
    }
}