using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnilneFlightBooking.Entity
{
    public class FlightEntity
    {
        [Key]
        public int Flight_Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid Name")]
        public string FlightName { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime Duration { get; set; }
        public int TotalSeat { get; set; }
        public FlightEntity(int flight_id,string flightName, string fromLocation, string toLocation, DateTime arrivalTime, DateTime duration, int totalSeat)
        {
            Flight_Id = flight_id;
            FlightName = flightName;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            ArrivalTime = arrivalTime;
            Duration = duration;
            TotalSeat = totalSeat;
        }
        public FlightEntity()
        {

        }
    }
}
