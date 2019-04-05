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

        [Fact]
        public void TwelveValueTrieFindsAllWords()
        {
            StrTrie trie = new StrTrie();
            trie.Add(Str.Parse("ALE"));
            trie.Add(Str.Parse("BEG"));
            trie.Add(Str.Parse("CEL"));
            trie.Add(Str.Parse("DAH"));
            trie.Add(Str.Parse("ELF"));
            trie.Add(Str.Parse("FIB"));
            trie.Add(Str.Parse("GAL"));
            trie.Add(Str.Parse("HAD"));
            trie.Add(Str.Parse("ICE"));
            trie.Add(Str.Parse("JIB"));
            trie.Add(Str.Parse("KAE"));
            trie.Add(Str.Parse("LIE"));
            LetterBoxStrSearch search = New(trie);
            List<string> found = new List<string>();

            FindWords(search).Should().BeEquivalentTo(
                "ALE:100010000001",
                "BEG:010010100000",
                "CEL:001010000001",
                "DAH:100100010000",
                "ELF:000011000001",
                "FIB:010001001000",
                "GAL:100000100001",
                "HAD:100100010000",
                "ICE:001010001000",
                "JIB:010000001100",
                "KAE:100010000010",
                "LIE:000010001001");
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
