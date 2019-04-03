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

        [Fact]
        public void TwoItemsLength2SharedPrefix()
        {
            StrTrie trie = new StrTrie();

            trie.Add(default(Str).Append(Ch.H).Append(Ch.I));
            trie.Add(default(Str).Append(Ch.H).Append(Ch.A));

            trie.Count.Should().Be(2);
            trie.Find(default(Str).Append(Ch.H)).Should().Be(StrTrie.NodeKind.Prefix);
            trie.Find(default(Str).Append(Ch.H).Append(Ch.A)).Should().Be(StrTrie.NodeKind.Terminal);
            trie.Find(default(Str).Append(Ch.H).Append(Ch.I)).Should().Be(StrTrie.NodeKind.Terminal);
        }
    }
}
