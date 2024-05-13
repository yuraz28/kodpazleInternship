using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;



public class User : IdentityUser
    { 
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Required]
        [Display(Name = "Год рождения")]
        public int Year { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }  