import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class CarTest {
	
	Car _car;
	
	@Before
	public void setUp()
	{
		_car = new Car();
	}
	
	@Test
	public void Should_Change_Speed_When_Accelerating() {
	
		// Arrange		
		double expected = 9.0;
		
		//Act
		double actual = _car.accelerate();
		
		//Assert
		assertEquals(expected, actual, .05);
	}

	@Test
	public void Should_Reduce_Speed_When_Deccelerating() {
		
		// Arrange
		double expected = 0.0;		
		_car.accelerate();
		_car.accelerate();
		
		// Act
		double actual = _car.deccelerate();
		
		// Assert
		assertEquals(expected, actual, .05);
	}
	
	@Test
	public void Should_Update_Position_When_Clock_Cycles()
	{
		// Arrange
		_car.accelerate();
		Position expected = new Position(9,0,0);
		int precision = 1;
				
		// Act			
		Position actual = _car.UpdatePosition(precision);
		
		// Assert
		assertEquals(expected, actual);		
	}

	
}
