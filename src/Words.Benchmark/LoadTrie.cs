// <copyright file="LoadTrie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Benchmark
{
    using System.Collections.Generic;
    using System.IO;
    using BenchmarkDotNet.Attributes;

    [CoreJob]
    [MemoryDiagnoser]
    public class LoadTrie
    {
        [Params(25, 50, 100)]
        public int Pct { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            string[] lines = File.ReadAllLines("words.txt");

            List<string> lines25 = new List<string>();
            List<string> lines50 = new List<string>();
            List<string> lines100 = new List<string>();
            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i];
                int n = i % 16;
                if (n < 4)
                {
                    lines25.Add(line);
                }

                if (n < 8)
                {
                    lines50.Add(line);
                }

                if (n < 16)
                {
                    lines100.Add(line);
                }
            }

            File.WriteAllLines(FileName(25), lines25);
            File.WriteAllLines(FileName(50), lines50);
            File.WriteAllLines(FileName(100), lines100);
        }

        [Benchmark]
        public int String()
        {
            StringTrie trie = StringTrie.Load(File.OpenRead(FileName(this.Pct)));
            return trie.Count;
        }

        [Benchmark]
        public int Str()
        {
            StrTrie trie = StrTrie.Load(File.OpenRead(FileName(this.Pct)));
            return trie.Count;
        }

        private static string FileName(int pct) => $"words_{pct}.txt";
    }
}
