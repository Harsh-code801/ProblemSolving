using System.Collections.Generic;
using System;

namespace MyApp
{
    internal class ProblemSolving
    {
        static void Main(string[] args)
        {
            int[] maxSubarraySum = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine(MaxSubarraySumWithContinusarr(maxSubarraySum, maxSubarraySum.Length));
            #region MissingNumber

            int[] missingNumber = new int[] { 1, 2, 3, 5, 3, 4 };
            Console.WriteLine(MissingNumber(missingNumber, missingNumber.Length));
            #endregion

            #region SubArrayWithGivenSum
            //int[] arr = new int[] { 5, 9, 7, 6, 3, 4 };
            int[] arr = new int[] { 101, 168, 93, 188, 133, 157, 175 };
            foreach (int i in SubArrayWithGivenSum(arr, arr.Length, 167))
                Console.WriteLine(i + " ");
            Console.ReadLine();
            #endregion
        }
        public static long MaxSubarraySumWithContinusarr(int[] array, int n)
        {
            List<long> sumList = new List<long>();
            int sum = 0;
            int index = 0;
            if (array.Where(x => x < 0).ToArray().Length == n)
            {
                return array.OrderByDescending(x => x).ToArray()[0];
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sum = sum + array[i];
                    if (i == n - 1)
                        sumList.Add(sum);
                    sum = 0;
                    i = index++;
                }
            }
            return sumList.Max();
        }
        public static long MaxSubarraySumwithNotContinus(int[] array, int n)
        {
            array = array.OrderByDescending(x => x).ToArray();
            int sum = array.Where(x => x > 0).Sum();
            if (sum != 0)
                return sum;
            else
            {
                int[] temp = array.Where(x => x < 0).ToArray();
                if (temp != null && temp.Length > 0)
                    return temp[0];
            }
            return 0;
        }
        public static int MissingNumber(int[] array, int n)
        {
            int[] main = Enumerable.Range(1, n + 1).ToArray();
            array = array.Distinct().ToArray();
            for (int i = 0; i < main.Length; i++)
            {
                if (!array.Contains(main[i]))
                    return i + 1;
            }
            return 0;
        }
        public static List<int> SubArrayWithGivenSum(int[] arr, int n, int s)
        {
            List<int> list = new List<int>();
            int startIndex = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = sum + arr[i];
                if (sum == s)
                {
                    list.Add(startIndex + 1);
                    list.Add(i + 1);
                    break;
                }
                else if (sum > s)
                {
                    startIndex++;
                    i = startIndex - 1;
                    sum = 0;
                }
                if (startIndex == n || i == n - 1)
                    list.Add(-1);
            }
            return list;
        }
    }
}