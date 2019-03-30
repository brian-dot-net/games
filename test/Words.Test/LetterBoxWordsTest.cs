// <copyright file="LetterBoxWordsTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxWordsTest
    {
        [Fact]
        public void EmptyFindsNothing()
        {
            LetterBoxWords words = new LetterBoxWords();
            int count = 0;

            words.Find((w1, w2) => ++count);

            count.Should().Be(0);
        }

        [Fact]
        public void OneWordFindsNothing()
        {
            LetterBoxWords words = new LetterBoxWords();
            words.Add("ALE", new LetterBox.Vertices(0b100000010001));
            int count = 0;

            words.Find((w1, w2) => ++count);

            count.Should().Be(0);
        }

        [Fact]
        public void TwoWordsInvalidSolutionFindsNothing()
        {
            LetterBoxWords words = new LetterBoxWords();
            words.Add("ALE", new LetterBox.Vertices(0b100000010001));
            words.Add("ELF", new LetterBox.Vertices(0b100000110000));
            int count = 0;

            words.Find((w1, w2) => ++count);

            count.Should().Be(0);
        }
    }
}
