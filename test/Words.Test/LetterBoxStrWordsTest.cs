// <copyright file="LetterBoxStrWordsTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxStrWordsTest
    {
        [Fact]
        public void EmptyFindsNothing()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void OneWordFindsNothing()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            words.Add(Str.Parse("ALE"), new LetterBoxStr.Vertices(0b100000010001));

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void TwoWordsInvalidSolutionFindsNothing()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            words.Add(Str.Parse("ALE"), new LetterBoxStr.Vertices(0b100000010001));
            words.Add(Str.Parse("ELF"), new LetterBoxStr.Vertices(0b100000110000));

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void TwoWordsValidSolutionFindsOne()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            words.Add(Str.Parse("ADBECF"), new LetterBoxStr.Vertices(0b000000111111));
            words.Add(Str.Parse("FGJHKIL"), new LetterBoxStr.Vertices(0b111111100000));

            FindSolutions(words).Should().BeEquivalentTo("ADBECF-FGJHKIL");
        }

        [Fact]
        public void ManyWordsFindsAllSolutions()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            words.Add(Str.Parse("ADB"), new LetterBoxStr.Vertices(0b000000001011));
            words.Add(Str.Parse("ADBECF"), new LetterBoxStr.Vertices(0b000000111111));
            words.Add(Str.Parse("BECFHJGKIL"), new LetterBoxStr.Vertices(0b111111111110));
            words.Add(Str.Parse("FGJHKIL"), new LetterBoxStr.Vertices(0b111111100000));
            words.Add(Str.Parse("FAHKILJG"), new LetterBoxStr.Vertices(0b111111100001));
            words.Add(Str.Parse("FAHKILJ"), new LetterBoxStr.Vertices(0b111110100001));

            FindSolutions(words).Should().BeEquivalentTo("ADB-BECFHJGKIL", "ADBECF-FGJHKIL", "ADBECF-FAHKILJG");
        }

        [Fact]
        public void CountsWords()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();

            words.Count.Should().Be(0);

            words.Add(Str.Parse("AB"), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(1);

            words.Add(Str.Parse("AB"), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(1);

            words.Add(Str.Parse("ABC"), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(2);

            words.Add(Str.Parse("ABCD"), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(3);
        }

        private static IList<string> FindSolutions(LetterBoxStrWords words)
        {
            List<string> found = new List<string>();

            words.Find((w1, w2) => found.Add(w1 + "-" + w2));

            found.Sort();
            return found;
        }
    }
}
