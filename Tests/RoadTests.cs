using System;
using Cars;
using Xunit;

namespace Tests
{
    public class RoadTests
    {
        private readonly Road _road = new Road();
        
        [Fact]
        public void Should_Update_Cars_When_Clock_Cycles()
        {
            // Arrange
            var car = new Car();
            car.Accelerate(); // car is now going 9 feet per second
		
            _road.AddCar(car);
            var expected = new Position(car.Position.Point + car.Speed, car.Position.Lane, _road.RoadId);				
		
            const int precision = 1;
		
            // Act
            _road.Update(precision);

            var actual = _road.Cars()[0].Position;
		
            // Assert		
            Assert.Equal(expected, actual);
        }

    }
}