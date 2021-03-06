﻿// <copyright file="Program.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words.Benchmark
{
    using BenchmarkDotNet.Running;

    internal sealed class Program
    {
        private static void Main()
        {
            // BenchmarkRunner.Run<FindWords>();
            // BenchmarkRunner.Run<FindTrie>();
            BenchmarkRunner.Run<LoadTrie>();
        }
    }
}
