using System.Collections.Generic;

namespace Cars
{
    public class Simulator
    {
        /***
     * 
     * The simulator "drives" the program. 
     * 
     ***/

        // time
        private double _t;

        public static int Precision { get; private set; } = 1;

        // roads
        private List<Car> _cars;

        public Simulator()
        {
            _t = 0;
            _cars = new List<Car>();
            Precision = 1;
        }

        public Simulator(List<Car> cars, int precision)
        {
            _t = 0;
            _cars = cars;
            Precision = precision;
        }

        public bool RunSimulation(int seconds)
        {
            var rate = 1.0 / Precision;
            while (_t < seconds)
            {
                _t += rate;
                UpdateCars();
            }

            return true;
        }

        private void UpdateCars()
        {
            foreach (var car in _cars)
            {
                car.Drive();
            }
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }
    }
}