import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;


public class RoadTest {

	Road _road;
	
	@Before
	public void setUp() throws Exception 
	{
		_road = new Road();				
	}

	@Test
	public void Should_Update_Cars_When_Clock_Cycles()
	{
		// Arrange
		Car car = new Car();
		car.accelerate(); // car is now going 9 feet per second
		
		_road.AddCar(car);
		Position expected = new Position(car.Position().X() + car.Speed(), car.Position().Y(), _road.RoadId());				
		
		int precision = 1;
		
		// Act
		_road.Update(precision);
		
		Position actual = _road.Cars().get(0).Position();
		
		// Assert		
		assertEquals(expected, actual);
	}

}
