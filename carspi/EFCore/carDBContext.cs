using Microsoft.EntityFrameworkCore;  
using carspi.Model;
namespace carspi.EfCore;

public class EF_DataContext: DbContext {
    public EF_DataContext(DbContextOptions < EF_DataContext > options): base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.UseSerialColumns();
    }
    

    public DbSet<Car> Cars { get; set; } = null!;
    

    public DbSet<carspi.Model.CarModel> CarModel { get; set; } = default!;
   
}