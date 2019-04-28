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
0 0 0 . 
0 . 0 . 
0 . 0 . 
0 0 0 . 
";
            ShouldBeString(Nmbr.Zero0, Expected);
        }

        [Fact]
        public void Zero1()
        {
            const string Expected = @"
0 0 0 0 
0 . . 0 
0 0 0 0 
. . . . 
";
            ShouldBeString(Nmbr.Zero1, Expected);
        }

        [Fact]
        public void One0()
        {
            const string E1pected = @"
1 1 . . 
. 1 . . 
. 1 . . 
. 1 . . 
";
            ShouldBeString(Nmbr.One0, E1pected);
        }

        [Fact]
        public void One1()
        {
            const string E1pected = @"
. . . 1 
1 1 1 1 
. . . . 
. . . . 
";
            ShouldBeString(Nmbr.One1, E1pected);
        }

        [Fact]
        public void One2()
        {
            const string E1pected = @"
1 . . . 
1 . . . 
1 . . . 
1 1 . . 
";
            ShouldBeString(Nmbr.One2, E1pected);
        }

        [Fact]
        public void One3()
        {
            const string E1pected = @"
1 1 1 1 
1 . . . 
. . . . 
. . . . 
";
            ShouldBeString(Nmbr.One3, E1pected);
        }

        [Fact]
        public void Two0()
        {
            const string E2pected = @"
. 2 2 . 
. 2 2 . 
2 2 . . 
2 2 2 . 
";
            ShouldBeString(Nmbr.Two0, E2pected);
        }

        [Fact]
        public void Two1()
        {
            const string E2pected = @"
2 2 2 . 
2 2 2 2 
2 . 2 2 
. . . . 
";
            ShouldBeString(Nmbr.Two1, E2pected);
        }

        [Fact]
        public void Two2()
        {
            const string E2pected = @"
2 2 2 . 
. 2 2 . 
2 2 2 . 
2 2 . . 
";
            ShouldBeString(Nmbr.Two2, E2pected);
        }

        [Fact]
        public void Two3()
        {
            const string E2pected = @"
2 2 . 2 
2 2 2 2 
. . 2 2 
. . . . 
";
            ShouldBeString(Nmbr.Two3, E2pected);
        }

        [Fact]
        public void Three0()
        {
            const string E3pected = @"
3 3 3 . 
. . 3 . 
. 3 3 . 
3 3 3 . 
";
            ShouldBeString(Nmbr.Three0, E3pected);
        }

        [Fact]
        public void Three1()
        {
            const string E3pected = @"
3 . . 3 
3 3 . 3 
3 3 3 3 
. . . . 
";
            ShouldBeString(Nmbr.Three1, E3pected);
        }

        [Fact]
        public void Three2()
        {
            const string E3pected = @"
3 3 3 . 
3 3 . . 
3 . . . 
3 3 3 . 
";
            ShouldBeString(Nmbr.Three2, E3pected);
        }

        [Fact]
        public void Three3()
        {
            const string E3pected = @"
3 3 3 3 
3 . 3 3 
3 . . 3 
. . . . 
";
            ShouldBeString(Nmbr.Three3, E3pected);
        }

        [Fact]
        public void Four0()
        {
            const string E4pected = @"
. 4 4 . 
. 4 . . 
4 4 4 . 
. 4 4 . 
";
            ShouldBeString(Nmbr.Four0, E4pected);
        }

        [Fact]
        public void Four1()
        {
            const string E4pected = @"
. 4 . . 
4 4 4 4 
4 4 . 4 
. . . . 
";
            ShouldBeString(Nmbr.Four1, E4pected);
        }

        [Fact]
        public void Four2()
        {
            const string E4pected = @"
4 4 . . 
4 4 4 . 
. 4 . . 
4 4 . . 
";
            ShouldBeString(Nmbr.Four2, E4pected);
        }

        [Fact]
        public void Four3()
        {
            const string E4pected = @"
4 . 4 4 
4 4 4 4 
. . 4 . 
. . . . 
";
            ShouldBeString(Nmbr.Four3, E4pected);
        }

        [Fact]
        public void Five0()
        {
            const string E5pected = @"
5 5 5 . 
5 5 5 . 
. . 5 . 
5 5 5 . 
";
            ShouldBeString(Nmbr.Five0, E5pected);
        }

        [Fact]
        public void Five1()
        {
            const string E5pected = @"
5 . 5 5 
5 . 5 5 
5 5 5 5 
. . . . 
";
            ShouldBeString(Nmbr.Five1, E5pected);
        }

        [Fact]
        public void Five2()
        {
            const string E5pected = @"
5 5 5 . 
5 . . . 
5 5 5 . 
5 5 5 . 
";
            ShouldBeString(Nmbr.Five2, E5pected);
        }

        [Fact]
        public void Five3()
        {
            const string E5pected = @"
5 5 5 5 
5 5 . 5 
5 5 . 5 
. . . . 
";
            ShouldBeString(Nmbr.Five3, E5pected);
        }

        [Fact]
        public void Six0()
        {
            const string E6pected = @"
6 6 . . 
6 . . . 
6 6 6 . 
6 6 6 . 
";
            ShouldBeString(Nmbr.Six0, E6pected);
        }

        [Fact]
        public void Six1()
        {
            const string E6pected = @"
6 6 6 6 
6 6 . 6 
6 6 . . 
. . . . 
";
            ShouldBeString(Nmbr.Six1, E6pected);
        }

        [Fact]
        public void Six2()
        {
            const string E6pected = @"
6 6 6 . 
6 6 6 . 
. . 6 . 
. 6 6 . 
";
            ShouldBeString(Nmbr.Six2, E6pected);
        }

        [Fact]
        public void Six3()
        {
            const string E6pected = @"
. . 6 6 
6 . 6 6 
6 6 6 6 
. . . . 
";
            ShouldBeString(Nmbr.Six3, E6pected);
        }

        [Fact]
        public void Seven0()
        {
            const string E7pected = @"
7 7 7 . 
. 7 . . 
7 7 . . 
7 . . . 
";
            ShouldBeString(Nmbr.Seven0, E7pected);
        }

        [Fact]
        public void Seven1()
        {
            const string E7pected = @"
7 7 . 7 
. 7 7 7 
. . . 7 
. . . . 
";
            ShouldBeString(Nmbr.Seven1, E7pected);
        }

        [Fact]
        public void Seven2()
        {
            const string E7pected = @"
. . 7 . 
. 7 7 . 
. 7 . . 
7 7 7 . 
";
            ShouldBeString(Nmbr.Seven2, E7pected);
        }

        [Fact]
        public void Seven3()
        {
            const string E7pected = @"
7 . . . 
7 7 7 . 
7 . 7 7 
. . . . 
";
            ShouldBeString(Nmbr.Seven3, E7pected);
        }

        [Fact]
        public void Eight0()
        {
            const string E8pected = @"
. 8 8 . 
. 8 8 . 
8 8 . . 
8 8 . . 
";
            ShouldBeString(Nmbr.Eight0, E8pected);
        }

        [Fact]
        public void Eight1()
        {
            const string E8pected = @"
8 8 . . 
8 8 8 8 
. . 8 8 
. . . . 
";
            ShouldBeString(Nmbr.Eight1, E8pected);
        }

        [Fact]
        public void Nine0()
        {
            const string E9pected = @"
9 9 9 . 
9 9 9 . 
9 9 . . 
9 9 . . 
";
            ShouldBeString(Nmbr.Nine0, E9pected);
        }

        [Fact]
        public void Nine1()
        {
            const string E9pected = @"
9 9 9 9 
9 9 9 9 
. . 9 9 
. . . . 
";
            ShouldBeString(Nmbr.Nine1, E9pected);
        }

        [Fact]
        public void Nine2()
        {
            const string E9pected = @"
. 9 9 . 
. 9 9 . 
9 9 9 . 
9 9 9 . 
";
            ShouldBeString(Nmbr.Nine2, E9pected);
        }

        [Fact]
        public void Nine3()
        {
            const string E9pected = @"
9 9 . . 
9 9 9 9 
9 9 9 9 
. . . . 
";
            ShouldBeString(Nmbr.Nine3, E9pected);
        }

        private static void ShouldBeString(Nmbr n, string expected)
        {
            n.ToString().Should().Be(expected.TrimStart());
        }
    }
}
