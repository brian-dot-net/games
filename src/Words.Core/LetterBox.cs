// <copyright file="LetterBox.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    public sealed class LetterBox
    {
        private readonly string box;

        public LetterBox(string box)
        {
            this.box = box;
        }

        public char this[int vertex] => this.box[vertex];
    }
}