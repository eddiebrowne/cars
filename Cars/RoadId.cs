namespace Cars
{
    public class RoadId
    {
        private static int _idCounter = 0;
        private int Id { get; }

        public RoadId()
        {
            Id = _idCounter++;
        }

    }
}