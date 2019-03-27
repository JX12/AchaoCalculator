using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using My_calculator;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ;
            
            
        }
        static void Main(string[] args)
        {
           Oprate[] a = new Oprate[4];
            a[0].label = 0; a[0].opre = '+';
            a[1].label = 1; a[1].opre = '*';
            a[2].label = 1; a[2].opre = '/';
            int[] Num = new int[5];
            Num[0] = 2; Num[1] = 3; Num[2] = 5; Num[3] = 5;
            My_calcula c = new My_calcula(1);
            Assert.AreEqual(5, c.Cal(5, Num, a)); 
        }
    }
}
