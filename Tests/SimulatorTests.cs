using System.Collections.Generic;
using Cars;
using Xunit;

namespace Tests
{
	public class SimulatorTests {
		[Fact]
		public void Should_Simulate_A_Car_Driving_Down_A_Simple_Road() 
		{
			// Arrange
			var road = new Road();
			var initialPosition = new Position(0);
			var expected = new Position(road.Length);
			var car = new Car(road, initialPosition, expected, speed: 88);
			var simulation = new Simulator();
			simulation.AddCar(car);
			
			const int runningTime = 60; // seconds

			// Act
			simulation.RunSimulation(runningTime);
		
			var actual = car.Position;
		
			// Assert
			Assert.Equal(expected, actual);
		}
	
		[Fact]
		public void Should_Simulate_A_Car_Driving_Down_A_Simple_Road_With_High_Precision() 
		{
			// Arrange
			var road = new Road();
			var initialPosition = new Position(0);
			var expected = new Position(road.Length);
			var car = new Car(road, initialPosition, expected, speed: 88);
			var simulation = new Simulator(new List<Car> {car}, precision: 20);
			
			const int runningTime = 60; // seconds
		
			// Act
			simulation.RunSimulation(runningTime);
		
			var actual = car.Position;
		
			// Assert
			Assert.Equal(expected, actual);
		}
	}
}