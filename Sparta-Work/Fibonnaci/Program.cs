using System;
using System.Collections;

namespace Fibonnaci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(InvertArray("This is my string"));
            Console.WriteLine(InvertArrayUsingStack("This is my string"));
            Console.WriteLine(ReverseOfString("This is my string"));

            Console.WriteLine($"The Factorial of 5 is: {Factorial(5)}");
            Console.WriteLine($"The Factorial of 5 in recursion is: {Factorial(5)}");
        }

        private static void FibonnaciSequence()
        {
            //Create a method which returns the sum of fibonacci numbers up to the nth fibonacci number.

            var result = 0;
            int[] arrayOfFibo = new int[11];

            arrayOfFibo[0] = 0;
            arrayOfFibo[1] = 1;

            var keepTrack = arrayOfFibo[0] + arrayOfFibo[1];

            result += keepTrack;
            for (int i = 2; i < arrayOfFibo.Length; i++)
            {
                //0 1 1 2 3 5 8 13 21 34 55

                arrayOfFibo[i] = arrayOfFibo[i - 2] + arrayOfFibo[i - 1];
                result += arrayOfFibo[i];

            }

            Console.WriteLine(result);
        }

        public static char[] InvertArray(string x)
        {
            var oldArray = x.ToCharArray();
            int j = 0;
            var newArray = new char[oldArray.Length];

            for (int i = oldArray.Length-1; i>= 0; i--)
            {
                newArray[j] = oldArray[i];
                j++;
            }

            return newArray;
        }

        public static char[] InvertArrayUsingStack(string x)
        {
            Stack newStack = new();
            var newArray = new char[x.Length];

            foreach(var element in x)
            {
                newStack.Push(element);
            }
            for(int i=0; i<x.Length;i++)
            {
                newArray[i] = (char)newStack.Pop();
            }

            return newArray;
        }

        public static string ReverseOfString(string str)
        {
            if (str.Length <= 1) return str;

            else
            {
                return ReverseOfString(str.Substring(1)) + str[0];

                //Factorial(5) = 5 * Factorial(4)
                //Factorial(4) = 4 * Factorial(3)
                //Factorial(3) = 3 * Factorial(2)
                //Factorial(2) = 2 * Factorial(1)
                //Factorial(1) = 1 ;
            }
        }

        public static double AverageMarks(string inputMarks)
        {
            int posOne = inputMarks.IndexOf(" ");
            string one = inputMarks.Substring(0, posOne);
            var middle = GetIndex(inputMarks, " ", 2);
            string two = inputMarks.Substring(posOne, middle);
            string three = inputMarks.Substring(middle);

            double num1 = double.Parse(one);
            double num2 = double.Parse(two);
            double num3 = double.Parse(three);

            double sum = num1 + num2 + num3;
            double result = sum / 3;
            return result;
        }


        public static int GetIndex(string input, string space)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == space)
                {
                    count++;
                }
            }
            return count;
        }

        public static int GetIndex(string input, string space, int n)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == space)
                {
                    count++;
                    if (n == count)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static int Factorial(int x)
        {
            int result = 1;

            for(int i = x; i>0; i--)
            {
                result *= i;
            }
            return result;
        }

        public static int FactorialWithRecursion(int x)
        {
            if (x == 1) return 1;
            return x * FactorialWithRecursion(x - 1);
        }
    }
}
