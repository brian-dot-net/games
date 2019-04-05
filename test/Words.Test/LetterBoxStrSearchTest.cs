// <copyright file="LetterBoxStrSearchTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public sealed class LetterBoxStrSearchTest
    {
        [Fact]
        public void EmptyTrieFindsNothing()
        {
            StrTrie trie = new StrTrie();
            LetterBoxStrSearch search = New(trie);

            FindWords(search).Should().BeEmpty();
        }

        [Fact]
        public void OneValueTrieFindsOneWord()
        {
            StrTrie trie = new StrTrie();
            trie.Add(Str.Parse("ALE"));
            LetterBoxStrSearch search = New(trie);
            List<string> found = new List<string>();

            FindWords(search).Should().BeEquivalentTo("ALE:100010000001");
        }

        private static LetterBoxStrSearch New(StrTrie trie)
        {
            return new LetterBoxStrSearch(trie, new LetterBoxStr(Str.Parse("ABCDEFGHIJKL")));
        }

        private static IList<string> FindWords(LetterBoxStrSearch search)
        {
            List<string> found = new List<string>();

            search.Run((w, v) => found.Add(w + ":" + v));

            return found;
        }
    }
}
