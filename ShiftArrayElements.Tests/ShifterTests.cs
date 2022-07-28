using NUnit.Framework;

namespace ShiftArrayElements.Tests
{
    [TestFixture]
    public class ShifterTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            // Arrange
            int[] actualResult = (int[])source.Clone();

            // Act
            Shifter.Shift(actualResult, Array.Empty<int>());

            // Assert
            Assert.That(actualResult, Is.EqualTo(source));
        }

        [TestCase(new int[] { }, new[] { 0 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new[] { 1 }, new int[] { }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 3 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 4 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 0 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 1 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 2 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 3 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 0, 4 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 0 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 1 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 2 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 3 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1, 4 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 0 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 1 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 2 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 3 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 2, 4 }, new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new int[] { }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 0 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 1 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 2 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 3 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 0, 4 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 1 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 3 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 4 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 1 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 2 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 3 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 4 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 1 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 2 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 3 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 1 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 2 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 3 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 4, 4 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new int[] { }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 0 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 0, 0 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1 }, new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 0, 1 }, new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1, 1 }, new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 1, 1, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2 }, new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 1 }, new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }, new[] { 3, 4, 5, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 }, new[] { 4, 5, 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new int[] { }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0, 0 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0, 0, 0 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 1 }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 1, 1 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 2 }, new[] { 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 1, 2 }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 2, 2 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 9 }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0, 9 }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 10 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0, 10 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 10, 10 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 11 }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { 0, 11 }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void Shift_SourceAndIterationsAreNotNull_ReturnsArrayWithShiftedElements(int[] actualResult, int[] iterations, int[] expectedResult)
        {
            // Act
            Shifter.Shift(actualResult, iterations);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
