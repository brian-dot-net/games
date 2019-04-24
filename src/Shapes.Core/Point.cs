// <copyright file="Point.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes
{
    public struct Point
    {
        public Point(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }

        public byte X { get; }

        public byte Y { get; }
    }
}
