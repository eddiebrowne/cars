using System;
using Cars;
using Xunit;

namespace Tests
{
    public class RoadTests
    {
        [Fact]
        public void Should_Change_Road_At_Intersection()
        {
            // Arrange
            var road = new Road();
            var expected = new Road();
            var position = new Position(Math.Floor(road.Length / 2.0), Lane.Left);
            road.AddIntersection(position, expected);

            // Act
            var actual = road.ChangeRoad(new Car(), position);
		
            // Assert		
            Assert.Equal(expected, actual);
        }
    }
}