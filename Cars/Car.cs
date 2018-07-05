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
        public double Speed { get; private set; }
        public int Precision { get; }

        public Car()
        {
            Length = DEFAULT_LENGTH;
            Width = DEFAULT_WIDTH;
            Acceleration = DEFAULT_ACC;
            Decceleration = DEFAULT_DEC;
            Speed = 0;
            Precision = 1;
        }

        public Car(
            Road road,
            Position position,
            Position destination,
            int precision = 1,
            int length = DEFAULT_LENGTH,
            int width = DEFAULT_WIDTH,
            int acc = DEFAULT_ACC,
            int dec = DEFAULT_DEC,
            double speed = 0)
        {
            Length = length;
            Width = width;
            Acceleration = acc;
            Decceleration = dec;
            Speed = speed;
            CurrentRoad = road;
            Destination = destination;
            Precision = precision;
            Position = position;
        }

        public double Accelerate()
        {
            Speed += Acceleration / Precision;
            return Speed;
        }

        public double Deccelerate()
        {
            Speed += Decceleration / Precision;
            return Speed;
        }

        public void Drive()
        {
            Position.Move(Speed / Precision);

            if (Position.Lane != Destination.Lane && Math.Abs(Position.Point - Destination.Point) < 3*Speed)
            {
                Position.Lane = (Position.Lane > Destination.Lane) ? Position.Lane-- : Position.Lane++;
            }

            if (Math.Abs(Position.Point - Destination.Point) < 15 && Position.Lane == Destination.Lane)
            {
                CurrentRoad = CurrentRoad.ChangeRoad(Destination);
            }
        }
    }
}