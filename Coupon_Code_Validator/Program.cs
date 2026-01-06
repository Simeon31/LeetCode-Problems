using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coupon_Code_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            Solution02 sol02 = new Solution02();

            string[] code = { "SAVE20", "", "PHARMA5", "SAVE@20" };
            string[] businessLine = { "restaurant", "grocery", "pharmacy", "restaurant"  };
            bool[] isActive = { true, true, true, true };

            Console.WriteLine("Sol01: " + string.Join(", ", sol.ValidateCoupons(code, businessLine, isActive)));
            Console.WriteLine("Sol02: " + string.Join(", ", sol02.ValidateCoupons(code, businessLine, isActive)));
        }
    }

    public class Solution
    {
        public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
        {
            List<(string Coupon, string BusinessLine)> coupon = new List<(string, string)>();
            List<string> allowedCategories = new List<string> { "electronics", "grocery", "pharmacy", "restaurant" };

            for (int i = 0; i < code.Length; i++)
            {
                if (isActive[i] &&
                    !string.IsNullOrWhiteSpace(code[i]) &&
                    allowedCategories.Contains(businessLine[i]) &&
                    code[i].All(ch => char.IsLetterOrDigit(ch) || ch == '_'))
                {
                    coupon.Add((code[i], businessLine[i]));
                }
            }

            var comparer = Comparer<(string Code, string BusinessLine)>.Create((x, y) =>
            {
                int cmp = allowedCategories.IndexOf(x.BusinessLine).CompareTo(allowedCategories.IndexOf(y.BusinessLine));
                if (cmp != 0) return cmp;
                return string.Compare(x.Code, y.Code, StringComparison.Ordinal);
            });

            coupon.Sort(comparer);

            return coupon.Select(c => c.Coupon).ToList();
        }   
    }

    public class Solution02
    {
        public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
        {
            var validBussinessLines = new HashSet<string>() { "electronics", "grocery", "pharmacy", "restaurant" };
            Func<string, bool> validCodeCheck = s => (!String.IsNullOrEmpty(s) && s.All(c => char.IsLetterOrDigit(c) || c == '_'));
            var result = new List<(string Code, string BusinessLine)>();

            for (int i = 0; i < code.Length; i++)
            {
                if (!validCodeCheck(code[i]))
                {
                    continue;
                }
                if (!validBussinessLines.Contains(businessLine[i]))
                {
                    continue;
                }
                if (!isActive[i])
                {
                    continue;
                }

                //Qualifies checks
                result.Add((code[i], businessLine[i]));
            }

            // Custom comparer for sorting
            var businessOrder = new List<string> { "electronics", "grocery", "pharmacy", "restaurant" };
            var comparer = Comparer<(string Code, string BusinessLine)>.Create((x, y) =>
            {
                int cmp = businessOrder.IndexOf(x.BusinessLine).CompareTo(businessOrder.IndexOf(y.BusinessLine));
                if (cmp != 0) return cmp;
                return string.Compare(x.Code, y.Code, StringComparison.Ordinal);
            });

            result.Sort(comparer);

            return result.Select(r => r.Code).ToList();
        }
    }
}
