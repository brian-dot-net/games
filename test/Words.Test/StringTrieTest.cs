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

        [Fact]
        public void TwoItemsLength2SharedPrefix()
        {
            StringTrie trie = new StringTrie();

            trie.Add("HI");
            trie.Add("HA");

            trie.Count.Should().Be(2);
            var node = trie['H'];
            node.IsTerminal.Should().BeFalse();
            node['A'].IsTerminal.Should().BeTrue();
            node['I'].IsTerminal.Should().BeTrue();
        }
    }
}
