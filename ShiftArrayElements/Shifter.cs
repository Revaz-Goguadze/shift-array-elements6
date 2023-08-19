namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (see README.md for detailed instructions).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static void Shift(int[] source, int[] iterations)
        {
            if (source.Length == 0 || iterations.Length == 0)
            {
                return;
            }

            int length = source.Length;

            for (int i = 0; i < iterations.Length; i++)
            {
                int currentIteration = iterations[i];

                if (i % 2 == 0)
                {
                    ShiftLeft(source, length, currentIteration);
                }
                else
                {
                    ShiftRight(source, length, currentIteration);
                }
            }
        }

        private static void ShiftLeft(int[] array, int length, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                int temp = array[0];
                Array.Copy(array, 1, array, 0, length - 1);
                array[length - 1] = temp;
            }
        }

        private static void ShiftRight(int[] array, int length, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                int temp = array[length - 1];
                Array.Copy(array, 0, array, 1, length - 1);
                array[0] = temp;
            }
        }
    }
}
