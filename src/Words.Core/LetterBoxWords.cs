// <copyright file="LetterBoxWords.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class LetterBoxWords
    {
        private readonly Dictionary<char, HashSet<Word>> words;

        public LetterBoxWords()
        {
            this.words = new Dictionary<char, HashSet<Word>>();
        }

        public void Add(string word, LetterBox.Vertices verts)
        {
            HashSet<Word> keyedWords;
            char key = word[0];
            if (!this.words.TryGetValue(key, out keyedWords))
            {
                keyedWords = new HashSet<Word>();
                this.words.Add(key, keyedWords);
            }

            keyedWords.Add(new Word(word, verts));
        }

        public void Find(Action<string, string> found)
        {
            foreach (Word w1 in this.words.Values.SelectMany(w => w))
            {
                if (this.words.TryGetValue(w1.Last, out HashSet<Word> inner))
                {
                    foreach (Word w2 in inner)
                    {
                        if (Word.IsSolution(w1, w2))
                        {
                            found(w1.ToString(), w2.ToString());
                        }
                    }
                }
            }
        }

        private struct Word : IEquatable<Word>
        {
            private readonly string word;
            private readonly LetterBox.Vertices verts;

            public Word(string word, LetterBox.Vertices verts)
            {
                this.word = word;
                this.verts = verts;
            }

            public char Last => this.word[this.word.Length - 1];

            public static bool IsSolution(Word w1, Word w2)
            {
                LetterBox.Vertices union = w1.verts + w2.verts;
                return union.IsComplete;
            }

            public bool Equals(Word other) => this.word == other.word;

            public override int GetHashCode() => this.word.GetHashCode();

            public override string ToString() => this.word;
        }
    }
}