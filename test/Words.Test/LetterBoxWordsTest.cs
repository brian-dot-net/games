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

        private static IList<string> FindSolutions(LetterBoxWords words)
        {
            List<string> found = new List<string>();

            words.Find((w1, w2) => found.Add(w1 + "-" + w2));

            return found;
        }
    }
}
