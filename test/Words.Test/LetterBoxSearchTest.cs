// <copyright file="LetterBoxSearchTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.Collections.Generic;
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

        [Fact]
        public void OneValueTrieFindsOneWord()
        {
            StringTrie trie = new StringTrie();
            trie.Add("ALE");
            LetterBoxSearch search = New(trie);
            List<string> found = new List<string>();

            search.Run((w, v) => found.Add(w + ":" + v));

            found.Should().BeEquivalentTo("ALE:100010000001");
        }

        private static LetterBoxSearch New(StringTrie trie)
        {
            return new LetterBoxSearch(trie, new LetterBox("ABCDEFGHIJKL"));
        }
    }
}
