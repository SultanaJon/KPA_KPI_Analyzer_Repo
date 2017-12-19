using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int total = 134072;
            int totalUnconfirmed = 11067;

            double percent = Math.Round((double)totalUnconfirmed / (total + totalUnconfirmed) * 100, 2);

            if(percent != 7.63)
            {
                Assert.Fail();
            }
        }
    }
}
