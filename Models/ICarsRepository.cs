﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ICarsRepository
    {
        Car GetCar(Guid id);
        Car GetCar(string registration);
        IEnumerable<Car> GetAllCars();
        Car Add(Car car);
        Car Update(Car carChanges);
        Car Delete(Guid id);
        Car Delete(string registration);

    }
}