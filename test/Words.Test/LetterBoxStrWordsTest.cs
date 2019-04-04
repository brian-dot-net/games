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

        [Fact]
        public void ManyWordsFindsAllSolutions()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();
            Str w1 = default(Str).Append(Ch.A).Append(Ch.D).Append(Ch.B);
            words.Add(w1, new LetterBoxStr.Vertices(0b000000001011));
            Str w2 = default(Str).Append(Ch.A).Append(Ch.D).Append(Ch.B).Append(Ch.E).Append(Ch.C).Append(Ch.F);
            words.Add(w2, new LetterBoxStr.Vertices(0b000000111111));
            Str w3 = default(Str).Append(Ch.B).Append(Ch.E).Append(Ch.C).Append(Ch.F).Append(Ch.H).Append(Ch.J).Append(Ch.G).Append(Ch.K).Append(Ch.I).Append(Ch.L);
            words.Add(w3, new LetterBoxStr.Vertices(0b111111111110));
            Str w4 = default(Str).Append(Ch.F).Append(Ch.G).Append(Ch.J).Append(Ch.H).Append(Ch.K).Append(Ch.I).Append(Ch.L);
            words.Add(w4, new LetterBoxStr.Vertices(0b111111100000));
            Str w5 = default(Str).Append(Ch.F).Append(Ch.A).Append(Ch.H).Append(Ch.K).Append(Ch.I).Append(Ch.L).Append(Ch.J).Append(Ch.G);
            words.Add(w5, new LetterBoxStr.Vertices(0b111111100001));
            Str w6 = default(Str).Append(Ch.F).Append(Ch.A).Append(Ch.H).Append(Ch.K).Append(Ch.I).Append(Ch.L).Append(Ch.J);
            words.Add(w6, new LetterBoxStr.Vertices(0b111110100001));

            FindSolutions(words).Should().BeEquivalentTo("ADB-BECFHJGKIL", "ADBECF-FGJHKIL", "ADBECF-FAHKILJG");
        }

        [Fact]
        public void CountsWords()
        {
            LetterBoxStrWords words = new LetterBoxStrWords();

            words.Count.Should().Be(0);

            words.Add(default(Str).Append(Ch.A).Append(Ch.B), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(1);

            words.Add(default(Str).Append(Ch.A).Append(Ch.B), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(1);

            words.Add(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C), default(LetterBoxStr.Vertices));

            words.Count.Should().Be(2);

            words.Add(default(Str).Append(Ch.B).Append(Ch.C).Append(Ch.D), default(LetterBoxStr.Vertices));

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
