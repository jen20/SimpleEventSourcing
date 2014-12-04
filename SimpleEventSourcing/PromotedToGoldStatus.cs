using System;

namespace SimpleEventSourcing
{
    public class PromotedToGoldStatus : IEvent
    {
        public readonly DateTime ExpiryDate;
	
        public PromotedToGoldStatus(DateTime expiryDate)
        {
            ExpiryDate = expiryDate;
        }

        public override string ToString()
        {
            return string.Format("[PromotedToGoldStatus] ExpiryDate: {0}", ExpiryDate);
        }
    }
}