// <copyright file="NmbrTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes.Test
{
    using FluentAssertions;
    using Xunit;

    public sealed class NmbrTest
    {
        [Fact]
        public void Zero0()
        {
            const string Expected = @"
xxx.
x.x.
x.x.
xxx.
";
            ShouldBeString(Nmbr.Zero0, Expected);
        }

        [Fact]
        public void Zero1()
        {
            const string Expected = @"
xxxx
x..x
xxxx
....
";
            ShouldBeString(Nmbr.Zero1, Expected);
        }

        private static void ShouldBeString(Nmbr n, string expected)
        {
            n.ToString().Should().Be(expected.TrimStart());
        }
    }
}
