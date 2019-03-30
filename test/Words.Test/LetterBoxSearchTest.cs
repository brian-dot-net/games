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

        [Fact]
        public void TwelveValueTrieFindsAllWords()
        {
            StringTrie trie = new StringTrie();
            trie.Add("ALE");
            trie.Add("BEG");
            trie.Add("CEL");
            trie.Add("DAH");
            trie.Add("ELF");
            trie.Add("FIB");
            trie.Add("GAL");
            trie.Add("HAD");
            trie.Add("ICE");
            trie.Add("JIB");
            trie.Add("KAE");
            trie.Add("LIE");
            LetterBoxSearch search = New(trie);
            List<string> found = new List<string>();

            search.Run((w, v) => found.Add(w + ":" + v));

            found.Should().BeEquivalentTo(
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

        [Fact]
        public void SearchDoesNotReturnInvalidMoves()
        {
            StringTrie trie = new StringTrie();
            trie.Add("ABC");
            trie.Add("DEF");
            trie.Add("GHI");
            trie.Add("JKL");
            trie.Add("MOW");
            trie.Add("ALA");
            LetterBoxSearch search = New(trie);
            List<string> found = new List<string>();

            search.Run((w, v) => found.Add(w + ":" + v));

            found.Should().BeEquivalentTo("ALA:100000000001");
        }

        private static LetterBoxSearch New(StringTrie trie)
        {
            return new LetterBoxSearch(trie, new LetterBox("ABCDEFGHIJKL"));
        }
    }
}
