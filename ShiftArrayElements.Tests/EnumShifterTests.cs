using NUnit.Framework;

namespace ShiftArrayElements.Tests
{
    [TestFixture]
    public class EnumShifterTests
    {
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] array)
        {
            // Arrange
            int[] copy = (int[])array.Clone();

            // Act
            EnumShifter.Shift(copy, Array.Empty<Direction>());

            // Assert
            Assert.That(copy, Is.EqualTo(array));
        }

        [TestCase(new object[] { -1 })]
        [TestCase(new object[] { Direction.Left, 2 })]
        [TestCase(new object[] { Direction.Left, Direction.Right, 3 })]
        public void Shift_DirectionsContainsWrongValues_ThrowsInvalidOperationException(object[] objects)
        {
            // Arrange
            int[] array = new[] { 1, 2, 3, 4, 5 };
            var directions = objects.Cast<Direction>().ToArray();

            // Act + Assert
            Assert.Throws<InvalidOperationException>(() => EnumShifter.Shift(array, directions));
        }

        [TestCase(new[] { 1 }, new Direction[] { }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left, Direction.Left }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right, Direction.Right }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left, Direction.Right }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right, Direction.Left }, new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new Direction[] { }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Right }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Left }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left, Direction.Left }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right, Direction.Right }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Right, Direction.Left }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Left, Direction.Right }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left, Direction.Right }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right, Direction.Left }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new Direction[] { }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left }, new[] { 2, 3, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left }, new[] { 3, 1, 2 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right }, new[] { 3, 1, 2 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right }, new[] { 2, 3, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Right }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Left }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Right, Direction.Left, Direction.Right }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Left, Direction.Right, Direction.Left }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left, Direction.Right, Direction.Right }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right, Direction.Left, Direction.Left }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left }, new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right }, new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left }, new[] { 3, 4, 5, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right }, new[] { 4, 5, 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new Direction[] { }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Right }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Left }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Left }, new[] { 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Right }, new[] { 9, 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Left, Direction.Left }, new[] { 4, 5, 6, 7, 8, 9, 0, 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Right, Direction.Right }, new[] { 8, 9, 0, 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Right, Direction.Left }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Left, Direction.Right }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, new[] { Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        public void Shift_SourceAndDirectionsAreNotNull_ReturnsArrayWithShiftedElements(int[] source, Direction[] directions, int[] expectedResult)
        {
            // Act
            EnumShifter.Shift(source, directions);

            // Assert
            Assert.That(source, Is.EqualTo(expectedResult));
        }
    }
}
