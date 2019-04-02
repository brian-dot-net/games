// <copyright file="Solver.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace LetterBoxedSolver
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Words;

    internal static class Solver
    {
        private static readonly Stopwatch Watch = Stopwatch.StartNew();

        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please specify a Letter Boxed puzzle and a word list file.");
                return;
            }

            LetterBox box = new LetterBox(args[0]);

            Log("Loading trie...");
            StringTrie trie = StringTrie.Load(File.OpenRead(args[1]));
            Log($"Loaded {trie.Count} words.");

            LetterBoxSearch search = new LetterBoxSearch(trie, box);
            LetterBoxWords words = new LetterBoxWords();

            Log("Finding valid words...");
            search.Run((w, v) => words.Add(w, v));
            Log($"Found {words.Count} valid words.");

            Log("Finding solutions...");
            words.Find((w1, w2) => Console.WriteLine(w1 + "-" + w2));

            Log("Done.");
        }

        private static void Log(string message)
        {
            Console.WriteLine("[{0:000.000}] {1}", Watch.Elapsed.TotalSeconds, message);
        }
    }
}
