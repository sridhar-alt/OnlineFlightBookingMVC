using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "DAte Requried")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Mail required")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public sex Sex { get; set; }

        public string UserAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
        public string ConfirmPassword { get; set; }

        public string Role;

        public UserEntity()
        { }

        public UserEntity(string name, string mobile, DateTime dob, string mail, sex sex, string userAddress, string password)
        {
            Name = name;
            Mobile = mobile;
            Dob = dob;
            Mail = mail;
            Sex = sex;
            UserAddress = userAddress;
            Password = password;
            Role = "user";
        }
    }
    
}
