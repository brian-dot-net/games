// <copyright file="LetterBoxStr.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Text;

    public sealed class LetterBoxStr
    {
        private readonly Str box;

        public LetterBoxStr(Str box)
        {
            this.box = box;
        }

        public Ch this[byte vertex] => this.box[vertex];

        public Vertices Next(byte start)
        {
            switch (start)
            {
                case 0:
                case 1:
                case 2:
                    return new Vertices(0b111111111000);
                case 3:
                case 4:
                case 5:
                    return new Vertices(0b111111000111);
                case 6:
                case 7:
                case 8:
                    return new Vertices(0b111000111111);
                case 9:
                case 10:
                case 11:
                    return new Vertices(0b000111111111);
                default:
                    throw new ArgumentOutOfRangeException(nameof(start));
            }
        }

        public struct Vertices
        {
            private readonly ushort bits;

            public Vertices(ushort bits)
            {
                this.bits = bits;
            }

            public bool this[int index] => ((this.bits >> index) & 1) == 1;

            public static Vertices operator +(Vertices x, Vertices y)
            {
                return new Vertices((ushort)(x.bits | y.bits));
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder(12);
                for (int i = 0; i < 12; ++i)
                {
                    sb.Append(this[i] ? '1' : '0');
                }

                return sb.ToString();
            }
        }
    }
}