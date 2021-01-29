using Epsic_Cave_A_Vin_Ethan.Enums;
using System.ComponentModel.DataAnnotations;

namespace Epsic_Cave_A_Vin_Ethan.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(25)]
        public string Lastname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [UserAgeValidator]
        public int Age { get; set; }
        [Required]
        public TypeUser Type { get; set; } = TypeUser.User;
        [Required]
        public string Password { get; set; }
    }

    public class UserDetailViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public TypeUser Type { get; set; } = TypeUser.User;
        public string Password { get; set; }
    }

    public class CreateUserDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public TypeUser Type { get; set; } = TypeUser.User;
        public string Password { get; set; }
    }

    public class UserSummaryViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}