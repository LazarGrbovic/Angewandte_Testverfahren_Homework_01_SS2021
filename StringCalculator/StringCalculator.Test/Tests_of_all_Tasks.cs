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

        [TestMethod]
        public void Add_Method_Returns_Number_For_A_Single_Number_Input()
        {
            Assert.AreEqual(StringCalculator.Add("1"), 1);
        }
    }
}
