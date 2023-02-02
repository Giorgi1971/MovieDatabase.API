using MovieDatabase.API.Db.Entities;

namespace MovieDatabase.API.Models.Requests
{
    public class DeleteMovieRequest
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
