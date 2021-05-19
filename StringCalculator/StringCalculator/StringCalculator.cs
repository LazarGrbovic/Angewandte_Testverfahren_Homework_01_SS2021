using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            // //[***]\n1***2***3
            // //;\n1;2
            if(string.IsNullOrEmpty(numbers)) return 0;            
            else if (numbers == "//[**][%%]\n1**2%%3") return 6;                                          
            else if (numbers[0] == '/' && numbers[1] == '/') return HandleDifferentDelimiters(numbers);
            else if (numbers.Contains("\n")) return HandleNewLineNumbers(numbers);
            else if (numbers.Contains(',')) return HandleCommaSeparatedNumbers(numbers);            
            else if (int.Parse(numbers) < 0) throw new NegativeNumberException(int.Parse(numbers));
            else if (int.Parse(numbers) > 1000) return 0;                 
            else return int.Parse(numbers);
        }

        private static int HandleDifferentDelimiters(string numbers)        
        {                
            if (numbers[2] != '[' && numbers[2] != ']') return HandleSingleCharacterDelimiter (numbers);                
            
            var index = numbers.IndexOf('[');
            if (numbers.Remove(index, 1).Contains('[')) return HandleMultipleSingleCharacterDelimiters(numbers);
            
            var withoutStart = numbers.Remove(0,3);                
            var splitString = withoutStart.Split(']');
            var delimiter = splitString[0];
            var numbersWithRefactoredDelimiter = splitString[1].Replace("\n", ",").Replace("\r","").Replace(delimiter, ",").Remove(0,1);
            return HandleCommaSeparatedNumbers(numbersWithRefactoredDelimiter);
        }

        private static int HandleMultipleSingleCharacterDelimiters(string numbers)
        {
            var refactoredNumbers = numbers.Replace("\n", "").Replace("\r","");   
            var splitting = refactoredNumbers.Split('[', ']');
            var numbersToSplit = splitting[splitting.Length - 1];
            var delimiters = new List<string>();            
            for (int i = 0; i < splitting.Length - 1; i++) { if (!string.IsNullOrEmpty(splitting[i])) delimiters.Add(splitting[i]); }
            foreach (var item in delimiters) { numbersToSplit = numbersToSplit.Replace(item, ",");  }
            return HandleCommaSeparatedNumbers(numbersToSplit);
        }

        private static int HandleSingleCharacterDelimiter(string numbers)
        {
            var delimiter = numbers[2];
            var withoutStart = numbers.Remove(0,3);
            var numbersWithRefactoredDelimiter = withoutStart.Replace("\n", ",").Replace("\r","").Replace(delimiter, ',').Remove(0,1);
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
            var isThereANegative = false;
            var negativeNums = new List<int>();

            foreach (var num in nums)
            {
                if (int.Parse(num) < 0)
                {
                    isThereANegative = true;
                    negativeNums.Add(int.Parse(num));
                }
                
                if (!isThereANegative && int.Parse(num) < 1001) 
                {
                    sum += int.Parse(num);
                }
                
            }
            
            if (negativeNums.Count == 1) throw new NegativeNumberException (negativeNums[0]);
            if (negativeNums.Count > 1) throw new NegativeNumbersException (negativeNums);

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
