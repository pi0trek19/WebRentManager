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
        public Car GetCar(Guid id)
        {
            return context.Cars.Find(id);
        }

        public IEnumerable<Car> GetFreeCars()
        {
            return context.Cars.Where(car => car.IsAvailable == true);
        }

        public Car Update(Car carChanges)
        {
            var car = context.Cars.Attach(carChanges);
            car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return carChanges;
        }

    }
}
