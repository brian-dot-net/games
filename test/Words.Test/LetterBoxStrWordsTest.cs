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

        private static IList<string> FindSolutions(LetterBoxStrWords words)
        {
            List<string> found = new List<string>();

            words.Find((w1, w2) => found.Add(w1 + "-" + w2));

            found.Sort();
            return found;
        }
    }
}
