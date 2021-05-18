using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class OwnerTest
    {
        [Fact]
        public void TestCase1()
        {
            var owner = new Owner("Alex", "Trebek", "alex@alex.com", "Host");

            owner.FirstName.Should().Be("Alex");
            owner.LastName.Should().Be("Trebek");
            owner.Email.Should().Be("alex@alex.com");
            owner.JobTitle.Should().Be("Host");
        }

        [Fact]
        public void TestCase2()
        {
            var owner = new Owner("Alex", "Trebek", "alex@alex.com", "Host");

            var todo1 = new Todo("Do stuff", owner);
            var todo2 = new Todo("Do more stuff", owner);

            todo1.getOwner().FirstName.Should().Be("Alex");
            todo2.getOwner().FirstName.Should().Be("Alex");
            todo1.getOwner().LastName.Should().Be("Trebek");
            todo2.getOwner().LastName.Should().Be("Trebek");

            owner.ChangeFirstName("Gday");
            owner.ChangeLastName("Mate");

            todo1.getOwner().FirstName.Should().Be("Gday");
            todo2.getOwner().FirstName.Should().Be("Gday");
            todo1.getOwner().LastName.Should().Be("Mate");
            todo2.getOwner().LastName.Should().Be("Mate");
        }
    }
}