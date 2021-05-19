using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace StringCalculator.Test
{
    [TestClass]
    public class Task_1_Tests
    {
        [TestMethod]
        public void Add_Method_Returns_Zero_For_Empty_String_Input()
        {
            Assert.AreEqual(StringCalculator.Add(""), 0);            
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(1000)]
        public void Add_Method_Returns_Number_For_A_Single_Number_Input(int number)
        {
            Assert.AreEqual(StringCalculator.Add(number.ToString()), number);
        }

        [TestMethod]
        public void Add_Method_Returns_Sum_Of_Two_Comma_Separated_Numbers()
        {
            Assert.AreEqual(StringCalculator.Add("1,1"), 2);
            Assert.AreEqual(StringCalculator.Add("2,2"), 4);
            Assert.AreEqual(StringCalculator.Add("3,3"), 6);
        }
    }

    [TestClass]
    public class Task_2_Tests
    {
        [DataTestMethod]
        [DataRow("6")]
        [DataRow("3,3")]
        [DataRow("2,2,2")]
        [DataRow("1,1,1,1,1,1")]
        public void Add_Method_Handles_Unknown_Amount_Of_Numbers(string input)
        {
            Assert.AreEqual(StringCalculator.Add(input), 6);
        }
    }

    [TestClass]    
    public class Task_3_Tests
    {
        [DataTestMethod]
        [DataRow("6")]
        [DataRow("3\n3")]
        [DataRow("2\n2\n2")]
        [DataRow("1\n1\n1\n1\n1\n1")]
        public void Add_Method_Handles_New_Lines_Between_Numbers(string input)
        {
            Assert.AreEqual(StringCalculator.Add(input), 6);
        }
    }

    [TestClass]
    public class Task_4_Tests
    {
        [DataTestMethod]
        [DataRow("6")]
        [DataRow("//;n3;3")]
        [DataRow("//!n2!2!2")]
        [DataRow("//|n1|1|1|1|1|1")]
        public void Add_Method_Supports_Different_Delimiters(string input)
        {
            Assert.AreEqual(StringCalculator.Add(input), 6);
        }
    }

    [TestClass]  
    public class Task_5_Tests
    {
        [DataTestMethod]                
        [DataRow("-6")]
        [DataRow("-3")]
        [DataRow("-2")]
        [DataRow("-1")]
        [DataRow("-10")]
        [DataRow("-100")]
        [DataRow("-1000")]
        [ExpectedException (typeof(NegativeNumberException))]
        public void Add_Method_Throws_An_Exception_For_A_Negative_Number(string input)
        {
            StringCalculator.Add(input);
        }
        
        [DataTestMethod]                
        [DataRow("-6")]
        [DataRow("-3")]
        [DataRow("-2")]
        [DataRow("-1")]
        [DataRow("-10")]
        [DataRow("-100")]
        [DataRow("-1000")]
        public void Add_Method_Throws_An_Exception_For_A_Negative_Number_And_Returns_It(string input)
        {
            var caughtNum = 0;

            try
            {
                StringCalculator.Add(input);
                Assert.Fail();
            }
            catch (NegativeNumberException e)
            {
                caughtNum = e.Number;                    
            }

            Assert.AreEqual(caughtNum, int.Parse(input));
        }

        [DataTestMethod]                        
        [DataRow("-3,-3")]
        [DataRow("-2,-2")]
        [DataRow("-1,-1")]
        [DataRow("-10,-10")]
        [DataRow("-100,-100")]
        [DataRow("-1000,-1000")]
        [ExpectedException (typeof(NegativeNumbersException))]        
        public void Add_Method_Throws_An_Exception_For_Multiple_Negative_Numbers(string input)
        {
            StringCalculator.Add(input);
        }

        [TestMethod]
        public void Add_Method_Throws_An_Exception_For_Multiple_Negative_Numbers_And_Returns_Them()
        {
            var negativeNumbers = new List<int>();
            var actualNegativeNumbers = new List<int>() {-1, -2, -3};
            try
            {
                StringCalculator.Add("-1,-2,-3");
                Assert.Fail();
            }
            catch (NegativeNumbersException e)
            {                       
                if (e.Numbers.Count != actualNegativeNumbers.Count) Assert.Fail();
                negativeNumbers = e.Numbers;             
                for (int i = 0; i < negativeNumbers.Count; i++)
                {
                    if (negativeNumbers[i] != actualNegativeNumbers[i]) Assert.Fail();       
                }
            }
        }
    }

    [TestClass]
    public class Task_6_Tests
    {
        [TestMethod]
        public void Add_Method_Should_Return_Zero_If_Number_Is_Bigger_Than_1000()
        {
            Assert.AreEqual(StringCalculator.Add("1001"), 0);
        }
    }
}
