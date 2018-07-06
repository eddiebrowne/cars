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
            Assert.Equal(expected, actual);
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
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Update_Position_When_Clock_Cycles()
        {
            // Arrange
            var car = new Car();
            car.Accelerate();
            var expected = new Position(9, Lane.Left);

            // Act
            car.Drive();
            var actual = car.Position;

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Should_Deccelerate_When_Approaching_Car()
        {
            // Arrange
            var road = new Road();
            var target = new Car(road, new Position(18, Lane.Left), new Position(road.Length));

            var car = new Car(road, new Position(11, Lane.Left), new Position(road.Length));
            car.Accelerate();
            
            const int expected = 0;

            // Act
            car.Drive();
            
            var actual = car.Speed;

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Should_Change_Road_At_Intersection()
        {
            // Arrange
            var road = new Road();
            var intersection = new Road();
            var destination = new Position(18, Lane.Left, isIntersection: true);
            road.AddIntersection(destination, intersection);

            var car = new Car(road, new Position(11, Lane.Left), destination);
            car.Accelerate();
            
            var expected = intersection.RoadId.Value;

            // Act
            car.Drive();
            
            var actual = car.CurrentRoad.RoadId.Value;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}