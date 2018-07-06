using System;

namespace Cars
{
    public class Position 
    {
        public double Point { get; private set; }
        public Lane Lane { get; set; }
        public bool IsIntersection { get; private set; }

        public Position(double point, Lane lane = Lane.Left, bool isIntersection = false)
        {
            Point = point;
            Lane = lane;
            IsIntersection = isIntersection;
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