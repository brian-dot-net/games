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

            Enumerable.Range(0, 12).Select(v => box[v]).Should().ContainInOrder(
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

        [Theory]
        [InlineData(-100)]
        [InlineData(-1)]
        [InlineData(12)]
        [InlineData(100)]
        public void FailsNextVerticesOutOfRange(int start)
        {
            LetterBox box = New();

            LetterBox.Vertices verts;
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
            LetterBox.Vertices verts = new LetterBox.Vertices(bits);

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
            LetterBox.Vertices z = new LetterBox.Vertices(x) + new LetterBox.Vertices(y);

            z.ToString().Should().Be(expected);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKL")]
        [InlineData("ZYXWVUTSRQPO")]
        [InlineData("MMMNNNMMMNNN")]
        public void StringValue(string expected)
        {
            LetterBox box = New(expected);

            box.ToString().Should().Be(expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("BC")]
        [InlineData("DEF")]
        [InlineData("GHIJ")]
        [InlineData("KLMNO")]
        [InlineData("PQRSTU")]
        [InlineData("VWXYZAB")]
        [InlineData("CDEFGHIJ")]
        [InlineData("KLMNOPQRS")]
        [InlineData("TUVWXYZABC")]
        [InlineData("DEFGHIJKLMN")]
        public void InputTooShort(string input)
        {
            Action act = () => New(input);

            act.Should().Throw<ArgumentOutOfRangeException>().Which.ParamName.Should().Be("box");
        }

        [Theory]
        [InlineData("ZZZYYYXXXWWWVVV")]
        [InlineData("NOTAVALIDLETTERBOX")]
        public void InputTooLong(string input)
        {
            Action act = () => New(input);

            act.Should().Throw<ArgumentOutOfRangeException>().Which.ParamName.Should().Be("box");
        }

        [Fact]
        public void InputNull()
        {
            Action act = () => new LetterBox(null);

            act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("box");
        }

        private static LetterBox New(string input = null) => new LetterBox(input ?? "ABCDEFGHIJKL");
    }
}
