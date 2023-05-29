using Microsoft.EntityFrameworkCore; //installed using dotnet add package Microsoft.EntityFrameworkCore.SqlServer
using bulky_web.Models;

namespace bulky_web.Data;

public class AppDbContext:DbContext //DbContext is a class provided by Entity Framework Core and serves as a bridge between your application and the database.
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    // this constructor is used to initialize the AppDbContext class. It takes an instance of DbContextOptions<AppDbContext> as a parameter, which represents the configuration options for the database context.
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor_Movie>().HasKey(am => new 
        {
            am.ActorId,
            am.MovieId
        });

        modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
        modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
        //what the fuck just happened here?

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Producer> Producers { get; set; }
}