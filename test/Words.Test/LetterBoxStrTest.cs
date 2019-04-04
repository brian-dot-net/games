// <copyright file="LetterBoxStrTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System;
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

        [Theory]
        [InlineData(12)]
        [InlineData(255)]
        public void FailsCharLookupOutOfRange(byte index)
        {
            LetterBoxStr box = New();

            Ch c;
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
        public void ReturnsNextVertices(byte start, string expected)
        {
            LetterBoxStr box = New();

            LetterBoxStr.Vertices verts = box.Next(start);

            verts.ToString().Should().Be(expected);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(100)]
        [InlineData(255)]
        public void FailsNextVerticesOutOfRange(byte start)
        {
            LetterBoxStr box = New();

            LetterBoxStr.Vertices verts;
            Action act = () => verts = box.Next(start);

            act.Should().Throw<ArgumentOutOfRangeException>().Which.ParamName.Should().Be("start");
        }

        [Theory]
        [InlineData(0xFC5, "TFTFFFTTTTTT")]
        [InlineData(0xFA5, "TFTFFTFTTTTT")]
        [InlineData(0x000, "FFFFFFFFFFFF")]
        [InlineData(0x0FF, "TTTTTTTTFFFF")]
        public void AllowsVertexLookup(ushort bits, string expected)
        {
            LetterBoxStr.Vertices verts = new LetterBoxStr.Vertices(bits);

            string.Join(string.Empty, Enumerable.Range(0, 12).Select(v => verts[v] ? "T" : "F")).Should().Be(expected);
        }

        [Theory]
        [InlineData(0x135, 0x642, "111011101110")]
        [InlineData(0x531, 0x246, "111011101110")]
        [InlineData(0xEFF, 0x1FE, "111111111111")]
        [InlineData(0x000, 0x000, "000000000000")]
        [InlineData(0x7FF, 0x7EE, "111111111110")]
        [InlineData(0x001, 0x020, "100001000000")]
        public void AllowsVertexUnion(ushort x, ushort y, string expected)
        {
            LetterBoxStr.Vertices z = new LetterBoxStr.Vertices(x) + new LetterBoxStr.Vertices(y);

            z.ToString().Should().Be(expected);
        }

        [Fact]
        public void StringValue()
        {
            LetterBoxStr box = New();

            box.ToString().Should().Be("ABCDEFGHIJKL");
        }

        [Fact]
        public void InputTooShort()
        {
            Action act = () => new LetterBoxStr(default(Str).Append(Ch.A));

            act.Should().Throw<ArgumentOutOfRangeException>().Which.ParamName.Should().Be("box");
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
