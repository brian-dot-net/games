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
            words.Add(default(Str).Append(Ch.A).Append(Ch.L).Append(Ch.E), new LetterBoxStr.Vertices(0b100000010001));

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void TwoWordsInvalidSolutionFindsNothing()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            words.Add(default(Str).Append(Ch.A).Append(Ch.L).Append(Ch.E), new LetterBoxStr.Vertices(0b100000010001));
            words.Add(default(Str).Append(Ch.E).Append(Ch.L).Append(Ch.F), new LetterBoxStr.Vertices(0b100000110000));

            FindSolutions(words).Should().BeEmpty();
        }

        [Fact]
        public void TwoWordsValidSolutionFindsOne()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            Str w1 = default(Str).Append(Ch.A).Append(Ch.D).Append(Ch.B).Append(Ch.E).Append(Ch.C).Append(Ch.F);
            Str w2 = default(Str).Append(Ch.F).Append(Ch.G).Append(Ch.J).Append(Ch.H).Append(Ch.K).Append(Ch.I).Append(Ch.L);
            words.Add(w1, new LetterBoxStr.Vertices(0b000000111111));
            words.Add(w2, new LetterBoxStr.Vertices(0b111111100000));

            FindSolutions(words).Should().BeEquivalentTo("ADBECF-FGJHKIL");
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
