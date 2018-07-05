
public class Car 
{
	// defaults
	private static final int DEFAULT_DEC = -18;
	private static final int DEFAULT_ACC = 9; // ~ 0-60 in 10 seconds
	private static final int DEFAULT_WIDTH = 5;
	private static final int DEFAULT_LENGTH = 12;
	
	// dimensions
	private int length;	// in feet
	private int width;	// in feet
	private int weight;

	// position
	private Position _position;
	
	// performance
	private int acceleration; // in feet per second per second
	private int decceleration; // in feet per second per second
	
	// conditions
	private double speed; // feet per second
	private int _precision;
		
	public Car()
	{
		length = DEFAULT_LENGTH;
		width = DEFAULT_WIDTH;
		acceleration = DEFAULT_ACC;
		decceleration = DEFAULT_DEC;
		speed = 0;
		_position = new Position(0,0,0);
		_precision = 1;
	}
	
	public Car(int length, int width, int acc, int dec, Position position, int precision)
	{
		this.length = length;
		this.width = width;
		acceleration = acc;
		decceleration = dec;
		_position = position;
		_precision = precision;
	}
	
	public double accelerate()
	{
		speed+=acceleration/_precision;
		return speed;
	}
	
	public double deccelerate()
	{
		speed+=decceleration/_precision;
		return speed;
	}

	public int Length() {
		return length;
	}
	
	public int Width() {
		return width;
	}
	
	public int Weight() {
		return weight;
	}
	
	public double Speed() {
		return speed;
	}
	
	public void Speed(int speed) {
		this.speed = speed;
	}

	public Position UpdatePosition(int precision)
	{
		_position.X(_position.X() + (double) (speed/precision));
		return _position;
	}
	
	public Position Position() {
		return _position;
	}

	public void Position(double x, double y)
	{
		Position(new Position(x, y, _position.RoadId()));
	}
	
	public void Position(Position position) {
		_position = position;
	}
}
