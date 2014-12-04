namespace SimpleEventSourcing
{
    public class FlightTaken : IEvent
    {
        public readonly int Miles;
        public readonly int TierPoints;

        public FlightTaken(int miles, int tierPoints)
        {
            Miles = miles;
            TierPoints = tierPoints;
        }

        public override string ToString()
        {
            return string.Format("[FlightTaken] Miles: {0}, TierPoints: {1}", Miles, TierPoints);
        }
    }
}