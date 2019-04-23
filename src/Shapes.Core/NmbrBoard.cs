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

        public NmbrBoard()
        {
            this.board = new byte[Side * Side];
        }

        public void PlaceFirst(Nmbr piece)
        {
            for (int y = 0; y < Nmbr.Side; ++y)
            {
                for (int x = 0; x < Nmbr.Side; ++x)
                {
                    if (piece[x, y])
                    {
                        this.board[Index(40 + x, 40 + y)] = 1;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(2 * Side * (Side + 1));
            for (int y = 0; y < Side; ++y)
            {
                for (int x = 0; x < Side; ++x)
                {
                    byte b = this.board[Index(x, y)];
                    char c = (b == 0) ? '.' : '0';
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
