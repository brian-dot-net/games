// <copyright file="StrTrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using FluentAssertions;
    using Xunit;

    public sealed class StrTrieTest
    {
        [Fact]
        public void Empty()
        {
            StrTrie trie = new StrTrie();

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void OneItemLength1()
        {
            StrTrie trie = new StrTrie();

            trie.Add(default(Str).Append(Ch.X));

            trie.Count.Should().Be(1);
        }
    }
}
