public class Material
{
    public int ID { get; set; }
    public int IdAuthor { get; set; }
    public string? Name {get; set;}
    public string? Information { get; set; }
    public string? UrlImage { get; set; }
    public int? TimeToLearn { get; set; }

    // public Material(int id, int idAuthor, string name, string information, string urlImage, List<int> rating)
    // {
    //     ID = id; 
    //     IdAuthor = idAuthor;
    //     Name = name; 
    //     Information = information; 
    //     UrlImage = urlImage;
    //     Rating = rating;
    //     Rate = Convert.ToInt32(Rating.Sum() / Rating.Count());
    //     TimeToLearn = Convert.ToInt32(Information.Split().Count());
    // }

    public Material() { }
}