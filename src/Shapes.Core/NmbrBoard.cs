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

                        int i = Index(x + x0, y + y0);
                        if ((i < 0) || (this.board[i] != 0))
                        {
                            this.UndoPlace(x0, y0, maxIndex);
                            return false;
                        }

                        this.board[i] = (byte)(this.count + 1);
                        maxIndex = i;
                    }
                }
            }

            if ((this.count > 0) && !anyAdjacent)
            {
                this.UndoPlace(x0, y0, maxIndex);
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

        private static int Index(int x, int y)
        {
            if ((x < 0) || (x >= Side) || (y < 0) || (y >= Side))
            {
                return -1;
            }

            return (y * Side) + x;
        }

        private bool CheckAdjacent(byte x, byte y, byte x0, byte y0)
        {
            if (this.CheckAdjacentX(x, x0, y + y0))
            {
                return true;
            }

            return this.CheckAdjacentY(y, y0, x + x0);
        }

        private bool CheckAdjacentX(byte x, byte x0, int y1)
        {
            int i = -1;
            if (x == 0)
            {
                i = Index(x + x0 - 1, y1);
            }
            else if (x == (Nmbr.Side - 1))
            {
                i = Index(x + x0 + 1, y1);
            }

            return (i >= 0) && (this.board[i] != 0);
        }

        private bool CheckAdjacentY(byte y, byte y0, int x1)
        {
            int i = -1;
            if (y == 0)
            {
                i = Index(x1, y + y0 - 1);
            }
            else if (y == (Nmbr.Side - 1))
            {
                i = Index(x1, y + y0 + 1);
            }

            return (i >= 0) && (this.board[i] != 0);
        }

        private void UndoPlace(byte x0, byte y0, int max)
        {
            for (byte y = 0; y < Nmbr.Side; ++y)
            {
                for (byte x = 0; x < Nmbr.Side; ++x)
                {
                    int i = Index(x0 + x, y0 + y);
                    if ((i < 0) || (i > max))
                    {
                        return;
                    }

                    this.board[i] = 0;
                }
            }
        }
    }
}
