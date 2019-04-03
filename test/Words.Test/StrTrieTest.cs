// <copyright file="StrTrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System;
    using System.Linq;
    using System.Text;
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

        [Fact]
        public void ThreeItemsLength3NoSharedPrefix()
        {
            StrTrie trie = new StrTrie();

            trie.Add(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C));
            trie.Add(default(Str).Append(Ch.D).Append(Ch.E).Append(Ch.F));
            trie.Add(default(Str).Append(Ch.G).Append(Ch.H).Append(Ch.I));

            trie.Count.Should().Be(3);
            trie.Find(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C)).Should().Be(StrTrie.NodeKind.Terminal);
            trie.Find(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C)).Should().Be(StrTrie.NodeKind.Terminal);
            trie.Find(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C)).Should().Be(StrTrie.NodeKind.Terminal);
        }

        [Fact]
        public void GetNonExistentNode()
        {
            StrTrie trie = new StrTrie();
            trie.Add(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C));

            trie.Find(default(Str).Append(Ch.X)).Should().Be(StrTrie.NodeKind.None);
        }

        [Fact]
        public void AddNodesMultipleTimes()
        {
            StrTrie trie = new StrTrie();

            trie.Add(default(Str).Append(Ch.A).Append(Ch.B));
            trie.Add(default(Str).Append(Ch.A).Append(Ch.B));
            trie.Add(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C));
            trie.Add(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C));

            trie.Count.Should().Be(2);
            trie.Find(default(Str).Append(Ch.A)).Should().Be(StrTrie.NodeKind.Prefix);
            trie.Find(default(Str).Append(Ch.A).Append(Ch.B)).Should().Be(StrTrie.NodeKind.Terminal);
            trie.Find(default(Str).Append(Ch.A).Append(Ch.B).Append(Ch.C)).Should().Be(StrTrie.NodeKind.Terminal);
        }

        [Fact]
        public void AddEmptyNode()
        {
            StrTrie trie = new StrTrie();

            trie.Add(default(Str));

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void LoadFromStreamEmpty()
        {
            StrTrie trie = Load();

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void LoadFromStreamOneWord()
        {
            StrTrie trie = Load("ONE");

            trie.Count.Should().Be(1);
            trie.Find(default(Str).Append(Ch.O).Append(Ch.N).Append(Ch.E)).Should().Be(StrTrie.NodeKind.Terminal);
        }

        [Fact]
        public void LoadFromStreamThreeWords()
        {
            StrTrie trie = Load("ONE", "TWO", "THREE");

            trie.Count.Should().Be(3);
            trie.Find(default(Str).Append(Ch.O).Append(Ch.N).Append(Ch.E)).Should().Be(StrTrie.NodeKind.Terminal);
            trie.Find(default(Str).Append(Ch.T).Append(Ch.W).Append(Ch.O)).Should().Be(StrTrie.NodeKind.Terminal);
            trie.Find(default(Str).Append(Ch.T).Append(Ch.H).Append(Ch.R).Append(Ch.E).Append(Ch.E)).Should().Be(StrTrie.NodeKind.Terminal);
        }

        private static StrTrie Load(params string[] lines)
        {
            WrappedMemoryStream stream = new WrappedMemoryStream(lines.SelectMany(l => Encoding.ASCII.GetBytes(l + Environment.NewLine)).ToArray());

            StrTrie trie = StrTrie.Load(stream);

            stream.DisposeCount.Should().Be(1);
            return trie;
        }
    }
}