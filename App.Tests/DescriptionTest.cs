using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class DescriptionTest
    {
        [Fact]
        public void itHasADescription() {
            DescriptionRepository desc = new DescriptionRepository();
            desc.setDescription("There's a million things he hasn't done");
            desc.getDescription().Should().Be("There's a million things he hasn't done");
        }
    }
}