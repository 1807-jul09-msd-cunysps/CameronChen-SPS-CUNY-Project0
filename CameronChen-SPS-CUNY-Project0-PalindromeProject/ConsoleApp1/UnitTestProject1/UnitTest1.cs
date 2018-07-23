using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string st = "A nut for a jar of tuna";
            bool expectedValue = true;

            Palindrome var = new Palindrome();
            bool actualValue = var.IsPalindrome(st);

            Assert.AreEqual(expectedValue, actualValue);

            //test
        }
    }
}
