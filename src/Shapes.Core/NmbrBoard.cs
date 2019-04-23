// <copyright file="NmbrBoard.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes
{
    using System;
    using System.Text;

    public sealed class NmbrBoard
    {
        private const int Side = 80;

        private readonly byte[] board;

        private byte count;

        public NmbrBoard()
        {
            this.board = new byte[Side * Side];
        }

        public bool Place(Nmbr piece, byte x0, byte y0)
        {
            ++this.count;
            for (int y = 0; y < Nmbr.Side; ++y)
            {
                for (int x = 0; x < Nmbr.Side; ++x)
                {
                    if (piece[x, y])
                    {
                        this.board[Index(x0 + x, y0 + y)] = this.count;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(2 * Side * (Side + 1));
            for (int y = 0; y < Side; ++y)
            {
                for (int x = 0; x < Side; ++x)
                {
                    byte b = this.board[Index(x, y)];
                    char c = '.';
                    if (b > 0)
                    {
                        c = (char)(b + '0' - 1);
                    }

                    sb.Append(c);
                    sb.Append(' ');
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private static int Index(int x, int y) => (y * Side) + x;
    }
}
