using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindrome2;

namespace MainFunction
{
    public class Program
    {
        static void Main(string[] args)
        {
            string st = "A nut for a jar of tuna";
            Palindrome var = new Palindrome();
            bool check = var.IsPalindrome(st);

            Console.Read();

        }

    }
}
