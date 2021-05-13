using System;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace App.Tests
{
    public class ApplicationTest
    {
        [Fact]
        public void AppShouldRunWithoutError()
        {
            string[] args = {};
            Program.Main(args);
        }
    }
}
