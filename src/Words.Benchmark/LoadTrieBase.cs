// <copyright file="LoadTrieBase.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Benchmark
{
    using System.Collections.Generic;
    using System.IO;

    public abstract class LoadTrieBase
    {
        protected LoadTrieBase()
        {
        }

        protected static void WriteFiles()
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

        protected static StringTrie LoadString(int pct) => StringTrie.Load(File.OpenRead(FileName(pct)));

        protected static StrTrie LoadStr(int pct) => StrTrie.Load(File.OpenRead(FileName(pct)));

        private static string FileName(int pct) => $"words_{pct}.txt";
    }
}
