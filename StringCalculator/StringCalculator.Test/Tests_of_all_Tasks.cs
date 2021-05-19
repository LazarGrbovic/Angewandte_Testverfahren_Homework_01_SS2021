using Microsoft.VisualStudio.TestTools.UnitTesting;

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
}
