// <copyright file="Nmbr.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Shapes
{
    using System;
    using System.Text;

    public struct Nmbr
    {
        public static readonly Nmbr Zero0 = new Nmbr(0x7557);
        public static readonly Nmbr Zero1 = new Nmbr(0x0F9F);
        public static readonly Nmbr One0 = new Nmbr(0x2223);
        public static readonly Nmbr One1 = new Nmbr(0x00F8);
        public static readonly Nmbr One2 = new Nmbr(0x3111);
        public static readonly Nmbr One3 = new Nmbr(0x001F);
        public static readonly Nmbr Two0 = new Nmbr(0x7366);
        public static readonly Nmbr Two1 = new Nmbr(0x0DF7);
        public static readonly Nmbr Two2 = new Nmbr(0x3767);
        public static readonly Nmbr Two3 = new Nmbr(0x0CFB);
        public static readonly Nmbr Three0 = new Nmbr(0x7647);
        public static readonly Nmbr Three1 = new Nmbr(0x0FB9);
        public static readonly Nmbr Three2 = new Nmbr(0x7137);
        public static readonly Nmbr Three3 = new Nmbr(0x09DF);
        public static readonly Nmbr Four0 = new Nmbr(0x6726);
        public static readonly Nmbr Four1 = new Nmbr(0x0BF2);
        public static readonly Nmbr Four2 = new Nmbr(0x3273);
        public static readonly Nmbr Four3 = new Nmbr(0x04FD);
        public static readonly Nmbr Five0 = new Nmbr(0x7477);
        public static readonly Nmbr Five1 = new Nmbr(0x0FDD);
        public static readonly Nmbr Five2 = new Nmbr(0x7717);
        public static readonly Nmbr Five3 = new Nmbr(0x0BBF);
        public static readonly Nmbr Six0 = new Nmbr(0x7713);
        public static readonly Nmbr Six1 = new Nmbr(0x03BF);
        public static readonly Nmbr Six2 = new Nmbr(0x6477);
        public static readonly Nmbr Six3 = new Nmbr(0x0FDC);
        public static readonly Nmbr Seven0 = new Nmbr(0x1327);
        public static readonly Nmbr Seven1 = new Nmbr(0x08EB);
        public static readonly Nmbr Seven2 = new Nmbr(0x7264);
        public static readonly Nmbr Seven3 = new Nmbr(0x0D71);
        public static readonly Nmbr Eight0 = new Nmbr(0x3366);
        public static readonly Nmbr Eight1 = new Nmbr(0x0CF3);
        public static readonly Nmbr Nine0 = new Nmbr(0x3377);
        public static readonly Nmbr Nine1 = new Nmbr(0x0CFF);
        public static readonly Nmbr Nine2 = new Nmbr(0x7766);

        private readonly ushort value;

        private Nmbr(ushort value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(40);
            ushort v = this.value;
            for (int j = 0; j < 4; ++j)
            {
                for (int i = 0; i < 4; ++i)
                {
                    char c = (v & 1) == 1 ? 'x' : '.';
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
