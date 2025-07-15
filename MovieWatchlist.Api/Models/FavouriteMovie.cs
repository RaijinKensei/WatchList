
using System.ComponentModel.DataAnnotations;

public class FavoriteMovie
    {
    //public int Id { get; set; }
    [Key]
    public string ImdbID { get; set; }
    public string Title { get; set; }  
    public string Year { get; set; }  
    public string Director { get; set; } 
    public string Poster { get; set; }
        
    }
