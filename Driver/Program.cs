using System;
using System.Collections.Generic;
using SimpleEventSourcing;

namespace Driver
{
    class Program
    {
        static void Main()
        {
            //Construction
            var account = new FrequentFlierAccount();

            //Previous events
            var history = new List<IEvent>
            {
                new NewAccountRegistered(0, new DateTime(2014, 07, 04)),
                    new FlightTaken(1000, 3),
                    new FlightTaken(5000, 10),
                    new FlightTaken(10000, 15),
                    new FlightTaken(4000, 5),
                    new FlightTaken(1000, 3)
            };

            Console.WriteLine("History:");
            foreach (var e in history)
                Console.WriteLine("\t{0}", e);

            //Load from history
            account.LoadFromEventStream(history);

            Console.WriteLine();
            Console.WriteLine(account);

            //Perform behaviour
            account.RecordFlightTaken(5000, 10);

            Console.WriteLine();
            Console.WriteLine(account);

            Console.WriteLine();
            Console.WriteLine("Uncommitted Changes:");
            foreach (var e in account.GetUncommittedChanges())
                Console.WriteLine("\t{0}", e);
        }
    }
}
