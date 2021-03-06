// <copyright file="PointTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes.Test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public sealed class PointTest
    {
        [Fact]
        public void EnumerateZeroZero()
        {
            TestEnumerate(new Point(0, 0));
        }

        [Fact]
        public void EnumerateOneOne()
        {
            TestEnumerate(new Point(1, 1), "(0, 0)");
        }

        [Fact]
        public void EnumerateTwoTwo()
        {
            TestEnumerate(new Point(2, 2), "(0, 0)", "(1, 0)", "(0, 1)", "(1, 1)");
        }

        private static void TestEnumerate(Point pt, params string[] expected)
        {
            List<string> points = new List<string>();
            foreach (Point p in pt)
            {
                points.Add(p.ToString());
            }

            points.Should().BeEquivalentTo(expected);
        }
    }
}
