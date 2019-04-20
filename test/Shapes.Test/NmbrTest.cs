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

        [Fact]
        public void Two3()
        {
            const string Expected = @"
x x . x 
x x x x 
. . x x 
. . . . 
";
            ShouldBeString(Nmbr.Two3, Expected);
        }

        [Fact]
        public void Three0()
        {
            const string Expected = @"
x x x . 
. . x . 
. x x . 
x x x . 
";
            ShouldBeString(Nmbr.Three0, Expected);
        }

        [Fact]
        public void Three1()
        {
            const string Expected = @"
x . . x 
x x . x 
x x x x 
. . . . 
";
            ShouldBeString(Nmbr.Three1, Expected);
        }

        [Fact]
        public void Three2()
        {
            const string Expected = @"
x x x . 
x x . . 
x . . . 
x x x . 
";
            ShouldBeString(Nmbr.Three2, Expected);
        }

        [Fact]
        public void Three3()
        {
            const string Expected = @"
x x x x 
x . x x 
x . . x 
. . . . 
";
            ShouldBeString(Nmbr.Three3, Expected);
        }

        [Fact]
        public void Four0()
        {
            const string Expected = @"
. x x . 
. x . . 
x x x . 
. x x . 
";
            ShouldBeString(Nmbr.Four0, Expected);
        }

        [Fact]
        public void Four1()
        {
            const string Expected = @"
. x . . 
x x x x 
x x . x 
. . . . 
";
            ShouldBeString(Nmbr.Four1, Expected);
        }

        [Fact]
        public void Four2()
        {
            const string Expected = @"
x x . . 
x x x . 
. x . . 
x x . . 
";
            ShouldBeString(Nmbr.Four2, Expected);
        }

        [Fact]
        public void Four3()
        {
            const string Expected = @"
x . x x 
x x x x 
. . x . 
. . . . 
";
            ShouldBeString(Nmbr.Four3, Expected);
        }

        [Fact]
        public void Five0()
        {
            const string Expected = @"
x x x . 
x x x . 
. . x . 
x x x . 
";
            ShouldBeString(Nmbr.Five0, Expected);
        }

        [Fact]
        public void Five1()
        {
            const string Expected = @"
x . x x 
x . x x 
x x x x 
. . . . 
";
            ShouldBeString(Nmbr.Five1, Expected);
        }

        [Fact]
        public void Five2()
        {
            const string Expected = @"
x x x . 
x . . . 
x x x . 
x x x . 
";
            ShouldBeString(Nmbr.Five2, Expected);
        }

        [Fact]
        public void Five3()
        {
            const string Expected = @"
x x x x 
x x . x 
x x . x 
. . . . 
";
            ShouldBeString(Nmbr.Five3, Expected);
        }

        [Fact]
        public void Six0()
        {
            const string Expected = @"
x x . . 
x . . . 
x x x . 
x x x . 
";
            ShouldBeString(Nmbr.Six0, Expected);
        }

        [Fact]
        public void Six1()
        {
            const string Expected = @"
x x x x 
x x . x 
x x . . 
. . . . 
";
            ShouldBeString(Nmbr.Six1, Expected);
        }

        private static void ShouldBeString(Nmbr n, string expected)
        {
            n.ToString().Should().Be(expected.TrimStart());
        }
    }
}
