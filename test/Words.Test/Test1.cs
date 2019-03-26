// <copyright file="Test1.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using FluentAssertions;
    using Xunit;

    public sealed class Test1
    {
        [Fact]
        public void Test()
        {
            new Class1("example").ToString().Should().Be("[example]");
        }
    }
}
