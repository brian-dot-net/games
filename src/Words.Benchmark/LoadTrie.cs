// <copyright file="LoadTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Benchmark
{
    using BenchmarkDotNet.Attributes;

    [CoreJob]
    [MemoryDiagnoser]
    public class LoadTrie : LoadTrieBase
    {
        [Params(25, 50, 100)]
        public int Pct { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            WriteFiles();
        }

        [Benchmark]
        public int String()
        {
            StringTrie trie = LoadString(this.Pct);
            return trie.Count;
        }

        [Benchmark]
        public int Str()
        {
            StrTrie trie = LoadStr(this.Pct);
            return trie.Count;
        }
    }
}
