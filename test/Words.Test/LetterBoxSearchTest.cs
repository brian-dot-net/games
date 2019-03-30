// <copyright file="LetterBoxSearchTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxSearchTest
    {
        [Fact]
        public void EmptyTrieFindsNothing()
        {
            StringTrie trie = new StringTrie();
            LetterBoxSearch search = New(trie);
            int count = 0;

            search.Run((_, __) => ++count);

            count.Should().Be(0);
        }

        private static LetterBoxSearch New(StringTrie trie)
        {
            return new LetterBoxSearch(trie, new LetterBox("ABCDEFGHIJKL"));
        }
    }
}
