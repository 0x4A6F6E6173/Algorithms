namespace Algorithms.Helpers
{
    public static class DoubleComparison
    {
        public static readonly double oneDigitPrecision = 0.1;
        public static readonly double twoDigitPrecision = 0.01;
        public static readonly double threeDigitPrecision = 0.001;
        public static readonly double fourDigitPrecision = 0.0001;
        public static readonly double fiveDigitPrecision = 0.00001;

        /*
         * Precision in Comparisons The Equals method should be used with caution, 
         * because two apparently equivalent values can be unequal due to the differing 
         * precision of the two values. The following example reports that the 
         * Double value .3333 and the Double returned by dividing 1 by 3 are unequal.
         * 
         * Rather than comparing for equality, one recommended technique involves 
         * defining an acceptable margin of difference between two values 
         * (such as .01% of one of the values). If the absolute value of the 
         * difference between the two values is less than or equal to that margin, 
         * the difference is likely to be due to differences in precision and, 
         * therefore, the values are likely to be equal. The following example 
         * uses this technique to compare .33333 and 1/3, the two Double values 
         * that the previous code example found to be unequal.
         * 
         */

        public static bool CompareDoubles(in double a, in double b, double precision = 0.01) =>
            Math.Abs(a - b) < precision;

    }
}
