using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnilneFlightBooking.Entity
{
    public class FlightEntity
    {
        public string FlightName { get; set; }
        public string FlightNumber { get; set; }
        public FlightEntity(string flightName, string flightNumber)
        {
            FlightName = flightName;
            FlightNumber = flightNumber;
        }
    }
}
