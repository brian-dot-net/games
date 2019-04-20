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
