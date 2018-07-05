import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;


public class Simulator 
{

	/***
	 * 
	 * The simulator "drives" the program. 
	 * It has a list of roads, each with a list of cars.
	 * It updates each of the items each second/precision.  
	 * 
	 ***/
	
	// time
	private double _t;
	private int _precision;
	
	public void Precision(int precision) {
		_precision = precision;
	}

	// roads
	private List<Road> _roads;
	
	public Simulator()
	{
		_t = 0;
		_roads = new ArrayList<Road>();	
		_precision = 1;
	}
	
	public Simulator(List<Road> roads)
	{
		_t = 0;
		_roads = roads;		
	}
	
	public boolean RunSimulation(int seconds)
	{		
		double rate = 1.0/_precision;
		while(_t < seconds)
		{
			_t += (rate);
			UpdateRoads();
		}
		return true;
	}
	
	private void UpdateRoads()
	{
		//
		for(Iterator<Road> iter =_roads.iterator(); iter.hasNext(); )
		{
			Road road = iter.next();
			road.Update(_precision);
		}		
	}

	public void AddRoad(Road road) 
	{		
		_roads.add(road);		
	}
}