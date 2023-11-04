using System;
using System.Diagnostics;

namespace MCItemChecker.Utils.Export
{
    [DebuggerDisplay("{Numerator}/{Denominator}")]
    internal struct Fraction
    {
        public long Numerator { get; }
        public long Denominator { get; }

        public Fraction(double value)
            : this(value, 1000)
        { }

        public Fraction(double value, long maxDenominator)
        {
            var fraction = Create(value, maxDenominator);
            Numerator = fraction.Numerator;
            Denominator = fraction.Denominator;
        }

        private Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        private static Fraction Create(double fraction, long maxDenominator)
        {
            long[,] m = new long[2, 2];
            double x = fraction;
            double startx = fraction;
            long ai;

            /* initialize matrix */
            m[0, 0] = m[1, 1] = 1;
            m[0, 1] = m[1, 0] = 0;

            /* loop finding terms until denom gets too big */
            while (m[1, 0] * (ai = (long)x) + m[1, 1] <= maxDenominator)
            {
                long t;
                t = m[0, 0] * ai + m[0, 1];
                m[0, 1] = m[0, 0];
                m[0, 0] = t;
                t = m[1, 0] * ai + m[1, 1];
                m[1, 1] = m[1, 0];
                m[1, 0] = t;
                if (x == ai)
                    break; // AF: division by zero
                x = 1 / (x - ai);
                if (x > 0x7FFFFFFF)
                    break; // AF: representation failure
            }

            /* now remaining x is between 0 and 1/ai */
            /* approx as either 0 or 1/m where m is max that will fit in maxden */
            /* first try zero */
            //var one = string.Format("{0}/{1}, error = {2}\n", m[0, 0], m[1, 0],
            //   startx - ((double)m[0, 0] / (double)m[1, 0]));

            return new Fraction(m[0, 0], m[1, 0]);

            /* now try other possibility */
            //ai = (maxDenominator - m[1, 1]) / m[1, 0];
            //m[0, 0] = m[0, 0] * ai + m[0, 1];
            //m[1, 0] = m[1, 0] * ai + m[1, 1];
            //var two = string.Format("{0}/{1}, error = {2}\n", m[0, 0], m[1, 0],
            //   startx - ((double)m[0, 0] / (double)m[1, 0]));
        }

        public static long GetCommonDenominator(Fraction left, Fraction right)
            => GetCommonDenominator(left.Denominator, right.Denominator);

        public static long GetCommonDenominator(long left, long right)
            => Math.Abs(left * right) / GCD(left, right);

        private static long GCD(long n1, long n2)
            => n2 == 0 ? n1 : GCD(n2, n1 % n2);
    }

}
