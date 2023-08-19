namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static void Shift(int[] source, Direction[] directions)
        {
            if (source.Length == 0 || directions.Length == 0)
            {
                return;
            }

            int length = source.Length;

            for (int i = 0; i < directions.Length; i++)
            {
                Direction currentDirection = directions[i];

                switch (currentDirection)
                {
                    case Direction.Left:
                        ShiftLeft(source, length);
                        break;

                    case Direction.Right:
                        ShiftRight(source, length);
                        break;

                    default:
                        throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
                }
            }
        }

        private static void ShiftLeft(int[] array, int length)
        {
            int temp = array[0];

            for (int i = 0; i < length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[length - 1] = temp;
        }

        private static void ShiftRight(int[] array, int length)
        {
            int temp = array[length - 1];

            for (int i = length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = temp;
        }
    }
}
