using Xunit;

namespace ToDoApp.Tests
{
    public class ModelTests
    {
        [Fact]
        public void MethodTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        private int Add(int x, int y)
        {
            return x + y;
        }
    }
}
