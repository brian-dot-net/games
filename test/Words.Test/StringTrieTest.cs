// <copyright file="StringTrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using FluentAssertions;
    using Xunit;

    public sealed class StringTrieTest
    {
        [Fact]
        public void Empty()
        {
            StringTrie trie = new StringTrie();

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void OneItemLength1()
        {
            StringTrie trie = new StringTrie();

            trie.Add("X");

            trie.Count.Should().Be(1);
        }
    }
}
