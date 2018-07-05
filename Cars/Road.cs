using System.Collections.Generic;

namespace Cars
{
    public class Road
    {
        private const int DEFAULT_LENGTH = 5280;
        private const int DEFAULT_WIDTH = 16; // 8 feet per lane
        private const int DEFAULT_NUM_LANES = 2;
        private const int DEFAULT_LANE_WIDTH = 8;
        private const int DEFAULT_SPEED_LIMIT = 88; // feet per second

        // id
        public RoadId RoadId { get; }

        // dimensions
        public int Length { get; }
        public int Width { get; }
        public int NumberOfLanes { get; }
        public int LaneWidth { get; }

        // properties
        public int SpeedLimit { get; }
        
        private readonly Dictionary<double, Road> _intersections;
        
        public Road()
        {
            Length = DEFAULT_LENGTH;
            Width = DEFAULT_WIDTH;
            NumberOfLanes = DEFAULT_NUM_LANES;
            LaneWidth = DEFAULT_LANE_WIDTH;
            SpeedLimit = DEFAULT_SPEED_LIMIT;
            RoadId = new RoadId();
            _intersections = new Dictionary<double, Road>();
        }

        public void AddIntersection(Position position, Road road)
        {
            _intersections.Add(position.Point, road);
        }

        public Road ChangeRoad(Position position)
        {
            return _intersections[position.Point];
        }
    }
}