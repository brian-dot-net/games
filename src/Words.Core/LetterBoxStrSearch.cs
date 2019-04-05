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
        }
    }
}