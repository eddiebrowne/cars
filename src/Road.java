import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;


public class Road 
{
	private static final int DEFAULT_LENGTH = 5280;
	private static final int DEFAULT_WIDTH = 16; // 8 feet per lane
	private static final int DEFAULT_NUM_LANES = 2;
	private static final int DEFAULT_LANE_WIDTH = 8;
	private static final int DEFAULT_SPEED_LIMIT = 88; // feet per second

	// id
	private static int _idCounter = 0;
	private int _roadId;
		
	// dimensions
	private int length; // in feet
	private int width; // in feet
	private int numberOfLanes; // in feet
	private int laneWidth; // in feet
	
	// properties
	private int speedLimit;	// in feet per second

	// cars
	private List<Car> _cars;
	
	public Road()
	{
		length = DEFAULT_LENGTH;
		width = DEFAULT_WIDTH;
		numberOfLanes = DEFAULT_NUM_LANES;
		laneWidth = DEFAULT_LANE_WIDTH;
		speedLimit = DEFAULT_SPEED_LIMIT;
		_cars = new ArrayList<Car>();
		_roadId = _idCounter++;
	}
	
	public void AddCar(Car car)
	{
		_cars.add(car);
	}
	
	public int Length() {
		return length;
	}

	public int Width() {
		return width;
	}

	public int NumberOfLanes() {
		return numberOfLanes;
	}

	public int LaneWidth() {
		return laneWidth;
	}

	public int SpeedLimit() {
		return speedLimit;
	}

	public List<Car> Cars() {
		return _cars;
	}

	public void Update(int precision) 
	{
		// updates the state of each vehicle
		
		for(Iterator<Car> iter = _cars.iterator(); iter.hasNext();)
		{
			Car car = iter.next(); 
			car.UpdatePosition(precision);
		}
	}
	
	public int RoadId() {
		return _roadId;
	}
}
