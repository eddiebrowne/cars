import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;


public class SimulatorTest {

	private Simulator _simulation;


	@Before
	public void setUp() throws Exception 
	{
		_simulation = new Simulator();
	}
	

	@Test
	public void Should_Simulate_A_Car_Driving_Down_A_Simple_Road() 
	{
		// Arrange
		Car car = new Car();
		car.Speed(88);
		Road road = new Road();
		road.AddCar(car);
		int runningTime = 60; // seconds
				
		Position expected = new Position(5280, 0, 0); // (x, y, roadId)
		_simulation.AddRoad(road);
		
		// Act
		_simulation.RunSimulation(runningTime);
		
		Position actual = car.Position();
		
		// Assert
		assertEquals(expected, actual);
	}
	
	@Test
	public void Should_Simulate_A_Car_Driving_Down_A_Simple_Road_With_High_Precision() 
	{
		// Arrange
		Car car = new Car();
		car.Speed(88);
		Road road = new Road();
		road.AddCar(car);
		int runningTime = 60; // seconds
		int precision = 100;
		
		Position expected = new Position(5280, 0, 0); // (x, y, roadId)
		_simulation.AddRoad(road);
		_simulation.Precision(precision);
		
		// Act
		_simulation.RunSimulation(runningTime);
		
		Position actual = car.Position();
		
		// Assert
		assertEquals(expected, actual);
	}
	
	

}
