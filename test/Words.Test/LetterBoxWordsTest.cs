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
    }
}
