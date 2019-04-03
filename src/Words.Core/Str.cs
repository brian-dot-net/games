// <copyright file="Str.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    public struct Str
    {
        public byte Length => 0;

        public Ch this[int index] => Ch.None;

        public override string ToString() => string.Empty;
    }
}
