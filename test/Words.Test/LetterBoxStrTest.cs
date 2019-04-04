// <copyright file="LetterBoxStrTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxStrTest
    {
        [Fact]
        public void AllowsCharLookup()
        {
            LetterBoxStr box = New();

            Enumerable.Range(0, 12).Select(v => box[(byte)v]).Should().BeEquivalentTo(
                Ch.A, Ch.B, Ch.C, Ch.D, Ch.E, Ch.F, Ch.G, Ch.H, Ch.I, Ch.J, Ch.K, Ch.L);
        }

        private static LetterBoxStr New()
        {
            Str box = default(Str)
                .Append(Ch.A)
                .Append(Ch.B)
                .Append(Ch.C)
                .Append(Ch.D)
                .Append(Ch.E)
                .Append(Ch.F)
                .Append(Ch.G)
                .Append(Ch.H)
                .Append(Ch.I)
                .Append(Ch.J)
                .Append(Ch.K)
                .Append(Ch.L);
            return new LetterBoxStr(box);
        }
    }
}
