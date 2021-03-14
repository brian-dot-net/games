// <copyright file="FindTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Benchmark
{
    using System;
    using BenchmarkDotNet.Attributes;

    [InProcess]
    public class FindTrie : LoadTrieBase
    {
        private const string WordStringMissing = "ZOATECHNICAL";
        private const string WordString6 = "LOCKED";
        private const string WordString12 = "ZOOTECHNICAL";

        private static readonly Str WordStrMissing = Str.Parse(WordStringMissing);
        private static readonly Str WordStr6 = Str.Parse(WordString6);
        private static readonly Str WordStr12 = Str.Parse(WordString12);

        private StringTrie stringTrie;
        private StrTrie strTrie;

        [Params(-1, 6, 12)]
        public int Len { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            WriteFiles();
            this.stringTrie = LoadString(100);
            this.strTrie = LoadStr(100);
        }

        [Benchmark]
        public int StringF()
        {
            return Find(this.stringTrie, this.WordString(), 0);
        }

        [Benchmark]
        public int StrF()
        {
            return Find(this.strTrie, this.WordStr());
        }

        private static int Find(StringTrie.INode node, string word, int index)
        {
            if (node == null)
            {
                return -1;
            }

            if (index == word.Length)
            {
                return node.Value.Length;
            }

            return Find(node[word[index]], word, index + 1);
        }

        private static int Find(StrTrie trie, Str word)
        {
            return (int)trie.Find(word);
        }

        private string WordString()
        {
            switch (this.Len)
            {
                case -1: return WordStringMissing;
                case 6: return WordString6;
                case 12: return WordString12;
                default: throw new NotImplementedException();
            }
        }

        private Str WordStr()
        {
            switch (this.Len)
            {
                case -1: return WordStrMissing;
                case 6: return WordStr6;
                case 12: return WordStr12;
                default: throw new NotImplementedException();
            }
        }
    }
}
