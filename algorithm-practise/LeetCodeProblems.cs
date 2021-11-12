using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace algorithm_practise
{
    public class LeetCodeProblems
    {
        // AMAZON problem 20/03/2021
        // not completed solution
        public static int FindLongestDiagram(string S)
        {
            var disctinctSting = new String(S.Distinct().ToArray());

            // first, if none available return -1
            if (S != disctinctSting)
                return -1;

            return 1;
        }

        // AMAZON problem 20/03/2021
        // not completed solution
        public static string FindLongestPossibleDiverseString(int A, int B, int C)
        {
            var value = new StringBuilder();
            var valueString = value.ToString();
            var hasValue = !string.IsNullOrEmpty(value.ToString());
            var valueLength = value.ToString().Length;
            var lastThreeValue = valueLength == 2 ? value.ToString().Substring(0, valueLength - 2) : string.Empty;

            while (A != 0 || B != 0 || C != 0)
            {
                for (int i = 0; i < A; i++)
                {
                    if (i == 2)
                        break;
                    
                        value.Append("a");
                        A--;

                    // we need to check last three characters aren't repeating and remove them or other way round not inserting them
                    if (hasValue && lastThreeValue == "aaa")
                    {
                        valueString =  valueString.Substring(0, valueLength - 1);
                    }
                }

                for (int i = 0; i < B; i++)
                {
                    if (i == 2)
                        break;

                    value.Append("b");
                    B--;

                    // we need to check last three characters aren't repeating and remove them or other way round not inserting them
                    if (hasValue && lastThreeValue == "bbb")
                    {
                        valueString = valueString.Substring(0, valueLength - 1);
                    }
                }

                for (int i = 0; i < C; i++)
                {
                    if (i == 2)
                        break;

                    value.Append("c");
                    C--;

                    // we need to check last three characters aren't repeating and remove them or other way round not inserting them
                    if (hasValue && lastThreeValue == "ccc")
                    {
                        valueString = valueString.Substring(0, valueLength - 1);
                    }
                }
            }

            return valueString;
        }

        // AMAZON problem 20/03/2021
        public static bool HasPairsInArray(int[] A)
        {
            // using Hashset gives us O(1) time complexity
            // these two hashset also O(1) space complexity
            HashSet<int> pairLeft = new HashSet<int>();
            HashSet<int> pairRight = new HashSet<int>();
            HashSet<int> missedItems = new HashSet<int>();

            // O(N) time complexity
            foreach (int arr in A)
            {
                var hasInserted = pairLeft.Add(arr);
                var hasSecondPairInserted = false;

                if (!hasInserted)
                {
                    hasSecondPairInserted = pairRight.Add(arr);
                }

                if (!hasInserted && !hasSecondPairInserted)
                {
                    missedItems.Add(arr);
                }
            }

            return pairLeft.Count() == pairRight.Count() && missedItems.Count == 0;
        }

        public static int FindSmallestIntegerInArray(int[] A)
        {
            int arrlength = A.Length;
            HashSet<int> positiveArrSet = new HashSet<int>();
            foreach (int a in A)
            {
                if (a > 0)
                {
                    positiveArrSet.Add(a);
                }
            }
            for (int i = 1; i <= arrlength + 1; i++)
            {
                if (!positiveArrSet.Contains(i))
                {
                    return i;
                }
            }

            return 0;
        }

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

        // Time Complexity: O(MAX * n * log n )
        // Space Complexity : O(1)
        public static string GetLongestCommonPrefix(string[] a)
        {
            int size = a.Length;

            /* if size is 0, return empty string */
            if (size == 0)
                return "";

            if (size == 1)
                return a[0];

            /* sort the array of strings */
            Array.Sort(a);

            /* find the minimum length from first 
            and last string */
            int end = Math.Min(a[0].Length, a[size - 1].Length);

            /* find the common prefix between the  
            first and last string */
            int i = 0;
            while (i < end && a[0][i] == a[size - 1][i])
                i++;

            string pre = a[0].Substring(0, i);

            return pre;
        }

        public static List<string> PopularNFeatures(
            int numFeatures,
            int topFeatures,
            List<string> possibleFeatures,
            int numFeatureRequests,
            List<string> featureRequests
        )
        {
            // WRITE YOUR CODE HERE
            if (topFeatures > possibleFeatures.Count)
                return featureRequests;

            var popular = new Dictionary<string, int>();
            var pFtr = possibleFeatures.Select(f => f.ToLower());

            foreach (var req in featureRequests)
            {
                var words = req.Split(" ").Select(w => w);

                foreach (var wd in words)
                {
                    var wdLower = wd.ToLower();
                    if (pFtr.Contains(wdLower))
                    {
                        if (!popular.TryAdd(wdLower, 1))
                        {
                            popular[wdLower]++;
                        }
                    }
                }
            }

            popular.OrderByDescending(p => p.Value).Take(topFeatures);

            return new List<string>(popular.Keys);
        }

        // AMAZON PROBLEM AUTUMN 2020
        // Given a list of N unique integers, construct a BST by inserting each integer in the given order without rebalacning the tree. Then
        // find the distance between the two given nodes, node 1 and node 2, of the BST. In case, either node 1 or node 2 is not present in the
        // tree, return 1.
        // 6, [5, 6, 3, 1, 2, 4], 2, 4
        // output : 3
        // path traversal node1 to node 2 is 2, 1, 3 and 4, so output is 3
        // public static int bstDistance(int num, List<int> values, int node1, int node2) { }

        public static bool AreTheyEqual(int[] arr_a, int[] arr_b)
        {
            // Write your code here
            Array.Sort(arr_a);
            Array.Sort(arr_b);

            for (int i = 0; i < arr_a.Length; i++)
            {
                if (arr_a[i] != arr_b[i])
                    return false;
            }

            return true;
        }
    }
}