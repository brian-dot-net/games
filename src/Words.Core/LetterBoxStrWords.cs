// <copyright file="LetterBoxStrWords.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class LetterBoxStrWords
    {
        private readonly Dictionary<Ch, HashSet<Word>> words;

        public LetterBoxStrWords()
        {
            this.words = new Dictionary<Ch, HashSet<Word>>();
        }

        public void Add(Str word, LetterBoxStr.Vertices verts)
        {
            HashSet<Word> keyedWords;
            Ch key = word[0];
            if (!this.words.TryGetValue(key, out keyedWords))
            {
                keyedWords = new HashSet<Word>();
                this.words.Add(key, keyedWords);
            }

            keyedWords.Add(new Word(word, verts));
        }

        public void Find(Action<Str, Str> found)
        {
            foreach (Word w1 in this.words.Values.SelectMany(w => w))
            {
                if (this.words.TryGetValue(w1.Last, out HashSet<Word> inner))
                {
                    foreach (Word w2 in inner)
                    {
                        if (Word.IsSolution(w1, w2))
                        {
                            found(w1.ToStr(), w2.ToStr());
                        }
                    }
                }
            }
        }

        private struct Word
        {
            private readonly Str word;
            private readonly LetterBoxStr.Vertices verts;

            public Word(Str word, LetterBoxStr.Vertices verts)
            {
                this.word = word;
                this.verts = verts;
            }

            public Ch Last => this.word[this.word.Length - 1];

            public static bool IsSolution(Word w1, Word w2)
            {
                LetterBoxStr.Vertices v = w1.verts + w2.verts;
                return v.IsComplete;
            }

            public Str ToStr() => this.word;
        }
    }
}