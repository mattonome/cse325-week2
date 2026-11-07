using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>());

        if (context.Movie.Any())
            return;

        context.Movie.AddRange(
            new Movie { Title = "The Matrix", ReleaseDate = DateTime.Parse("1999-03-31"), Genre = "Sci-Fi", Price = 9.99M },
            new Movie { Title = "Interstellar", ReleaseDate = DateTime.Parse("2014-11-07"), Genre = "Sci-Fi", Price = 12.99M },
            new Movie { Title = "Inception", ReleaseDate = DateTime.Parse("2010-07-16"), Genre = "Sci-Fi", Price = 11.99M }
        );
        context.SaveChanges();
    }
}