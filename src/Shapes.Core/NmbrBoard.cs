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
            bool anyAdjacent = false;
            int maxIndex = 0;
            for (byte y = 0; y < Nmbr.Side; ++y)
            {
                for (byte x = 0; x < Nmbr.Side; ++x)
                {
                    if (piece[x, y])
                    {
                        if (!anyAdjacent && this.CheckAdjacent(x, y, x0, y0))
                        {
                            anyAdjacent = true;
                        }

                        maxIndex = Index(x + x0, y + y0);
                        if (this.board[maxIndex] != 0)
                        {
                            this.UndoPlace(x0, y0, maxIndex);
                            return false;
                        }

                        this.board[maxIndex] = (byte)(this.count + 1);
                    }
                }
            }

            if ((this.count > 0) && !anyAdjacent)
            {
                this.UndoPlace(x0, y0, maxIndex + 1);
                return false;
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

        private bool CheckAdjacent(byte x, byte y, byte x0, byte y0)
        {
            if (x == 0)
            {
                int xa = x + x0 - 1;
                if ((xa >= 0) && (this.board[Index(xa, y + y0)] != 0))
                {
                    return true;
                }
            }
            else if ((x == (Nmbr.Side - 1)) && (this.board[Index(x + x0 + 1, y + y0)] != 0))
            {
                return true;
            }

            if (y == 0)
            {
                int ya = y + y0 - 1;
                if ((ya >= 0) && (this.board[Index(x + x0, ya)] != 0))
                {
                    return true;
                }
            }
            else if ((y == (Nmbr.Side - 1)) && (this.board[Index(x + x0, y + y0 + 1)] != 0))
            {
                return true;
            }

            return false;
        }

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
