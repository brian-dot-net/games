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
        }
    }
}