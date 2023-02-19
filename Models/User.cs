using System;
using System.ComponentModel.DataAnnotations;

namespace Minitwit7.Models
{
    public class User
    {

        [Range(0, 100000, ErrorMessage = "The UserId cannot be more than 1000 numbers")]
        [Required(ErrorMessage = "You have to enter a userId")]
        // [CustomValidation(typeof(User), "UniqueId, ErrorMessage = "The userId is already taken.")]
        public int UserId { get; set; }
        
        // [CustomValidation(typeof(User), "UniqueUsername", ErrorMessage = "The username is already taken.")]
        [StringLength(10, ErrorMessage = "The username cannot be longer than 50 characters.")]
        [Required(ErrorMessage = "You have to enter a username")]

        public string Username { get; set; } = "";

         [Required(ErrorMessage = "You have to enter a valid email address")]
        
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Invalid email format.")]
       
        // [CustomValidation(typeof(User), "UniqueEmail", ErrorMessage = "The email address is already registered.")]

        public string Email { get; set; } = "";
        [Required(ErrorMessage = "You have to enter a password")]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "Invalid password format.")]

        
        public string PwHash { get; set; } = "";

        // Custom validation for unique username
       
        // public static int? get_user_id(string username)
        // {
        //     // your code to check if the username already exists in the database
        //     // return the user id or null
        // }

        // public static ValidationResult UniqueUsername(string username, ValidationContext context)
        // {
        //     if (get_user_id(username) != null)
        //     {
        //         return new ValidationResult("The username is already taken.");
        //     }
        //     return ValidationResult.Success;
        // }

        // public static ValidationResult UniqueEmail(string email, ValidationContext context)
        // {
        //     if (get_user_by_email(email) != null)
        //     {
        //         return new ValidationResult("The email address is already registered.");
        //     }
        //     return ValidationResult.Success;
        // }
        
        // private static User get_user_by_email(string email)
        // {
        //     // your code to check if the email already exists in the database
        //     // return the user or null
        // }
    }
}

