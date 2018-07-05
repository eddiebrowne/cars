using System;

namespace Cars
{
    public class Position 
    {
        public double Point { get; private set; }
        public int Lane { get; set; }

        public Position(double point, int lane)
        {
            Point = point;
            Lane = lane;
        }

        public void Move(double distance)
        {
            Point = Point + distance;
        }
        
        public override bool Equals(object obj) {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Position other = (Position) obj;
            var tolerance = .05;
            if (Math.Abs(Point - other.Point) > tolerance)
                return false;
            if (Math.Abs(Lane - other.Lane) > tolerance)
                return false;
            return true;
        }
    }
}