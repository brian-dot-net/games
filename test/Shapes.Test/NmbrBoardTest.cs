// <copyright file="NmbrBoardTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes.Test
{
    using System;
    using System.Text;
    using FluentAssertions;
    using Xunit;

    public sealed class NmbrBoardTest
    {
        private static readonly string NL = Environment.NewLine;

        [Fact]
        public void PlaceFirstPiece()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 . " + BlankSquares(36) + NL +
                BlankSquares(40) + "0 . 0 . " + BlankSquares(36) + NL +
                BlankSquares(40) + "0 . 0 . " + BlankSquares(36) + NL +
                BlankSquares(40) + "0 0 0 . " + BlankSquares(36) + NL +
                BlankLines(36);

            NmbrBoard board = new NmbrBoard();

            board.PlaceFirst(Nmbr.Zero0);

            board.ToString().Should().Be(expected);
        }

        private static string BlankLines(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                sb.Append(BlankSquares(80));
                sb.Append(NL);
            }

            return sb.ToString();
        }

        private static string BlankSquares(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                sb.Append('.');
                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
