using System;
using Xunit;

namespace ConsoleApp.Test
{
    public class MathHelperTest
    {
        [Fact]
        public void IsEvenTest()
        {
            var calc = new MathHelper();
            int x = 1;
            int y = 2;

            var xresult = calc.IsEven(x);
            var yresult = calc.IsEven(y);

            Assert.False(xresult);

            Assert.True(yresult);
        }

        [Theory]
        [InlineData(1,2,1)]
        [InlineData(1, 3, 2)]
        [InlineData(1, 5, 4)]
        public void DiffTest(int x , int y , int expectedValue)
        {
            var calc = new MathHelper();
            var result = calc.Diff(x, y);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(new int[] {1,2,3 },6)]
        [InlineData(new int[] {1,-5,-8 },-12)]
        public void SumTest(int[] values , int expectedValue)
        {
            var calc = new MathHelper();
            var result = calc.Sum(values);

            Assert.Equal(expectedValue, result);
        }

        [Theory]

        [InlineData(3,3, 6)]
        [InlineData(3,5, 8)]

        public void AddTest(int x , int y, int expectedResult)
        {
            var calc = new MathHelper();

            var result = calc.Add(x, y);

            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2)]

        public void AverageTest(int[] values, int expectedResult)
        {
            var calc = new MathHelper();

            var result = calc.Average(values);

            Assert.Equal(expectedResult, result);
        }
    }
}
