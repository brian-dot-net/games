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
            Str s = default(Str).Append(c0);

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
    }
}
