using carspi.EfCore;

namespace carspi.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        // Method to get all cars from the database
        public List<CarModel> GetCars()
        {
            List<CarModel> response = new List<CarModel>();
            // Retrieve all the cars from the Cars table
            var dataList = _context.Cars.ToList();
            // Convert each car object from the database into a CarModel object and add it to the response list
            dataList.ForEach(row => response.Add(new CarModel()
            {
                Id = row.Id,
                Make = row.Make,
                Model = row.Model,
                Year = row.Year,
                Colour= row.Colour,
            }));
            // Return the list of CarModel objects
            return response;
        }

        // Method to get a single car by its ID
        public CarModel GetCarById(int id)
        {
            CarModel response = new CarModel();
            // Find the car with the specified ID in the Cars table
            var row = _context.Cars.Where(d => d.Id.Equals(id)).FirstOrDefault();
            // If a car with the specified ID is found, convert it into a CarModel object and return it
            return new CarModel()
            {
                Id = row.Id,
                Make = row.Make,
                Model = row.Model,
                Colour= row.Colour,
                Year = row.Year
            };
        }

        // Method to save a car to the database
        public void SaveCar(CarModel carModel)
        {
            Car dbTable = new Car();
            
            if (carModel.Id > 0)
            {
                // If the car ID is greater than 0, update an existing car
                dbTable = _context.Cars.Where(d => d.Id.Equals(carModel.Id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Make = carModel.Make;
                    dbTable.Model = carModel.Model;
                    dbTable.Year = carModel.Year;
                    dbTable.Colour = carModel.Colour;
                }
            }
            else
            {
                // If the car ID is 0 or less, add a new car to the database
                dbTable.Make = carModel.Make;
                dbTable.Model = carModel.Model;
                dbTable.Year = carModel.Year;
                dbTable.Colour = carModel.Colour;
                _context.Cars.Add(dbTable);
            }
            // Save changes to the database
            _context.SaveChanges();
        }

        // Method to delete a car from the database
        public void DeleteCar(int id)
        {
            // Find the car with the specified ID in the Cars table
            var car = _context.Cars.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (car != null)
            {
                // Remove the car from the Cars table
                _context.Cars.Remove(car);
                // Save changes to the database
                _context.SaveChanges();
            }
        }
    }
}
