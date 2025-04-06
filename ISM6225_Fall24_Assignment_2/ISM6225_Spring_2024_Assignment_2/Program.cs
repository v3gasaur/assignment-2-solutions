using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> missingNumbers = new List<int>();
                if (nums == null || nums.Length == 0)
                {
                    return missingNumbers; // Edge Case 1: Empty input
                }

                HashSet<int> seenNumbers = new HashSet<int>();
                foreach (int num in nums)
                {
                    seenNumbers.Add(num); // Duplicates are automatically handled by HashSet
                }

                int n = nums.Length;
                for (int i = 1; i <= n; i++)
                {
                    if (!seenNumbers.Contains(i))
                    {
                        missingNumbers.Add(i); // Edge Cases 2-6 covered
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return nums; // Edge case: empty or null array

                int[] result = new int[nums.Length];
                int evenIndex = 0;
                int oddIndex = nums.Length - 1;

                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                    {
                        result[evenIndex++] = num;
                    }
                    else
                    {
                        result[oddIndex--] = num;
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> numDict = new Dictionary<int, int>();
                
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    
                    if (numDict.ContainsKey(complement))
                    {
                        return new int[] { numDict[complement], i };
                    }
                    
                    if (!numDict.ContainsKey(nums[i]))
                    {
                        numDict.Add(nums[i], i);
                    }
                }
                
                throw new ArgumentException("No two numbers add up to the target.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums.Length < 3)
                    throw new ArgumentException("Array must have at least 3 elements");

                Array.Sort(nums);
                int n = nums.Length;
                int option1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                int option2 = nums[0] * nums[1] * nums[n - 1];
                return Math.Max(option1, option2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                    return "0";

                bool isNegative = decimalNumber < 0;
                uint number = isNegative ? (uint)(-decimalNumber) : (uint)decimalNumber;

                char[] binary = new char[32];
                int index = binary.Length;
                
                while (number > 0)
                {
                    binary[--index] = (number % 2 == 0) ? '0' : '1';
                    number /= 2;
                }
                string result = new string(binary, index, binary.Length - index);
                return isNegative ? "-" + result : result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    throw new ArgumentException("Input array cannot be null or empty");

                int left = 0;
                int right = nums.Length - 1;

                if (nums[left] <= nums[right])
                    return nums[left];

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[mid + 1])
                        return nums[mid + 1];
                    
                    if (nums[mid - 1] > nums[mid])
                        return nums[mid];
                    
                    if (nums[mid] > nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0)
                    return false;
                
                if (x < 10)
                    return true;
                
                if (x % 10 == 0)
                    return false;

                int reversed = 0;
                int original = x;
                
                while (x > 0)
                {
                    reversed = reversed * 10 + x % 10;
                    x /= 10;
                }
                
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Handle base cases
                if (n <= 1)
                    return n;
                
                // Initialize memoization array
                int[] fib = new int[n + 1];
                fib[0] = 0;
                fib[1] = 1;
                
                // Build Fibonacci sequence bottom-up
                for (int i = 2; i <= n; i++)
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }
                
                return fib[n];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
