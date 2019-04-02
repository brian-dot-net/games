// <copyright file="StringTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public sealed class StringTrie : StringTrie.INode
    {
        private readonly Node root;

        public StringTrie()
        {
            this.root = new Node();
        }

        public interface INode
        {
            bool IsTerminal { get; }

            string Value { get; }

            INode this[char key] { get; }
        }

        public int Count { get; private set; }

        public bool IsTerminal => this.root.IsTerminal;

        public string Value => this.root.Value;

        public INode this[char key] => this.root[key];

        public static StringTrie Load(Stream stream)
        {
            StringTrie trie = new StringTrie();
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        trie.Add(line);
                    }
                }
                while (line != null);
            }

            return trie;
        }

        public void Add(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            if (this.root.Add(value, 0))
            {
                ++this.Count;
            }
        }

        private sealed class Node : INode
        {
            private readonly Dictionary<char, Node> children;

            public Node()
            {
                this.children = new Dictionary<char, Node>();
            }

            public bool IsTerminal => this.Value != null;

            public string Value { get; set; }

            public INode this[char key]
            {
                get
                {
                    this.children.TryGetValue(key, out Node child);
                    return child;
                }
            }

            public bool Add(string value, int index)
            {
                if (index == value.Length)
                {
                    if (this.Value != null)
                    {
                        return false;
                    }

                    this.Value = value;
                    return true;
                }

                char key = value[index];
                if (!this.children.TryGetValue(key, out Node child))
                {
                    child = new Node();
                    this.children.Add(key, child);
                }

                return child.Add(value, index + 1);
            }
        }
    }
}
