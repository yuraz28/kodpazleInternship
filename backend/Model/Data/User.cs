using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class User
{ 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? Role { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }  
    public List<int>? FavouritesMaterials { get; set; }

    public User(string role, string name, string email, string password, List<int> favouritesMaterials)
    {
        Role = role; 
        Name = name; 
        Email = email; 
        Password = password; 
        FavouritesMaterials = favouritesMaterials;
    }
}