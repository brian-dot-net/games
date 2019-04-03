// <copyright file="StrTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Collections.Generic;

    public sealed class StrTrie
    {
        private readonly Dictionary<Str, bool> nodes;

        public StrTrie()
        {
            this.nodes = new Dictionary<Str, bool>();
        }

        public enum NodeKind : byte
        {
            None = 0,
            Prefix = 1,
            Terminal = 2,
        }

        public int Count { get; private set; }

        public void Add(Str value)
        {
            ++this.Count;
            this.nodes[value] = true;
            for (byte i = 1; i < value.Length; ++i)
            {
                value = value.Chop();
                this.nodes[value] = false;
            }
        }

        public NodeKind Find(Str value)
        {
            bool isTerminal;
            if (!this.nodes.TryGetValue(value, out isTerminal))
            {
                return NodeKind.None;
            }

            return isTerminal ? NodeKind.Terminal : NodeKind.Prefix;
        }
    }
}
