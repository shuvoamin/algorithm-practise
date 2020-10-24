using System;
using System.Collections.Generic;
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

        // N number of character in word and M number of ban word 
        // Time Complexity: O(N+M)
        // Space Complexity: O(N+M)
        public static string GetMostCommonWord(string paragraph, string[] bannedWords)
        {
            char[] delimiterChars = { ' ', '!', '?', '\'', ',', ';', '.' };
            string[] words = paragraph.Split(delimiterChars);

            var banned = new HashSet<string>();
            foreach (var bannedWord in bannedWords)
                banned.Add(bannedWord.ToLower());

            var wordCounts = new Dictionary<string, int>();

            foreach (var wd in words)
            {
                string word = wd.ToLower();

                if (banned.Contains(word) || word.Length < 1)
                    continue;

                if (!wordCounts.TryAdd(word, 1))
                {
                    wordCounts[word]++;
                }
            }

            var wordList = wordCounts.ToList();
            wordList.Sort((a, b) => b.Value.CompareTo(a.Value));  // Sort Descending

            return wordList.First().Key;   // Since it's gurranteed to have an ans
        }
    }
}