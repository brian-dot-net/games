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

        [Fact]
        public void One0()
        {
            const string Expected = @"
xx..
.x..
.x..
.x..
";
            ShouldBeString(Nmbr.One0, Expected);
        }

        [Fact]
        public void One1()
        {
            const string Expected = @"
...x
xxxx
....
....
";
            ShouldBeString(Nmbr.One1, Expected);
        }

        [Fact]
        public void One2()
        {
            const string Expected = @"
x...
x...
x...
xx..
";
            ShouldBeString(Nmbr.One2, Expected);
        }

        [Fact]
        public void One3()
        {
            const string Expected = @"
xxxx
x...
....
....
";
            ShouldBeString(Nmbr.One3, Expected);
        }

        [Fact]
        public void Two0()
        {
            const string Expected = @"
.xx.
.xx.
xx..
xxx.
";
            ShouldBeString(Nmbr.Two0, Expected);
        }

        private static void ShouldBeString(Nmbr n, string expected)
        {
            n.ToString().Should().Be(expected.TrimStart());
        }
    }
}
