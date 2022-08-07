// <copyright file="FindWords.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Benchmark
{
    using System.IO;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    [InProcess]
    [MemoryDiagnoser]
    public class FindWords
    {
        private LetterBoxSearch? stringSearch;
        private LetterBoxStrSearch? strSearch;

        [GlobalSetup]
        public void Setup()
        {
            this.stringSearch = new LetterBoxSearch(
                StringTrie.Load(File.OpenRead("words.txt")),
                new LetterBox("RMEWCLTGKAPI"));

            this.strSearch = new LetterBoxStrSearch(
                StrTrie.Load(File.OpenRead("words.txt")),
                new LetterBoxStr(Str.Parse("RMEWCLTGKAPI")));
        }

        [Benchmark]
        public int StringF()
        {
            int count = 0;
            this.stringSearch!.Run((w, v) => ++count);
            return count;
        }

        [Benchmark]
        public int StrF()
        {
            int count = 0;
            this.strSearch!.Run((w, v) => ++count);
            return count;
        }
    }
}