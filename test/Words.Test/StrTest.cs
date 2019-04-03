// <copyright file="StrTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System;
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

        [Theory]
        [InlineData(Ch.V, Ch.W, Ch.X, Ch.Y, Ch.Z, Ch.A, Ch.B, Ch.C, "VWXYZABC")]
        [InlineData(Ch.A, Ch.B, Ch.C, Ch.D, Ch.E, Ch.F, Ch.G, Ch.H, "ABCDEFGH")]
        [InlineData(Ch.I, Ch.J, Ch.K, Ch.L, Ch.M, Ch.N, Ch.O, Ch.P, "IJKLMNOP")]
        public void EightChars(Ch c0, Ch c1, Ch c2, Ch c3, Ch c4, Ch c5, Ch c6, Ch c7, string expected)
        {
            Str s = default(Str)
                .Append(c0)
                .Append(c1)
                .Append(c2)
                .Append(c3)
                .Append(c4)
                .Append(c5)
                .Append(c6)
                .Append(c7);

            s.Length.Should().Be(8);
            s.ToString().Should().Be(expected);
            Enumerable.Range(0, 12).Select(i => s[i]).Should().BeEquivalentTo(
                c0,
                c1,
                c2,
                c3,
                c4,
                c5,
                c6,
                c7,
                Ch.None,
                Ch.None,
                Ch.None,
                Ch.None);
        }

        [Theory]
        [InlineData(Ch.Q, Ch.R, Ch.S, Ch.T, Ch.U, Ch.V, Ch.W, Ch.X, Ch.Y, Ch.Z, Ch.A, Ch.B, "QRSTUVWXYZAB")]
        [InlineData(Ch.C, Ch.D, Ch.E, Ch.F, Ch.G, Ch.H, Ch.I, Ch.J, Ch.K, Ch.L, Ch.M, Ch.N, "CDEFGHIJKLMN")]
        [InlineData(Ch.O, Ch.P, Ch.Q, Ch.R, Ch.S, Ch.T, Ch.U, Ch.V, Ch.W, Ch.X, Ch.Y, Ch.Z, "OPQRSTUVWXYZ")]
        public void TwelveChars(Ch c0, Ch c1, Ch c2, Ch c3, Ch c4, Ch c5, Ch c6, Ch c7, Ch c8, Ch c9, Ch c10, Ch c11, string expected)
        {
            Str s = default(Str)
                .Append(c0)
                .Append(c1)
                .Append(c2)
                .Append(c3)
                .Append(c4)
                .Append(c5)
                .Append(c6)
                .Append(c7)
                .Append(c8)
                .Append(c9)
                .Append(c10)
                .Append(c11);

            s.Length.Should().Be(12);
            s.ToString().Should().Be(expected);
            Enumerable.Range(0, 12).Select(i => s[i]).Should().BeEquivalentTo(
                c0,
                c1,
                c2,
                c3,
                c4,
                c5,
                c6,
                c7,
                c8,
                c9,
                c10,
                c11);
        }

        [Fact]
        public void AppendTooMany()
        {
            Str max = default(Str)
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

            Action act = () => max.Append(Ch.X);

            act.Should().Throw<InvalidOperationException>();
        }
    }
}
