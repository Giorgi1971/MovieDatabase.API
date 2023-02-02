namespace MovieDatabase.API.Db.Entities
{
    public enum Status
    {
        Active,
        Deleted
    }
    public class MovieEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public string? Director { get; set; }
        public Status MovieStatus { get; set; }
        public DateTime CreatedAt { get; set; } 
    }

}
