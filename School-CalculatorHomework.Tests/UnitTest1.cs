using System;
using Xunit;
using School_CalculatorHomework;

namespace School_CalculatorHomework.Tests
{
    public class MathOperatorTests
    {
        [Theory]
        [InlineData(0, 432, 0)]
        [InlineData(32, 50.5, 0.633)]
        [InlineData(-32, 50.5, -0.633)]
        public void DivisionTests(double num1, double num2, double expected)
        {
            double actual = Program.Divide(num1, num2);

            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void DivisionByZeroTest()
        {
            double num1 = 5;
            double num2 = 0;
            double expected = -1;

            double actual = Program.Divide(num1, num2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 432, 0)]
        [InlineData(32, 50.5, 32)]
        [InlineData(-32, 50.5, -32)]
        public void ModulusTests(double num1, double num2, double expected)
        {
            double actual = Program.Modulus(num1, num2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ModulusByZeroTest()
        {
            double num1 = 5;
            double num2 = 0;
            double expected = -1;

            double actual = Program.Modulus(num1, num2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(30.6, 50.5, 1545.30)]
        [InlineData(532, 97, 51604)]
        [InlineData(-2, -98, 196)]
        [InlineData(3, 5, 15)]
        public void MultiplicationTests(double num1, double num2, double expected)
        {
            double actual = Program.Multiply(num1, num2);

            Assert.Equal(expected, actual, 2);
        }

        [Theory]
        [InlineData(30.6, 50.5, 81.1)]
        [InlineData(532, 97, 629)]
        [InlineData(-2, -98, -100)]
        [InlineData(3, 5, 8)]
        public void AdditionTests(double num1, double num2, double expected)
        {
            double actual = Program.Add(num1, num2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new double[] { 4, 3, 2 }, 9)]
        [InlineData(new double[] { -53, -96, -25 }, -174)]
        [InlineData(new double[] { 871, 496, 356 }, 1723)]
        public void AdditionArrayTests(double[] numArray, double expected)
        {
            double actual = Program.Add(numArray);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(30.6, 50.5, -19.9)]
        [InlineData(532, 97, 435)]
        [InlineData(-2, -98, 96)]
        [InlineData(3, 5, -2)]
        public void SubtractionTests(double num1, double num2, double expected)
        {
            double actual = Program.Subtract(num1, num2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new double[] { 4, 3, 2 }, -1)]
        [InlineData(new double[] { -53, -96, -20 }, 63)]
        [InlineData(new double[] { 871, 496, -356 }, 731)]
        public void SubtractionArrayTests(double[] numArray, double expected)
        {
            double actual = Program.Subtract(numArray);

            Assert.Equal(expected, actual);
        }
    }
}