using System;

namespace SimpleEventSourcing
{
    public class NewAccountRegistered : IEvent
    {
        public readonly int OpeningMiles;
        public readonly DateTime ExpiryDate;

        public NewAccountRegistered(int openingMiles, DateTime expiryDate)
        {
            OpeningMiles = openingMiles;
            ExpiryDate = expiryDate;
        }

        public override string ToString()
        {
            return string.Format("[NewAccountRegistered] OpeningMiles: {0}, ExpiryDate: {1}", OpeningMiles, ExpiryDate);
        }
    }
}