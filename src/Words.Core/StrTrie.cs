// <copyright file="StrTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.IO;

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

        public static StrTrie Load(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                StrTrie trie = new StrTrie();
                char[] buffer = new char[1024];
                Str value = default(Str);
                bool skip = false;
                int length;
                do
                {
                    length = reader.ReadBlock(buffer, 0, buffer.Length);
                    for (int i = 0; i < length; ++i)
                    {
                        char c = buffer[i];
                        switch (c)
                        {
                            case '\r':
                            case '\n':
                                if (!skip && (value.Length > 2))
                                {
                                    trie.Add(value);
                                }

                                value = default(Str);
                                skip = false;
                                break;
                            default:
                                if (!skip)
                                {
                                    if (value.Length == 12)
                                    {
                                        skip = true;
                                    }
                                    else
                                    {
                                        value = value.Append((Ch)(c - 'A' + 1));
                                    }
                                }

                                break;
                        }
                    }
                }
                while (length > 0);

                return trie;
            }
        }

        public void Add(Str value)
        {
            if (value.Length == 0)
            {
                return;
            }

            if (this.nodes.ContainsKey(value))
            {
                return;
            }

            ++this.Count;
            this.nodes[value] = true;
            for (byte i = 1; i < value.Length; ++i)
            {
                value = value.Chop();
                if (!this.nodes.ContainsKey(value))
                {
                    this.nodes.Add(value, false);
                }
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
