namespace MovieWatchlist.Web.Models
{
    public class MovieResult
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Actors { get; set; }
        public string ImdbID { get; set; }
        public List<Rating> Ratings { get; set; }

    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
