// <copyright file="LetterBox.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System.Text;

    public sealed class LetterBox
    {
        private readonly string box;

        public LetterBox(string box)
        {
            this.box = box;
        }

        public char this[int vertex] => this.box[vertex];

        public Vertices Next(int start)
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
                default:
                    return new Vertices(0b000111111111);
            }
        }

        public struct Vertices
        {
            private readonly ushort bits;

            public Vertices(ushort bits)
            {
                this.bits = bits;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder(12);
                for (int i = 0; i < 12; ++i)
                {
                    bool b = ((this.bits >> i) & 1) == 1;
                    sb.Append(b ? '1' : '0');
                }

                return sb.ToString();
            }
        }
    }
}