// <copyright file="Nmbr.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes
{
    using System;
    using System.Text;

    public struct Nmbr
    {
        public const byte Side = 4;

        public static readonly Nmbr Zero0 = new Nmbr(0x7557, 0);
        public static readonly Nmbr Zero1 = new Nmbr(0x0F9F, 0);
        public static readonly Nmbr One0 = new Nmbr(0x2223, 1);
        public static readonly Nmbr One1 = new Nmbr(0x00F8, 1);
        public static readonly Nmbr One2 = new Nmbr(0x3111, 1);
        public static readonly Nmbr One3 = new Nmbr(0x001F, 1);
        public static readonly Nmbr Two0 = new Nmbr(0x7366, 2);
        public static readonly Nmbr Two1 = new Nmbr(0x0DF7, 2);
        public static readonly Nmbr Two2 = new Nmbr(0x3767, 2);
        public static readonly Nmbr Two3 = new Nmbr(0x0CFB, 2);
        public static readonly Nmbr Three0 = new Nmbr(0x7647, 3);
        public static readonly Nmbr Three1 = new Nmbr(0x0FB9, 3);
        public static readonly Nmbr Three2 = new Nmbr(0x7137, 3);
        public static readonly Nmbr Three3 = new Nmbr(0x09DF, 3);
        public static readonly Nmbr Four0 = new Nmbr(0x6726, 4);
        public static readonly Nmbr Four1 = new Nmbr(0x0BF2, 4);
        public static readonly Nmbr Four2 = new Nmbr(0x3273, 4);
        public static readonly Nmbr Four3 = new Nmbr(0x04FD, 4);
        public static readonly Nmbr Five0 = new Nmbr(0x7477, 5);
        public static readonly Nmbr Five1 = new Nmbr(0x0FDD, 5);
        public static readonly Nmbr Five2 = new Nmbr(0x7717, 5);
        public static readonly Nmbr Five3 = new Nmbr(0x0BBF, 5);
        public static readonly Nmbr Six0 = new Nmbr(0x7713, 6);
        public static readonly Nmbr Six1 = new Nmbr(0x03BF, 6);
        public static readonly Nmbr Six2 = new Nmbr(0x6477, 6);
        public static readonly Nmbr Six3 = new Nmbr(0x0FDC, 6);
        public static readonly Nmbr Seven0 = new Nmbr(0x1327, 7);
        public static readonly Nmbr Seven1 = new Nmbr(0x08EB, 7);
        public static readonly Nmbr Seven2 = new Nmbr(0x7264, 7);
        public static readonly Nmbr Seven3 = new Nmbr(0x0D71, 7);
        public static readonly Nmbr Eight0 = new Nmbr(0x3366, 8);
        public static readonly Nmbr Eight1 = new Nmbr(0x0CF3, 8);
        public static readonly Nmbr Nine0 = new Nmbr(0x3377, 9);
        public static readonly Nmbr Nine1 = new Nmbr(0x0CFF, 9);
        public static readonly Nmbr Nine2 = new Nmbr(0x7766, 9);
        public static readonly Nmbr Nine3 = new Nmbr(0x0FF3, 9);

        private readonly ushort bits;

        private Nmbr(ushort bits, byte value)
        {
            this.bits = bits;
            this.Value = value;
        }

        public byte Value { get; }

        public bool this[Point p] => ((this.bits >> ((p.Y * Side) + p.X)) & 1) == 1;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(40);
            ushort v = this.bits;
            char d = (char)(this.Value + '0');
            for (int j = 0; j < 4; ++j)
            {
                for (int i = 0; i < 4; ++i)
                {
                    char c = (v & 1) == 1 ? d : '.';
                    sb.Append(c);
                    sb.Append(' ');
                    v >>= 1;
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
