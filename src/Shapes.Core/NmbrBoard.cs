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
            for (byte y = 0; y < Nmbr.Side; ++y)
            {
                for (byte x = 0; x < Nmbr.Side; ++x)
                {
                    if (piece[x, y])
                    {
                        int i = Index(x + x0, y + y0);
                        if (this.board[i] != 0)
                        {
                            this.UndoPlace(x0, y0, i);
                            return false;
                        }

                        this.board[i] = (byte)(this.count + 1);
                    }
                }
            }

            ++this.count;
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(2 * Side * (Side + 1));
            for (byte y = 0; y < Side; ++y)
            {
                for (byte x = 0; x < Side; ++x)
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

        private void UndoPlace(byte x0, byte y0, int max)
        {
            for (byte y = 0; y < Nmbr.Side; ++y)
            {
                for (byte x = 0; x < Nmbr.Side; ++x)
                {
                    int i = Index(x0 + x, y0 + y);
                    if (i >= max)
                    {
                        return;
                    }

                    this.board[i] = 0;
                }
            }
        }
    }
}
