using Bogus;
using CS_MovieCards_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using CS_MovieCards_API;

namespace CS_MovieCards_API.Data
{
    public static class SeedData
    {
        public static async Task SeedDataAsync(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var servicesProvider = scope.ServiceProvider;
                var db = servicesProvider.GetRequiredService<DBContext>();

                await db.Database.MigrateAsync();

                if (await db.Movie.AnyAsync()) return;

                try
                {
                    var movies = GenerateMovies(4);
                    await db.AddRangeAsync(movies);
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        private static IEnumerable<Movie> GenerateMovies(int nrOfMovies)
        {
        var faker = new Faker<Movie>("sv")
            .RuleFor(c => c.Title, f => string.Join(" ", f.Lorem.Words(f.Random.Int(1, 3))))
            .RuleFor(c => c.Rating, f => f.Random.Int(1, 5))
            .RuleFor(c => c.ReleaseDate, f => f.Date.Past(80))
            .RuleFor(c => c.Description, f => f.Lorem.Paragraph());
            
        return faker.Generate(nrOfMovies);
        }

        private static ICollection<Director> GenerateDirectors(int nrOfDirectors)
        {
        var faker = new Faker<Director>("sv")
            .RuleFor(d => d.Name, e => e.Person.FullName)
            .RuleFor(d => d.DateOfBirth, e => e.Date.Past(60));
            
            return faker.Generate(nrOfDirectors);
        }
    }
}
