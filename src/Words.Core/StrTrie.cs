// <copyright file="StrTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    public sealed class StrTrie
    {
        public int Count { get; private set; }

        public void Add(Str value)
        {
            ++this.Count;
        }
    }
}
