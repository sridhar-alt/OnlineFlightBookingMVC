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
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [Key]
        [Required(ErrorMessage = "Phone number required")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Enter the numeric digits.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage ="Date of Birth required")]
        [DataType(DataType.Date, ErrorMessage = "(dd/mm/yyyy) is Required Format")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public sex Sex { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string UserAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }

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
        }
        public UserEntity(string mobile,string password)
        {
            Mobile = mobile;
            Password = password;
        }
    }
    
}
