using System;

namespace StringCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to the String Calculator!");
            Console.WriteLine("Examples: ");
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1 = ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(StringCalculator.Add("1"));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("1,1 = ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(StringCalculator.Add("1,1"));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("//;\\n1;1 = ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(StringCalculator.Add("//;\n1;1"));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("//[***]\\n1***1 = ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(StringCalculator.Add("//[***]\n1***1"));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("//[***][###]\\n1***2###3 = ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(StringCalculator.Add("//[***][###]\n1***2###3"));            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();            
        }
    }
}
