using Microsoft.EntityFrameworkCore;
using c_sharp.Models.User;
using c_sharp.Repositories;

namespace c_sharp.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>().HasData(new User
        {
            UserId = Guid.NewGuid(),
            Email= "bamse.stark@mail.com",
            HashPassword = UserRepository.HashPassword("bamse123"),
            FirstName =  "Bamse",
            LastName = "Stark",
            CreatedAt = DateTime.Now,
        });
    }

    public DbSet<User> Users { get; set; }
}