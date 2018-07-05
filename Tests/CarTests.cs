using Cars;
using Xunit;

namespace Tests
{
    public class CarTests
    {
        private readonly Car _car = new Car();

        [Fact]
        public void Should_Change_Speed_When_Accelerating()
        {
            // Arrange
            const double expected = 9.0;

            //Act
            var actual = _car.Accelerate();

            //Assert
            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void Should_Reduce_Speed_When_Deccelerating()
        {
            // Arrange
            const double expected = 0.0;
            _car.Accelerate();
            _car.Accelerate();

            // Act
            var actual = _car.Deccelerate();

            // Assert
            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void Should_Update_Position_When_Clock_Cycles()
        {
            // Arrange
            _car.Accelerate();
            var expected = new Position(9, 1);
            const int precision = 1;

            // Act			    
            var actual = _car.UpdatePosition(precision);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}