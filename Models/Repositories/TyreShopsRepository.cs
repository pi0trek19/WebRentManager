using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class TyreShopsRepository : ITyreShopsRepository
    {
        private readonly AppDbContext context;

        public TyreShopsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public TyreShop Add(TyreShop tyreShop)
        {
            context.TyreShops.Add(tyreShop);
            context.SaveChanges();
            return tyreShop;
        }

        public IEnumerable<TyreShop> GetAll()
        {
            return context.TyreShops;
        }

        public TyreShop GetTyreShop(Guid guid)
        {
            return context.TyreShops.Find(guid);
        }

        public TyreShop Remove(TyreShop tyreShop)
        {
            throw new NotImplementedException();
        }

        public TyreShop Update(TyreShop tyreShopchanges)
        {
            throw new NotImplementedException();
        }
    }
}
