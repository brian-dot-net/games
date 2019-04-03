// <copyright file="StrTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public sealed class StrTest
    {
        [Fact]
        public void Empty()
        {
            Str s = default(Str);

            s.Length.Should().Be(0);
            s.ToString().Should().Be(string.Empty);
            Enumerable.Range(0, 12).Select(i => s[i]).Should().BeEquivalentTo(
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None);
        }

        [Theory]
        [InlineData(Ch.A, "A")]
        [InlineData(Ch.B, "B")]
        [InlineData(Ch.C, "C")]
        public void OneChar(Ch c0, string expected)
        {
            Str s = default(Str)
                .Append(c0);

            s.Length.Should().Be(1);
            s.ToString().Should().Be(expected);
            Enumerable.Range(0, 12).Select(i => s[i]).Should().BeEquivalentTo(
                c0,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None);
        }

        [Theory]
        [InlineData(Ch.D, Ch.E, "DE")]
        [InlineData(Ch.F, Ch.G, "FG")]
        [InlineData(Ch.H, Ch.I, "HI")]
        public void TwoChars(Ch c0, Ch c1, string expected)
        {
            Str s = default(Str)
                .Append(c0)
                .Append(c1);

            s.Length.Should().Be(2);
            s.ToString().Should().Be(expected);
            Enumerable.Range(0, 12).Select(i => s[i]).Should().BeEquivalentTo(
                c0,
                c1,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None);
        }

        [Theory]
        [InlineData(Ch.J, Ch.K, Ch.L, Ch.M, "JKLM")]
        [InlineData(Ch.N, Ch.O, Ch.P, Ch.Q, "NOPQ")]
        [InlineData(Ch.R, Ch.S, Ch.T, Ch.U, "RSTU")]
        public void FourChars(Ch c0, Ch c1, Ch c2, Ch c3, string expected)
        {
            Str s = default(Str)
                .Append(c0)
                .Append(c1)
                .Append(c2)
                .Append(c3);

            s.Length.Should().Be(4);
            s.ToString().Should().Be(expected);
            Enumerable.Range(0, 12).Select(i => s[i]).Should().BeEquivalentTo(
                c0,
                c1,
                c2,
                c3,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None);
        }
    }
}
