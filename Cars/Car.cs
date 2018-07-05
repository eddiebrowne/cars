using System;

namespace Cars
{
    public class Car
    {
        // defaults
        private const int DEFAULT_DEC = -18;
        private const int DEFAULT_ACC = 9; // ~ 0-60 in 10 seconds
        private const int DEFAULT_WIDTH = 5;
        private const int DEFAULT_LENGTH = 12;

        // dimensions
        public int Length { get; }
        public int Width { get; }
        public int Weight { get; }

        // position
        public Position Position { get; }
        public Road CurrentRoad { get; set; }
        public Position Destination { get; }

        // performance
        public int Acceleration { get; }
        public int Decceleration { get; }

        // conditions
        public int Speed { get; private set; }

        public Car()
        {
            Length = DEFAULT_LENGTH;
            Width = DEFAULT_WIDTH;
            Acceleration = DEFAULT_ACC;
            Decceleration = DEFAULT_DEC;
            Speed = 0;
            Position = new Position(0, Lane.Left);
        }

        public Car(
            Road road,
            Position position,
            Position destination,
            int length = DEFAULT_LENGTH,
            int width = DEFAULT_WIDTH,
            int acc = DEFAULT_ACC,
            int dec = DEFAULT_DEC,
            int speed = 0)
        {
            Length = length;
            Width = width;
            Acceleration = acc;
            Decceleration = dec;
            Speed = speed;
            CurrentRoad = road;
            Destination = destination;
            Position = position;
        }

        public int Accelerate()
        {
            Speed += Acceleration / Simulator.Precision;
            return Speed;
        }

        public int Deccelerate()
        {
            Speed += Decceleration / Simulator.Precision;
            return Speed;
        }

        public void Drive()
        {
            var distance = Speed / (double)Simulator.Precision;
            if (Position.Point + distance > CurrentRoad.Length)
                distance = CurrentRoad.Length - Position.Point;
            Position.Move(distance);

            if (Destination != null)
            {
                if (Position.Lane != Destination.Lane && Math.Abs(Position.Point - Destination.Point) < 3 * Speed)
                {
                    Position.Lane = (Position.Lane > Destination.Lane) ? Position.Lane-- : Position.Lane++;
                }
                
                if (Destination.IsIntersection && Math.Abs(Position.Point - Destination.Point) < 15 && Position.Lane == Destination.Lane)
                {
                    CurrentRoad = CurrentRoad.ChangeRoad(Destination);
                }
            }
        }
    }
}