using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Odd_Nums_In_Interval_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution testSolution = new Solution();

            Console.Write("Low = ");
            int low = int.Parse(Console.ReadLine());

            Console.Write("High = ");
            int high= int.Parse(Console.ReadLine());

            int output01 = testSolution.CountOddsMethod02(low, high);
            int ouput02 = testSolution.CountOddsMethod01(low, high);

            Console.WriteLine("First Output: {0}", output01);
            Console.WriteLine("Second Output: {0}", ouput02);
        }
    }

    public class Solution
    {
        public int CountOddsMethod01(int low, int high)
        {
            return (high + (high & 1) - low + (low & 1)) >> 1;
        }

        public int CountOddsMethod02(int low, int high)
        {
            int output = 0;
            if (0 <= low && high <= int.MaxValue)
            {
                while (low <= high)
                {

                    if (low % 2 == 1)
                    {
                        output++;
                    }

                    low++;
                }
            }
            else
            {
                Console.WriteLine("Number out of boundaries");
                return -1;
            }

            return output;
        }
    }
}
