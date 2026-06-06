namespace AppPeliculas.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;


        // Relación: Una película puede estar en los favoritos de muchos usuarios
        public ICollection<FavoriteMovie> FavoriteMovies { get; set; } = new List<FavoriteMovie>();
        public ICollection<MovieRating> MovieRatings { get; set; } = new List<MovieRating>();

    }
}
