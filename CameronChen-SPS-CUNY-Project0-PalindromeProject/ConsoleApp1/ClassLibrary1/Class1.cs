using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome2
{
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            //rid spaces
            s = s.Replace(" ", string.Empty);
            Console.WriteLine(s);
            //all lowercase
            s = s.ToLower();
            Console.WriteLine(s);
            //cast to char array
            char[] x = s.ToCharArray();
            Console.WriteLine(x);
            //reverse
            char[] y = s.ToCharArray();
            Array.Reverse(y);
            Console.WriteLine(y);
            //convert back to string
            string b = new string(x);
            string c = new string(y);
            //compare
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(string.Equals(b, c));
            return string.Equals(b, c);
        }
    }
}
