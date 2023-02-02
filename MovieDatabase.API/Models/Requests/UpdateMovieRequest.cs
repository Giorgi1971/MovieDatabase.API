namespace MovieDatabase.API.Models.Requests
{
    public class UpdateMovieRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public string? Director { get; set; }
    }
}
