// <copyright file="StringTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    public sealed class StringTrie
    {
        public int Count { get; private set; }

        public void Add(string value)
        {
            ++this.Count;
        }
    }
}
