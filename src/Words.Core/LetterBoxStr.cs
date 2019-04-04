// <copyright file="LetterBoxStr.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    public sealed class LetterBoxStr
    {
        private readonly Str box;

        public LetterBoxStr(Str box)
        {
            this.box = box;
        }

        public Ch this[byte vertex] => this.box[vertex];
    }
}