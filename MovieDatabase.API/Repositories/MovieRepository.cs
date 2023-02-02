using Microsoft.IdentityModel.Tokens;
using MovieDatabase.API.Db;
using MovieDatabase.API.Db.Entities;
using MovieDatabase.API.Models.Requests;

namespace MovieDatabase.API.Repositories
{
    public interface IMovieRepository
    {
        Task AddMovieAsync(AddMovieRequest request);
        Task<MovieEntity> UpdateMovieAsync(UpdateMovieRequest request);
        void DeleteMovie(DeleteMovieRequest request);
        MovieEntity GetById(int id);
        MovieEntity SearchMovie(SearchMovieRequest request);
        Task SaveChangesAsync();
    }
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddMovieAsync(AddMovieRequest request)
        {
            var entity = new MovieEntity();

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Year = request.Year;
            entity.Director = request.Director;
            entity.MovieStatus = Status.Active;
            entity.CreatedAt = DateTime.UtcNow;

            await _db.Movies.AddAsync(entity);
        }

        public void DeleteMovie(DeleteMovieRequest request)
        {
            var movie = GetById(request.Id);
            if (movie == null) return;

            movie.MovieStatus = Status.Deleted;
        }

        public MovieEntity GetById(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<MovieEntity> UpdateMovieAsync(UpdateMovieRequest request)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == request.Id);

            if (request.Name != null) movie.Name = request.Name;
            if (request.Description != null) movie.Description = request.Description;
            if (request.Year != null) movie.Year = request.Year;
            if (request.Director != null) movie.Director = request.Director;

            _db.Movies.Update(movie);
            return movie;
        }

        public MovieEntity SearchMovie(SearchMovieRequest request)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Director == request.Director || 
            x.Name == request.Name ||
            x.Year == request.Year);

            if (movie == null) return null;

            return movie;
        }
    }
}
