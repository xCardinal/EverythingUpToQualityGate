using NUnit.Framework;
using ConsoleApp1;

namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //KODE KATA 2
        [TestCase(new int[] {10,11,12,13,14,15,15,16}, 6)]
        [TestCase(new int[] {int.MaxValue, int.MaxValue}, 0)]
        [TestCase(new int[] { 10, 11, 12, 13, 14, 15, 15, 16, 240 }, 230)]
        public void GivenANewListReturnsTheBiggestDifferenceOf_TwoNumbers(int[] array, int result)
        {
            Assert.That(() => Program.DiffBetweenTwoElements(array), Is.EqualTo(result));
        }

        //KODE KATA 3
        [TestCase(19,"Celsius",51)]
        [TestCase(32, "Fahrenheit", 0)]
        [TestCase(269.6, "Fahrenheit", 132.0)]
        public void GivenATempInCelsiusORGahrenheit_ReturnTheRightTemperature(double firstTemp, string currentModel, double resultTemp)
        {
            Assert.That(() => Program.Conversion(firstTemp, currentModel), Is.EqualTo(resultTemp).Within(0.0001));
        }
        
    }
}