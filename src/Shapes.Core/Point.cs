// <copyright file="Point.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes
{
    using System.Collections;
    using System.Collections.Generic;

    public struct Point
    {
        public Point(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }

        public byte X { get; }

        public byte Y { get; }

        public Enumerator GetEnumerator() => new Enumerator(this);

        public override string ToString() => $"({this.X}, {this.Y})";

        public struct Enumerator : IEnumerator<Point>
        {
            private static readonly Point Max = new Point(byte.MaxValue, byte.MaxValue);

            private readonly Point upperBound;

            public Enumerator(Point upperBound)
            {
                this.upperBound = upperBound;
                this.Current = Max;
            }

            public Point Current { get; private set; }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                // NO-OP
            }

            public bool MoveNext()
            {
                byte nextX = (byte)(this.Current.X + 1);
                byte nextY = this.Current.Y;
                if (nextX == 0)
                {
                    ++nextY;
                }
                else if (nextX == this.upperBound.X)
                {
                    nextX = 0;
                    ++nextY;
                }

                if (nextY == this.upperBound.Y)
                {
                    return false;
                }

                this.Current = new Point(nextX, nextY);
                return true;
            }

            public void Reset()
            {
                this.Current = Max;
            }
        }
    }
}
