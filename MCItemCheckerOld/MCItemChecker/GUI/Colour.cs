using System.Diagnostics;

namespace MCItemChecker.GUI
{
    [DebuggerDisplay("A:{m_a} R:{m_r} G:{m_g} B:{m_b}")]
    internal struct Colour
    {
        readonly byte m_a;
        readonly byte m_r;
        readonly byte m_g;
        readonly byte m_b;

        public Colour(byte r, byte g, byte b)
            : this(255, r, g, b)
        { }

        public Colour(byte a, byte r, byte g, byte b)
        {
            m_a = a;
            m_r = r;
            m_g = g;
            m_b = b;
        }

        public static implicit operator System.Drawing.Color(Colour c)
            => System.Drawing.Color.FromArgb(c.m_a, c.m_r, c.m_g, c.m_b);

        public static implicit operator Colour(System.Drawing.Color c)
            => new Colour(c.A, c.R, c.G, c.B);

        public static Colour SelectedDone
            => new Colour(153, 255, 153);

        public static Colour Transparent
            => new Colour(0, 255, 255, 255);
    }
}
