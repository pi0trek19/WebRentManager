using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarDamagesRepository : ICarDamagesRepository
    {
        private readonly AppDbContext context;

        public CarDamagesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CarDamage Add(CarDamage damage)
        {
            context.CarDamages.Add(damage);
            context.SaveChanges();
            return damage;
        }

        public CarDamage GetCarDamage(Guid id)
        {
            return context.CarDamages.Find(id);
        }

        public IEnumerable<CarDamage> GetCarDamages(Guid id)
        {
            return context.CarDamages.Where(damage => damage.CarId == id);
        }

        public CarDamage Remove(CarDamage damage)
        {
            throw new NotImplementedException();
        }

        public CarDamage Update(CarDamage damageChanges)
        {
            var damage = context.CarDamages.Attach(damageChanges);
            damage.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return damageChanges;
        }
    }
}
