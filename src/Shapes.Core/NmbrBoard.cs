// <copyright file="NmbrBoard.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public sealed class NmbrBoard
    {
        private const int Side = 80;

        private readonly byte[][] board;

        private byte count;

        public NmbrBoard()
        {
            this.board = new byte[10][];
            for (int i = 0; i < this.board.Length; ++i)
            {
                this.board[i] = new byte[Side * Side];
            }
        }

        public int Score() => 0;

        public bool Place(Nmbr piece, Point p, byte level)
        {
            bool validPlacement = false;
            HashSet<byte> underlying = new HashSet<byte>();
            int maxIndex = 0;
            for (byte y = 0; y < Nmbr.Side; ++y)
            {
                for (byte x = 0; x < Nmbr.Side; ++x)
                {
                    if (piece[x, y])
                    {
                        if (level == 0)
                        {
                            if (!validPlacement && this.CheckAdjacent(x, y, p, level))
                            {
                                validPlacement = true;
                            }
                        }

                        int i = Index(x + p.X, y + p.Y);
                        if ((i < 0) || (this.board[level][i] != 0))
                        {
                            this.UndoPlace(level, p, maxIndex);
                            return false;
                        }

                        if (level > 0)
                        {
                            underlying.Add(this.board[level - 1][i]);
                        }

                        this.board[level][i] = (byte)(this.count + 1);
                        maxIndex = i;
                    }
                }
            }

            if (this.count == 0)
            {
                validPlacement = true;
            }

            if (level > 0)
            {
                validPlacement = (underlying.Count > 1) && !underlying.Contains(0);
            }

            if (!validPlacement)
            {
                this.UndoPlace(level, p, maxIndex);
                return false;
            }

            ++this.count;
            return true;
        }

        public override string ToString()
        {
            char[] buffer = new char[2 * Side * (Side + 1)];
            for (byte i = 0; i < this.board.Length; ++i)
            {
                this.WriteBoard(buffer, i);
            }

            return new string(buffer);
        }

        private static int Index(int x, int y)
        {
            if ((x < 0) || (x >= Side) || (y < 0) || (y >= Side))
            {
                return -1;
            }

            return (y * Side) + x;
        }

        private void WriteBoard(char[] buffer, byte level)
        {
            int i = 0;
            for (byte y = 0; y < Side; ++y)
            {
                for (byte x = 0; x < Side; ++x)
                {
                    byte b = this.board[level][Index(x, y)];
                    char c;
                    if (b > 0)
                    {
                        c = (char)(b + '0' - 1);
                    }
                    else if (level == 0)
                    {
                        c = '.';
                    }
                    else
                    {
                        c = buffer[i];
                    }

                    buffer[i++] = c;
                    buffer[i++] = ' ';
                }

                buffer[i++] = Environment.NewLine[0];
                buffer[i++] = Environment.NewLine[1];
            }
        }

        private bool CheckAdjacent(byte x, byte y, Point p, byte level)
        {
            if (this.CheckAdjacentX(x, p.X, y + p.Y, level))
            {
                return true;
            }

            return this.CheckAdjacentY(y, p.Y, x + p.X, level);
        }

        private bool CheckAdjacentX(byte x, byte x0, int y1, byte level)
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

            return (i >= 0) && (this.board[level][i] != 0);
        }

        private bool CheckAdjacentY(byte y, byte y0, int x1, byte level)
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

            return (i >= 0) && (this.board[level][i] != 0);
        }

        private void UndoPlace(byte level, Point p, int max)
        {
            byte[] topBoard = this.board[level];
            for (byte y = 0; y < Nmbr.Side; ++y)
            {
                for (byte x = 0; x < Nmbr.Side; ++x)
                {
                    int i = Index(p.X + x, p.Y + y);
                    if ((i < 0) || (i > max))
                    {
                        return;
                    }

                    topBoard[i] = 0;
                }
            }
        }
    }
}
