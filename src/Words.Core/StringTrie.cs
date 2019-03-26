// <copyright file="StringTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System.Collections.Generic;

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

            INode this[char key] { get; }
        }

        public int Count { get; private set; }

        public bool IsTerminal => this.root.IsTerminal;

        public INode this[char key] => this.root[key];

        public void Add(string value)
        {
            if (this.root.Add(value))
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

            public bool IsTerminal { get; private set; }

            public INode this[char key] => this.children[key];

            public bool Add(string value)
            {
                if (value.Length == 0)
                {
                    this.IsTerminal = true;
                    return true;
                }

                char key = value[0];
                if (!this.children.TryGetValue(key, out Node child))
                {
                    child = new Node();
                    this.children.Add(key, child);
                }

                return child.Add(value.Substring(1));
            }
        }
    }
}
