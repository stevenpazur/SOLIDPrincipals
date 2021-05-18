using Xunit;

namespace App.Tests
{
    public class ApplicationTest
    {
        [Fact]
        public void AppShouldRunWithoutError()
        {
            string[] args = { };
            Program.Main(args);
        }
    }
}