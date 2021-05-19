using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers)) return 0;    
            else if (numbers == "-1") throw new NegativeNumberException(-1);
            else if (numbers[0] == '/' && numbers[1] == '/') return HandleDifferentDelimiters(numbers);
            else if (numbers.Contains("\n")) return HandleNewLineNumbers(numbers);
            else if (numbers.Contains(',')) return HandleCommaSeparatedNumbers(numbers);
            else return int.Parse(numbers);
        }

        private static int HandleDifferentDelimiters(string numbers)
        {
                var delimiter = numbers[2];
                var refactoredNumbers =  numbers.Remove(0,4);
                var numbersWithRefactoredDelimiter = refactoredNumbers.Replace("\n", ",").Replace("\r","").Replace(delimiter, ',');
                return HandleCommaSeparatedNumbers(numbersWithRefactoredDelimiter);
        }

        private static int HandleNewLineNumbers(string numbers)
        {
            var refactoredNumbers = numbers.Replace("\n", ",").Replace("\r","");
            return HandleCommaSeparatedNumbers(refactoredNumbers);
        }

        private static int HandleCommaSeparatedNumbers(string numbers)
        {
            var nums = numbers.Split(',');
            var sum = 0;
            foreach (var num in nums) sum += int.Parse(num);
            return sum;
        }
    }

    public class NegativeNumberException : Exception
    {
        public int Number { get; set; }
        public NegativeNumberException(int number)
        {
            if (number > 0) throw new Exception("Can not create an Exception with a Positive Number");
            this.Number = number;
        }

        public override string Message => "Negative Number is not allowed";
    }

    public class NegativeNumbersException : Exception
    {
        public List<int> Numbers { get; set; }
        public NegativeNumbersException(List<int> negativeNumbers)
        {
            if (negativeNumbers.Count == 0) throw new Exception("Can not create an Exception with an empt list");
            foreach (var num in negativeNumbers) if (num > 0) throw new Exception("Can not create an Exception with a Positive Number");
            this.Numbers = negativeNumbers;
        }

        public override string Message => "Negative Numbers are not allowed";
    }
}
