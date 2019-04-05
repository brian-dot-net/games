// <copyright file="LetterBoxStrSearch.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;

    public sealed class LetterBoxStrSearch
    {
        private readonly StrTrie trie;
        private readonly LetterBoxStr box;

        public LetterBoxStrSearch(StrTrie trie, LetterBoxStr box)
        {
            this.trie = trie;
            this.box = box;
        }

        public void Run(Action<Str, LetterBoxStr.Vertices> found)
        {
            byte v1 = 0;
            Ch c = this.box[v1];
            LetterBoxStr.Vertices verts = new LetterBoxStr.Vertices((ushort)(1 << v1));
            this.Next(default(Str).Append(c), v1, verts, found);
        }

        private void Next(Str str, byte v1, LetterBoxStr.Vertices verts, Action<Str, LetterBoxStr.Vertices> found)
        {
            StrTrie.NodeKind kind = this.trie.Find(str);
            if (kind == StrTrie.NodeKind.None)
            {
                return;
            }

            if (kind == StrTrie.NodeKind.Terminal)
            {
                found(str, verts);
            }

            LetterBoxStr.Vertices next = this.box.Next(v1);
            for (byte v2 = 0; v2 < 12; ++v2)
            {
                if (next[v2])
                {
                    Ch c = this.box[v2];
                    LetterBoxStr.Vertices nextVerts = verts + new LetterBoxStr.Vertices((ushort)(1 << v2));
                    this.Next(str.Append(c), v2, nextVerts, found);
                }
            }
        }
    }
}