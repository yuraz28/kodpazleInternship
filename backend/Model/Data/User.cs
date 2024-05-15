using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{ 
    public int ID { get; set; }
    public string Login { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}