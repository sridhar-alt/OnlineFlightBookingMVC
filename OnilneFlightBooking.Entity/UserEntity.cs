using System;

namespace OnilneFlightBooking.Entity
{
    public enum sex
    {
        male,
        female,
        others
    }
    public class UserEntity
    {
        public string name { get; set; }
        public string mobile { get; set; }
        public DateTime dob { get; set; }
        public string mail { get; set; }
        public sex sex { get; set; }
        public string userAddress { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
