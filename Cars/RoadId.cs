namespace Cars
{
    public class RoadId
    {
        private static int _idCounter = 0;
        public int Value { get; }

        public RoadId()
        {
            Value = _idCounter++;
        }

    }
}