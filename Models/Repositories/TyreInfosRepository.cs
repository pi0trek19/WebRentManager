using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class TyreInfosRepository : ITyreInfosRepository
    {
        private readonly AppDbContext context;

        public TyreInfosRepository(AppDbContext context)
        {
            this.context = context;
        }

        public TyreInfo Create(TyreInfo tyreInfo)
        {
            context.TyreInfos.Add(tyreInfo);
            context.SaveChanges();
            return tyreInfo;
        }

        public TyreInfo Update(TyreInfo tyreInfoChanges)
        {
            var tyreInfo = context.TyreInfos.Attach(tyreInfoChanges);
            tyreInfo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return tyreInfoChanges;
        }

        public IEnumerable<TyreInfo> GetAll()
        {
            return context.TyreInfos;
        }

        public IEnumerable<TyreInfo> GetAllByCar(Guid carId)
        {
            return context.TyreInfos.AsQueryable().Where(tyreinfo => tyreinfo.CarId == carId).ToList();
        }

        public TyreInfo GetTyreInfo(Guid guid)
        {
            return context.TyreInfos.Find(guid);
        }

        public TyreInfo Remove(TyreInfo tyreInfo)
        {
            context.TyreInfos.Remove(tyreInfo);
            context.SaveChanges();
            return tyreInfo;
        }
    }
}
