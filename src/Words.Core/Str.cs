// <copyright file="Str.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>

namespace Words
{
    using System.Text;

    public struct Str
    {
        private readonly Ch c0;

        private Str(Ch c0)
        {
            this.c0 = c0;
        }

        public byte Length
        {
            get
            {
                if (this.c0 == Ch.None)
                {
                    return 0;
                }

                return 1;
            }
        }

        public Ch this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this.c0;
                }

                return Ch.None;
            }
        }

        public Str Append(Ch c) => new Str(c);

        public override string ToString()
        {
            if (this.c0 == Ch.None)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            char c = (char)('A' - 1 + (char)this.c0);
            sb.Append(c);
            return sb.ToString();
        }
    }
}
