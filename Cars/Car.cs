using System;
using System.Linq;

namespace Cars
{
    public class Car
    {
        // defaults
        private const int DEFAULT_DEC = -18;
        private const int DEFAULT_ACC = 9; // ~ 0-60 in 10 seconds
        private const int DEFAULT_WIDTH = 5;
        private const int DEFAULT_LENGTH = 12;

        public CarId CarId { get; }

        // dimensions
        public int Length { get; }
        public int Width { get; }
        public int Weight { get; }

        // position
        public Position Position { get; }
        public Road CurrentRoad { get; set; }
        public Position Destination { get; }

        // performance
        private int Buffer => 3 * Speed;
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
            CurrentRoad = new Road();
            CarId = new CarId();
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
            CarId = new CarId();
            CurrentRoad = road;
            CurrentRoad.AddCar(this);
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
            Speed = Speed < 0 ? 0 : Speed;
            return Speed;
        }

        public void Drive()
        {
            if (IsApproachingCar)
            {
                Deccelerate();
            }
            
            var distance = Speed / (double)Simulator.Precision;
            if (Position.Point + distance > CurrentRoad.Length)
            {
                distance = CurrentRoad.Length - Position.Point;
            }

            Position.Move(distance);
            
            if (Destination != null)
            {
                if (ShouldChangeLanes)
                {
                    Position.Lane = (Position.Lane > Destination.Lane) ? Position.Lane-- : Position.Lane++;
                }
                
                if (IsApproachingDestination)
                {
                    Deccelerate();
                    CurrentRoad = CurrentRoad.ChangeRoad(this, Destination);
                    CurrentRoad.AddCar(this);
                }
            }
        }

        private bool IsApproachingDestination =>
            Destination.IsIntersection && 
                   Destination.Point - Position.Point <= Buffer && 
                   Position.Lane == Destination.Lane;

        private bool ShouldChangeLanes =>
            Position.Lane != Destination.Lane && 
            Destination.Point - Position.Point <= Buffer;

        private bool IsApproachingCar => 
            CurrentRoad.Cars.Any(c => 
                c.Position.Lane == Position.Lane && 
                c.Position.Point > Position.Point && 
                (c.Position.Point - Position.Point) <= Buffer);
    }

    public class CarId
    {
        private static int _carCounter;
        public int Value { get; }

        public CarId()
        {
            Value = _carCounter++;
        }
    }
}