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
            LetterBox box = new LetterBox("ABCDEFGHIJKL");

            Enumerable.Range(0, 12).Select(v => box[v]).Should().BeEquivalentTo(
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L');
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(12)]
        public void FailsCharLookupOutOfRange(int index)
        {
            LetterBox box = new LetterBox("ABCDEFGHIJKL");

            char c;
            Action act = () => c = box[index];

            act.Should().Throw<IndexOutOfRangeException>();
        }
    }
}
