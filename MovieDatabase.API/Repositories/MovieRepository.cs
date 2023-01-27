
using MovieDatabase.API.Db;
using MovieDatabase.API.Db.Entities;

namespace MovieDatabase.API.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(MovieEntity entity);
    }
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }
        public Task AddAsync(MovieEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
