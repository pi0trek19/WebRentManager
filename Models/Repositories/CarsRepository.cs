using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarsRepository : ICarsRepository
    {
        private readonly AppDbContext context;
        public CarsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Car Add(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
            return car;
        }

        public Car Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Car> GetAllCars()
        {
            return context.Cars;
        }
        public Car GetCar(Guid guid)
        {
            return context.Cars.Find(guid);
        }
        public Car Update(Car carChanges)
        {
            throw new NotImplementedException();
        }
    }
}
