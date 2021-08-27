using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = { 2, 3, 1, 7, 9, 5, 11, 3, 5 };

            Console.WriteLine($"Original array: {String.Join(", ", numArray)}");

            Console.WriteLine($"Sorted Array: {String.Join(", ", SortArray(numArray))}");

            Console.WriteLine($"The maximum difference between two elements of the given array is : " +
                $"{DiffBetweenTwoElements(numArray)}");

            Console.WriteLine();

            Console.WriteLine("Please Choose One of following: ");
            Console.WriteLine("1 - Celsius\n2 - Fahrenheit");

            string tempType = Console.ReadLine();

            if (tempType == "1")
            {
                Console.WriteLine("You temperature in Celsius: ");
                tempType = "Celsius";
            }
            else if(tempType == "2")
            {
                Console.WriteLine("You temperature in Fahrenheit: ");
                tempType = "Fahrenheit";
            }
            
            var holdTemp = Console.ReadLine();

            double temperature;

            double.TryParse(holdTemp, out temperature);

            Console.WriteLine(Conversion(temperature, tempType));


        }
        //KODE KATA 2
        public static int DiffBetweenTwoElements(int[] nums)
        {

            // This method takes an Int Array and returns the MAX-imum difference between the contents of the array

            // In the example array above the out will be as follows:

            // Original array: 2, 3, 1, 7, 9, 5, 11, 3, 5
            // The maximum difference between two elements of the given array is : 10



            // Write your code here

            //find the smallest value,
            //find the biggest value
            //do the difference

            int min = nums[0];
            int max = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max) max = nums[i];
                else if (nums[i] < min) min = nums[i];
            }

            int diff = max - min;

            return diff;

        }

        public static double Conversion(double firstTemp, string currentModel)
        {
            switch(currentModel)
            {
                case "Fahrenheit":
                    //(32°F − 32) × 5/9 = 0°C
                    //Convert to Celsius
                    var result= ((firstTemp - 32.0) * (5.0 / 9.0));
                    return result;

                case "Celsius":
                    //(0°C × 9/5) + 32 = 32°F
                    //Convert to Fahrenheit
                    return (firstTemp * (9.0 / 5.0)) + 32.0;
                default:
                    return 0;
            }
            
        }

        //JUST TESTING KNOWLEDGE
        public static int[] SortArray(int[] myArray)
        {
            //Pick the first number 
            for (int i = 0; i < myArray.Length; i++)
            {
                //and check it against all of the other elements in the array
                for (int j = 0; j < myArray.Length; j++)
                {
                    if (myArray[i] < myArray[j])
                    {
                        int temporary = myArray[j];
                        myArray[j] = myArray[i];
                        myArray[i] = temporary;
                    }
                }
            }
            return myArray;
        }
    }
}
