using OnilneFlightBooking.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFlightbooking.DIL
{
    public class UserContext: DbContext
    {
        public UserContext():base("DBConnection")
        {

        }
        public DbSet<UserEntity> UserEntity { get; set; }
    }
}
