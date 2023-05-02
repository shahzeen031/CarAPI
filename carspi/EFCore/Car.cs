using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace carspi.EfCore;
[Table("Car")]
public class Car {
  [Key, Required]
    public int Id { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Colour { get; set; }
    public int Year { get; set; }
}