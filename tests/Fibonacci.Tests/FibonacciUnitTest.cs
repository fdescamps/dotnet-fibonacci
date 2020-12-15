using Xunit;

namespace Fibonacci.Tests
{
    public class FibonacciUnitTest
    {
        [Fact]
        public void Execute44ShouldSuccess()
        {
            var results = Compute.Execute(new []{"44"});
            Assert.Equal(701408733, results[0]);
        }
    }
}
