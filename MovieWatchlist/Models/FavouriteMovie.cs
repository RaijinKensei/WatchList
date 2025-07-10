namespace MovieWatchlist.Web.Models
{
    public class FavouriteMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public string ImdbID { get; set; }
    }
}
