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
x x x . 
x . x . 
x . x . 
x x x . 
";
            ShouldBeString(Nmbr.Zero0, Expected);
        }

        [Fact]
        public void Zero1()
        {
            const string Expected = @"
x x x x 
x . . x 
x x x x 
. . . . 
";
            ShouldBeString(Nmbr.Zero1, Expected);
        }

        [Fact]
        public void One0()
        {
            const string Expected = @"
x x . . 
. x . . 
. x . . 
. x . . 
";
            ShouldBeString(Nmbr.One0, Expected);
        }

        [Fact]
        public void One1()
        {
            const string Expected = @"
. . . x 
x x x x 
. . . . 
. . . . 
";
            ShouldBeString(Nmbr.One1, Expected);
        }

        [Fact]
        public void One2()
        {
            const string Expected = @"
x . . . 
x . . . 
x . . . 
x x . . 
";
            ShouldBeString(Nmbr.One2, Expected);
        }

        [Fact]
        public void One3()
        {
            const string Expected = @"
x x x x 
x . . . 
. . . . 
. . . . 
";
            ShouldBeString(Nmbr.One3, Expected);
        }

        [Fact]
        public void Two0()
        {
            const string Expected = @"
. x x . 
. x x . 
x x . . 
x x x . 
";
            ShouldBeString(Nmbr.Two0, Expected);
        }

        [Fact]
        public void Two1()
        {
            const string Expected = @"
x x x . 
x x x x 
x . x x 
. . . . 
";
            ShouldBeString(Nmbr.Two1, Expected);
        }

        [Fact]
        public void Two2()
        {
            const string Expected = @"
x x x . 
. x x . 
x x x . 
x x . . 
";
            ShouldBeString(Nmbr.Two2, Expected);
        }

        private static void ShouldBeString(Nmbr n, string expected)
        {
            n.ToString().Should().Be(expected.TrimStart());
        }
    }
}
