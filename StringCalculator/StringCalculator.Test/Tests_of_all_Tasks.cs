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

        [DataTestMethod]
        [DataRow("1,1", 2)]
        [DataRow("2,2", 4)]
        [DataRow("3,3", 6)]
        public void Add_Method_Returns_Sum_Of_Two_Comma_Separated_Numbers(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);                      
        }
    }

    [TestClass]
    public class Task_2_Tests
    {
        [DataTestMethod]
        [DataRow("6", 6)]
        [DataRow("3,3", 6)]
        [DataRow("2,2,2", 6)]
        [DataRow("1,1,1,1,1,1", 6)]
        public void Add_Method_Handles_Unknown_Amount_Of_Numbers(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);
        }
    }

    [TestClass]    
    public class Task_3_Tests
    {
        [DataTestMethod]
        [DataRow("6", 6)]
        [DataRow("3\n3", 6)]
        [DataRow("2\n2\n2", 6)]
        [DataRow("1\n1\n1\n1\n1\n1", 6)]
        public void Add_Method_Handles_New_Lines_Between_Numbers(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);
        }
    }

    [TestClass]
    public class Task_4_Tests
    {
        [DataTestMethod]
        [DataRow("6", 6)]
        [DataRow("//;\n3;3", 6)]
        [DataRow("//!\n2!2!2", 6)]
        [DataRow("//|\n1|1|1|1|1|1", 6)]
        public void Add_Method_Supports_Different_Delimiters(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);
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

        [DataTestMethod]
        [DataRow("-1,-2,-3", new int [] {-1,-2,-3})]
        [DataRow("-1,-2,-3,1001", new int [] {-1,-2,-3})]
        public void Add_Method_Throws_An_Exception_For_Multiple_Negative_Numbers_And_Returns_Them(string input, int [] expected)
        {
            var negativeNumbers = new List<int>();
            var actualNegativeNumbers = new List<int>(expected);
            try
            {
                StringCalculator.Add(input);
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
        [DataTestMethod]
        [DataRow("1001")]
        [DataRow("2001")]
        [DataRow("3001")]
        [DataRow("4001")]
        [DataRow("5001")]
        [DataRow("6001")]
        [DataRow("7001")]
        [DataRow("8001")]
        [DataRow("9001")]        
        public void Add_Method_Should_Return_Zero_If_Number_Is_Bigger_Than_1000(string input)
        {
            Assert.AreEqual(StringCalculator.Add(input), 0);
        }

        [DataTestMethod]
        [DataRow("1001,2", 2)]
        [DataRow("1001\n2\n1001", 2)]
        [DataRow("//:\n1001:2:1001", 2)]
        public void Add_Method_Ignores_Numbers_Greater_1000(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);
        }
    }

    [TestClass]
    public class Task_7_Tests
    {
        [DataTestMethod]
        [DataRow("//[***]\n1***2***3", 6)]
        [DataRow("//[!!!!]\n1!!!!2!!!!3", 6)]
        [DataRow("//[||||]\n1||||2||||3", 6)]
        public void Add_Method_Supports_Delimiters_Of_Any_Length(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);            
        }
    }

    [TestClass]
    public class Task_8_Tests
    {
        [DataTestMethod]
        [DataRow("//[*][%]\n1*2%3", 6)]
        [DataRow("//[*][%][!]\n2*2%1!1", 6)]
        [DataRow("//[*][%][!]\n1*1%1!1!1!1", 6)]
        [DataRow("//[*][%][!]\n2*1%1*1%1", 6)]
        public void Add_Method_Supports_Multiple_Single_Character_Delimiters(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);
        }
    }

    [TestClass]
    public class Task_9_Tests
    {
        [DataTestMethod]
        [DataRow("//[**][%%]\n1**2%%3", 6)]
        [DataRow("//[*#*][%#%]\n1*#*2%#%3", 6)]
        public void Add_Method_Supports_Multiple_Delimiters(string input, int expected)
        {
            Assert.AreEqual(StringCalculator.Add(input), expected);
        }
    }
}
