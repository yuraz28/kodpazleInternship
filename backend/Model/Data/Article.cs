using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Article
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public int IdAuthor { get; set; }
    public string? Name {get; set;}
    public string? Information { get; set; }
    public int? Rating { get; set; }
}