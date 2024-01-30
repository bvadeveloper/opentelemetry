using Microsoft.EntityFrameworkCore;

namespace Source.One.Db;

public class CarDbContext(DbContextOptions<CarDbContext> options) : DbContext(options)
{
    public DbSet<CarEntity> Cars { get; set; } = null!;
}