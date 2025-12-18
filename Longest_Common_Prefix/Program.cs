using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Common_Prefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();

            string[] arr = new string[] { "flower", "flow", "flight" };

            Console.WriteLine(sol.LongestCommonPrefix(arr));
        }
    }

    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            Array.Sort(strs);

            string firstWord = strs[0];
            string lastWord = strs[strs.Length - 1];

            int minLength = Math.Min(firstWord.Length, lastWord.Length);

            int i = 0;
            while (i < minLength && firstWord[i] == lastWord[i])
            {
                i++;
            }

            return lastWord.Substring(0, i);
        }
    }
}
