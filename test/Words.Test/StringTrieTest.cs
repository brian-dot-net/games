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
    }
}
