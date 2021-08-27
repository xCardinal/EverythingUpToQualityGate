using NUnit.Framework;
using Fibonnaci;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Hello")]
        public void Given(string textString)
        {
            char[] charArray = textString.ToCharArray();
            System.Array.Reverse(charArray);

            Assert.That(Program.ReverseOfString(textString), Is.EqualTo(new string(charArray)));
        }
    }
}