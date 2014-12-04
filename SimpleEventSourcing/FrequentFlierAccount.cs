using System;

namespace SimpleEventSourcing
{
    public class FrequentFlierAccount : AggregateRoot
    {
        private int _miles;
        private int _tierPoints;
        private MembershipStatus _status;
        private DateTime _accountExpiryDate;

        public override string ToString()
        {
            return string.Format("Account:\n\tMiles: {0}\n\tTier Points: {1}\n\tStatus: {2}\n\tExpiry Date: {3}\n",
                _miles, _tierPoints, _status, _accountExpiryDate.ToString("d"));
        }

        public void RecordFlightTaken(int miles, int tierPoints)
        {
            ApplyChange(new FlightTaken(miles, tierPoints));

            if (_tierPoints >= 40)
                PromoteToGoldStatus();
        }

        private void PromoteToGoldStatus()
        {
            ApplyChange(new PromotedToGoldStatus(DateTime.UtcNow.AddYears(1)));
        }

        private void Apply(NewAccountRegistered e)
        {
            _miles = e.OpeningMiles;
            _tierPoints = 0;
	    _status = MembershipStatus.Red;
            _accountExpiryDate = e.ExpiryDate;
        }

        private void Apply(FlightTaken e)
        {
            _miles += e.Miles;
            _tierPoints += e.TierPoints;
        }

        private void Apply(PromotedToGoldStatus e)
        {
            _status = MembershipStatus.Gold;
            _accountExpiryDate = e.ExpiryDate;
        }

        public FrequentFlierAccount()
        {
	    AddHandler<NewAccountRegistered>(Apply);
            AddHandler<FlightTaken>(Apply);
            AddHandler<PromotedToGoldStatus>(Apply);
        }
    }
}