using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface ITyreShopsRepository
    {
        TyreShop GetTyreShop(Guid guid);
        IEnumerable<TyreShop> GetAll();
        TyreShop Add(TyreShop tyreShop);
        TyreShop Remove(TyreShop tyreShop);
        TyreShop Update(TyreShop tyreShopchanges);

    }
}
