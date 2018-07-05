
public class Position 
{
	private double _x;
	private double _y;
	private int _roadId;
	
	public Position(double x, double y, int roadId)
	{
		_x = x;
		_y = y;
		_roadId = roadId;
	}

	public void X(double x) 
	{		
		_x = x;		
	}
	
	public void Y(double y) 
	{
		_y = y;		
	}
	
	public double X() {
		return _x;
	}

	public double Y() {
		return _y;
	}

	public int RoadId() {
		return _roadId;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + _roadId;
		long temp;
		temp = Double.doubleToLongBits(_x);
		result = prime * result + (int) (temp ^ (temp >>> 32));
		temp = Double.doubleToLongBits(_y);
		result = prime * result + (int) (temp ^ (temp >>> 32));
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Position other = (Position) obj;
		if (_roadId != other._roadId)
			return false;
		if (Double.doubleToLongBits(_x) != Double.doubleToLongBits(other._x))
			return false;
		if (Double.doubleToLongBits(_y) != Double.doubleToLongBits(other._y))
			return false;
		return true;
	}

}