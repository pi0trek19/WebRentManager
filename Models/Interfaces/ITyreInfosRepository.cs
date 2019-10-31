using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ITyreInfosRepository
    {
        IEnumerable<TyreInfo> GetAllByCar(Guid carId);
        IEnumerable<TyreInfo> GetAll();
        TyreInfo GetTyreInfo(Guid guid);
        TyreInfo Create(TyreInfo tyreInfo);
        TyreInfo Remove(TyreInfo tyreInfo);
        TyreInfo Update(TyreInfo tyreInfo);
    }
}
