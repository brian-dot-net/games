// <copyright file="StringTrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Test
{
    using System.IO;
    using System.Linq;
    using System.Text;
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

        [Fact]
        public void ThreeItemsLength3NoSharedPrefix()
        {
            StringTrie trie = new StringTrie();

            trie.Add("ABC");
            trie.Add("DEF");
            trie.Add("GHI");

            trie.Count.Should().Be(3);
            var one = trie['A']['B']['C'];
            one.IsTerminal.Should().BeTrue();
            one.Value.Should().Be("ABC");
            var two = trie['D']['E']['F'];
            two.IsTerminal.Should().BeTrue();
            two.Value.Should().Be("DEF");
            var three = trie['G']['H']['I'];
            three.IsTerminal.Should().BeTrue();
            three.Value.Should().Be("GHI");
        }

        [Fact]
        public void GetNonExistentNode()
        {
            StringTrie trie = new StringTrie();
            trie.Add("ABC");

            var notThere = trie['X'];

            notThere.Should().BeNull();
        }

        [Fact]
        public void AddNodesMultipleTimes()
        {
            StringTrie trie = new StringTrie();

            trie.Add("AB");
            trie.Add("AB");
            trie.Add("ABC");
            trie.Add("ABC");

            trie.Count.Should().Be(2);
        }

        [Fact]
        public void AddEmptyNode()
        {
            StringTrie trie = new StringTrie();

            trie.Add(string.Empty);

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void AddNullNode()
        {
            StringTrie trie = new StringTrie();

            trie.Add(null);

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void LoadFromStreamEmpty()
        {
            StringTrie trie = Load();

            trie.Count.Should().Be(0);
        }

        [Fact]
        public void LoadFromStreamOneWord()
        {
            StringTrie trie = Load("ONE");

            trie.Count.Should().Be(1);
            trie['O']['N']['E'].Value.Should().Be("ONE");
        }

        private static StringTrie Load(params string[] lines)
        {
            WrappedMemoryStream stream = new WrappedMemoryStream(lines.SelectMany(l => Encoding.ASCII.GetBytes(l)).ToArray());

            StringTrie trie = StringTrie.Load(stream);

            stream.DisposeCount.Should().Be(1);
            return trie;
        }

        private sealed class WrappedMemoryStream : MemoryStream
        {
            public WrappedMemoryStream(byte[] buffer)
                : base(buffer)
            {
            }

            public int DisposeCount { get; private set; }

            protected override void Dispose(bool disposing)
            {
                ++this.DisposeCount;
                base.Dispose(disposing);
            }
        }
    }
}
