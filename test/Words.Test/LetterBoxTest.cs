// <copyright file="LetterBoxTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxTest
    {
        [Fact]
        public void AllowsCharLookup()
        {
            LetterBox box = New();

            Enumerable.Range(0, 12).Select(v => box[v]).Should().BeEquivalentTo(
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L');
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(12)]
        public void FailsCharLookupOutOfRange(int index)
        {
            LetterBox box = New();

            char c;
            Action act = () => c = box[index];

            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Theory]
        [InlineData(0, "000111111111")]
        [InlineData(1, "000111111111")]
        [InlineData(2, "000111111111")]
        [InlineData(3, "111000111111")]
        [InlineData(4, "111000111111")]
        [InlineData(5, "111000111111")]
        [InlineData(6, "111111000111")]
        [InlineData(7, "111111000111")]
        [InlineData(8, "111111000111")]
        [InlineData(9, "111111111000")]
        [InlineData(10, "111111111000")]
        [InlineData(11, "111111111000")]
        public void ReturnsNextVertices(int start, string expected)
        {
            LetterBox box = New();

            LetterBox.Vertices verts = box.Next(start);

            verts.ToString().Should().Be(expected);
        }

        private static LetterBox New() => new LetterBox("ABCDEFGHIJKL");
    }
}
