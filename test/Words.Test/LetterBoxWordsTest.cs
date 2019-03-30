// <copyright file="LetterBoxWordsTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxWordsTest
    {
        [Fact]
        public void EmptyFindsNothing()
        {
            LetterBoxWords words = new LetterBoxWords();

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void OneWordFindsNothing()
        {
            LetterBoxWords words = new LetterBoxWords();
            words.Add("ALE", new LetterBox.Vertices(0b100000010001));

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void TwoWordsInvalidSolutionFindsNothing()
        {
            LetterBoxWords words = new LetterBoxWords();
            words.Add("ALE", new LetterBox.Vertices(0b100000010001));
            words.Add("ELF", new LetterBox.Vertices(0b100000110000));

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void TwoWordsValidSolutionFindsOne()
        {
            LetterBoxWords words = new LetterBoxWords();
            words.Add("ADBECF", new LetterBox.Vertices(0b000000111111));
            words.Add("FGJHKIL", new LetterBox.Vertices(0b111111100000));

            FindSolutions(words).Should().BeEquivalentTo("ADBECF-FGJHKIL");
        }

        [Fact]
        public void ManyWordsFindsAllSolutions()
        {
            LetterBoxWords words = new LetterBoxWords();
            words.Add("ADB", new LetterBox.Vertices(0b000000001011));
            words.Add("ADBECF", new LetterBox.Vertices(0b000000111111));
            words.Add("BECFHJGKIL", new LetterBox.Vertices(0b111111111110));
            words.Add("FGJHKIL", new LetterBox.Vertices(0b111111100000));
            words.Add("FAHKILJG", new LetterBox.Vertices(0b111111100001));
            words.Add("FAHKILJ", new LetterBox.Vertices(0b111110100001));

            FindSolutions(words).Should().BeEquivalentTo("ADB-BECFHJGKIL", "ADBECF-FGJHKIL", "ADBECF-FAHKILJG");
        }

        [Fact]
        public void CountsWords()
        {
            LetterBoxWords words = new LetterBoxWords();

            words.Count.Should().Be(0);

            words.Add("AB", default(LetterBox.Vertices));

            words.Count.Should().Be(1);

            words.Add("AB", default(LetterBox.Vertices));

            words.Count.Should().Be(1);

            words.Add("ABC", default(LetterBox.Vertices));

            words.Count.Should().Be(2);

            words.Add("BCD", default(LetterBox.Vertices));

            words.Count.Should().Be(3);
        }

        private static IList<string> FindSolutions(LetterBoxWords words)
        {
            List<string> found = new List<string>();

            words.Find((w1, w2) => found.Add(w1 + "-" + w2));

            found.Sort();
            return found;
        }
    }
}
