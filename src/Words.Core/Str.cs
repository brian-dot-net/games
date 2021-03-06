﻿// <copyright file="Str.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System;
    using System.Text;

    public struct Str : IEquatable<Str>
    {
        private readonly ulong data;

        private Str(ulong data)
        {
            this.data = data;
        }

        public byte Length => (byte)(this.data & 0xF);

        public Ch this[int index]
        {
            get
            {
                if (index > 11)
                {
                    throw new IndexOutOfRangeException();
                }

                byte b = (byte)(this.data >> (4 + (5 * index)) & 0x1F);
                return (Ch)b;
            }
        }

        public static Str Parse(string s)
        {
            Str value = default(Str);
            foreach (char c in s)
            {
                value = value.Append((Ch)(c - 'A' + 1));
            }

            return value;
        }

        public bool Equals(Str other) => this.data == other.data;

        public override int GetHashCode() => this.data.GetHashCode();

        public Str Append(Ch c)
        {
            if (this.Length == 12)
            {
                throw new InvalidOperationException();
            }

            ulong ch = (ulong)c << (4 + (5 * this.Length));
            return new Str((ch | this.data) + 1);
        }

        public Str Chop()
        {
            if (this.Length == 0)
            {
                throw new InvalidOperationException();
            }

            ulong mask = ~(0x1FUL << (4 + ((this.Length - 1) * 5)));
            return new Str((this.data & mask) - 1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(this.Length);
            for (byte i = 0; i < this.Length; ++i)
            {
                char c = (char)('A' - 1 + (char)this[i]);
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
