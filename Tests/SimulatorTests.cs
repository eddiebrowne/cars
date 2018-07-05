using Cars;
using Xunit;

namespace Tests
{
	public class SimulatorTests {

		private readonly Simulator _simulation = new Simulator();

		[Fact]
		public void Should_Simulate_A_Car_Driving_Down_A_Simple_Road() 
		{
			// Arrange
			var road = new Road();
			_simulation.AddRoad(road);

			var car = new Car(new Position(0, 0, road.RoadId), speed: 88);
			
			const int runningTime = 60; // seconds

			var expected = new Position(5280, 0, road.RoadId);
		
			// Act
			_simulation.RunSimulation(runningTime);
		
			var actual = car.Position;
		
			// Assert
			Assert.Equal(expected, actual);
		}
	
		[Fact]
		public void Should_Simulate_A_Car_Driving_Down_A_Simple_Road_With_High_Precision() 
		{
			// Arrange
			var road = new Road();
			_simulation.AddRoad(road);

			var car = new Car(new Position(0, 0, road.RoadId), speed: 88);
			
			const int runningTime = 60; // seconds
			const int precision = 100;
		
			var expected = new Position(5280, 0, road.RoadId);
		
			// Act
			_simulation.RunSimulation(runningTime);
		
			var actual = car.Position;
		
			// Assert
			Assert.Equal(expected, actual);
		}
	}
}