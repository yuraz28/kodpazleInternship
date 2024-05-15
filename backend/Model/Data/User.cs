using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;


public class User
{ 

    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Nullable<long> ID { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }  
    public List<int>? FavouritesMaterials { get; set; }
}