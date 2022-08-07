// <copyright file="LetterBoxSearch.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;

    public sealed class LetterBoxSearch
    {
        private readonly StringTrie trie;
        private readonly LetterBox box;

        public LetterBoxSearch(StringTrie trie, LetterBox box)
        {
            this.trie = trie;
            this.box = box;
        }

        public void Run(Action<string, LetterBox.Vertices> found)
        {
            for (int v1 = 0; v1 < 12; ++v1)
            {
                char c = this.box[v1];
                LetterBox.Vertices verts = new LetterBox.Vertices((ushort)(1 << v1));
                this.Next(this.trie[c], v1, verts, found);
            }
        }

        private void Next(StringTrie.INode? node, int v1, LetterBox.Vertices verts, Action<string, LetterBox.Vertices> found)
        {
            if (node == null)
            {
                return;
            }

            if (node.IsTerminal)
            {
                found(node.Value!, verts);
            }

            LetterBox.Vertices next = this.box.Next(v1);
            for (int v2 = 0; v2 < 12; ++v2)
            {
                if (next[v2])
                {
                    char c = this.box[v2];
                    LetterBox.Vertices nextVerts = verts + new LetterBox.Vertices((ushort)(1 << v2));
                    this.Next(node[c], v2, nextVerts, found);
                }
            }
        }
    }
}