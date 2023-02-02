namespace MovieDatabase.API.Models.Requests
{
    public class SearchMovieRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int Year { get; set; }
    }
}
