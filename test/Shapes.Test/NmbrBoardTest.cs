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

            PlaceValid(board, Nmbr.Zero0, 40, 40);

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
            PlaceValid(board, Nmbr.Zero0, 40, 40);

            PlaceValid(board, Nmbr.Zero1, 43, 40);

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
            PlaceValid(board, Nmbr.Zero0, 40, 40);

            PlaceInvalid(board, Nmbr.Zero1, 42, 40);

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
            PlaceValid(board, Nmbr.Zero0, 40, 40);

            PlaceInvalid(board, Nmbr.Zero1, 41, 41);

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
            PlaceValid(board, Nmbr.Zero0, 40, 40);
            PlaceInvalid(board, Nmbr.Zero1, 41, 41);

            PlaceValid(board, Nmbr.Zero1, 43, 41);

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

            PlaceValid(board, Nmbr.Zero0, 0, 40);
            PlaceValid(board, Nmbr.One0, 3, 40);
            PlaceValid(board, Nmbr.Two0, 5, 40);
            PlaceValid(board, Nmbr.Three0, 8, 40);
            PlaceValid(board, Nmbr.Four0, 11, 40);
            PlaceValid(board, Nmbr.Five0, 0, 44);
            PlaceValid(board, Nmbr.Six0, 3, 44);
            PlaceValid(board, Nmbr.Seven0, 6, 44);
            PlaceValid(board, Nmbr.Eight0, 8, 44);
            PlaceValid(board, Nmbr.Nine0, 11, 44);

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
            PlaceValid(board, Nmbr.Zero0, 40, 40);

            PlaceInvalid(board, Nmbr.Zero1, 43, 44);

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
            PlaceValid(board, Nmbr.Zero0, 4, 40);

            PlaceValid(board, Nmbr.Zero1, 0, 40);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceAdjacentRightEdge()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(73) + "0 0 0 1 1 1 1 " + NL +
                BlankSquares(73) + "0 . 0 1 . . 1 " + NL +
                BlankSquares(73) + "0 . 0 1 1 1 1 " + NL +
                BlankSquares(73) + "0 0 0 . . . . " + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 73, 40);

            PlaceValid(board, Nmbr.Zero1, 76, 40);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceAdjacentTopLeftCorner()
        {
            string expected =
                "1 1 1 1 0 0 0 " + BlankSquares(73) + NL +
                "1 . . 1 0 . 0 " + BlankSquares(73) + NL +
                "1 1 1 1 0 . 0 " + BlankSquares(73) + NL +
                ". . . . 0 0 0 " + BlankSquares(73) + NL +
                BlankLines(76);
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 4, 0);

            PlaceValid(board, Nmbr.Zero1, 0, 0);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceAdjacentBottomRightCorner()
        {
            string expected =
                BlankLines(76) +
                BlankSquares(73) + "0 0 0 1 1 1 1 " + NL +
                BlankSquares(73) + "0 . 0 1 . . 1 " + NL +
                BlankSquares(73) + "0 . 0 1 1 1 1 " + NL +
                BlankSquares(73) + "0 0 0 . . . . " + NL;
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 73, 76);

            PlaceValid(board, Nmbr.Zero1, 76, 76);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceFirstPieceExtremeBottomRightCorner()
        {
            string expected =
                BlankLines(76) +
                BlankSquares(76) + ". . . . " + NL +
                BlankSquares(76) + ". . . . " + NL +
                BlankSquares(76) + "0 0 0 0 " + NL +
                BlankSquares(76) + "0 . . . " + NL;
            NmbrBoard board = new NmbrBoard();

            PlaceValid(board, Nmbr.One3, 76, 78);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceFirstPieceTooFarBottomRightCornerFails()
        {
            string expected = BlankLines(80);
            NmbrBoard board = new NmbrBoard();

            PlaceInvalid(board, Nmbr.One3, 79, 79);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceFirstPieceTooFarBottomLeftCornerFails()
        {
            string expected = BlankLines(80);
            NmbrBoard board = new NmbrBoard();

            PlaceInvalid(board, Nmbr.One2, 0, 79);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceFirstPieceOnLayerOneFails()
        {
            string expected = BlankLines(80);
            NmbrBoard board = new NmbrBoard();

            PlaceInvalid(board, Nmbr.One2, 40, 40, 1);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceSecondPieceOnLayerOneFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 . " + BlankSquares(36) + NL +
                BlankSquares(40) + "0 . 0 . " + BlankSquares(36) + NL +
                BlankSquares(40) + "0 . 0 . " + BlankSquares(36) + NL +
                BlankSquares(40) + "0 0 0 . " + BlankSquares(36) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 40, 40);

            PlaceInvalid(board, Nmbr.One2, 40, 40, 1);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceThirdPieceOnLayerOneWithOverhangFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 . . 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 40, 40);
            PlaceValid(board, Nmbr.Zero1, 43, 40);

            PlaceInvalid(board, Nmbr.One0, 42, 40, 1);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceThirdPieceOnLayerOneDirectlyAboveOnePieceFails()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 . . 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 40, 40);
            PlaceValid(board, Nmbr.Zero1, 43, 40);

            PlaceInvalid(board, Nmbr.One0, 41, 40, 1);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void PlaceThirdPieceOnLayerOneWithNoOverhangAboveTwoPieces()
        {
            string expected =
                BlankLines(40) +
                BlankSquares(40) + "0 0 2 2 2 2 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 2 1 . . 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 . 0 1 1 1 1 " + BlankSquares(33) + NL +
                BlankSquares(40) + "0 0 0 . . . . " + BlankSquares(33) + NL +
                BlankLines(36);
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Zero0, 40, 40);
            PlaceValid(board, Nmbr.Zero1, 43, 40);

            PlaceValid(board, Nmbr.One3, 42, 40, 1);

            board.ToString().Should().Be(expected);
        }

        [Fact]
        public void ScoreZeroPieces()
        {
            NmbrBoard board = new NmbrBoard();

            board.Score().Should().Be(0);
        }

        [Fact]
        public void ScoreNineOnLayerZero()
        {
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Nine0, 40, 40);

            board.Score().Should().Be(0);
        }

        [Fact]
        public void ScoreNineOnLayerOne()
        {
            NmbrBoard board = new NmbrBoard();
            PlaceValid(board, Nmbr.Eight0, 40, 40);
            PlaceValid(board, Nmbr.Eight0, 42, 40);
            PlaceValid(board, Nmbr.Nine2, 40, 40, 1);

            board.Score().Should().Be(9);
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

        private static void PlaceValid(NmbrBoard board, Nmbr piece, byte x0, byte y0, byte level = 0)
        {
            board.Place(piece, new Point(x0, y0), level).Should().BeTrue();
        }

        private static void PlaceInvalid(NmbrBoard board, Nmbr piece, byte x0, byte y0, byte level = 0)
        {
            board.Place(piece, new Point(x0, y0), level).Should().BeFalse();
        }
    }
}
