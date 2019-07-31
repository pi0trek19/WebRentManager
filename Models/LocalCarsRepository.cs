using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class LocalCarsRepository : ICarsRepository
    {

        private List<Car> _carsList;
        public LocalCarsRepository()
        {
            Guid tmp = new Guid();
            Guid tmp1 = new Guid();
            Guid tmp2 = new Guid();
            _carsList = new List<Car>()
            {
                
                new Car(){Id=tmp,Make="VW",Model="Golf",RegistrationNumber="WI323HY",ProductionYear=2019},
                new Car(){Id=tmp1,Make="Opel",Model="Astra",RegistrationNumber="WI902GW",ProductionYear=2017},
                new Car(){Id=tmp2,Make="Kia",Model="Optima",RegistrationNumber="WI789JJ",ProductionYear=2019}
            };
        }
        public Car Add(Car car)
        {
            throw new NotImplementedException();
        }

        public Car Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Car Delete(string registration)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carsList;
        }

        public Car GetCar(Guid id)
        {
            return _carsList.FirstOrDefault(c => c.Id == id);
        }

        public Car GetCar(string registration)
        {
            return _carsList.FirstOrDefault(c => c.RegistrationNumber == registration);
        }

        public Car Update(Car carChanges)
        {
            throw new NotImplementedException();
        }
    }
}
