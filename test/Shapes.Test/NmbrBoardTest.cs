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

            board.Place(Nmbr.Zero0, 40, 40).Should().BeTrue();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceAdjacent()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 . . 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            board.Place(Nmbr.Zero0, 40, 40);

            board.Place(Nmbr.Zero1, 43, 40).Should().BeTrue();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceOverlappingFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            board.Place(Nmbr.Zero0, 40, 40);

            board.Place(Nmbr.Zero1, 42, 40).Should().BeFalse();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPiecePartiallyOverlappingFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            board.Place(Nmbr.Zero0, 40, 40);

            board.Place(Nmbr.Zero1, 41, 41).Should().BeFalse();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSuccessfulSecondPieceAdjacentAfterSecondPieceFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 . . 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            board.Place(Nmbr.Zero0, 40, 40);
            board.Place(Nmbr.Zero1, 41, 41);

            board.Place(Nmbr.Zero1, 43, 41).Should().BeTrue();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceTenPieces()
        {
            string expected =
                BlankLines(40) +
                "0 0 0 1 1 . 2 2 3 3 3 . 4 4 . " + BlankSquares(65) + NL +
                "0 . 0 . 1 . 2 2 . . 3 . 4 . . " + BlankSquares(65) + NL +
                "0 . 0 . 1 2 2 . . 3 3 4 4 4 . " + BlankSquares(65) + NL +
                "0 0 0 . 1 2 2 2 3 3 3 . 4 4 . " + BlankSquares(65) + NL +
                "5 5 5 6 6 . 7 7 7 8 8 9 9 9 . " + BlankSquares(65) + NL +
                "5 5 5 6 . . . 7 . 8 8 9 9 9 . " + BlankSquares(65) + NL +
                ". . 5 6 6 6 7 7 8 8 . 9 9 . . " + BlankSquares(65) + NL +
                "5 5 5 6 6 6 7 . 8 8 . 9 9 . . " + BlankSquares(65) + NL +
                BlankLines(32);
            NmbrBoard board = new NmbrBoard();

            board.Place(Nmbr.Zero0, 0, 40).Should().BeTrue();
            board.Place(Nmbr.One0, 3, 40).Should().BeTrue();
            board.Place(Nmbr.Two0, 5, 40).Should().BeTrue();
            board.Place(Nmbr.Three0, 8, 40).Should().BeTrue();
            board.Place(Nmbr.Four0, 11, 40).Should().BeTrue();
            board.Place(Nmbr.Five0, 0, 44).Should().BeTrue();
            board.Place(Nmbr.Six0, 3, 44).Should().BeTrue();
            board.Place(Nmbr.Seven0, 6, 44).Should().BeTrue();
            board.Place(Nmbr.Eight0, 8, 44).Should().BeTrue();
            board.Place(Nmbr.Nine0, 11, 44).Should().BeTrue();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceNotAdjacentToFirstFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 . . . . " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            board.Place(Nmbr.Zero0, 40, 40);

            board.Place(Nmbr.Zero1, 43, 44).Should().BeFalse();

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceAdjacentLeftEdge()
        {
            string expected =
                BlankLines(40) +
                "1 1 1 1 0 0 0 " + BlankSquares(73) + NL +
                "1 . . 1 0 . 0 " + BlankSquares(73) + NL +
                "1 1 1 1 0 . 0 " + BlankSquares(73) + NL +
                ". . . . 0 0 0 " + BlankSquares(73) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            board.Place(Nmbr.Zero0, 4, 40);

            board.Place(Nmbr.Zero1, 0, 40).Should().BeTrue();

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
