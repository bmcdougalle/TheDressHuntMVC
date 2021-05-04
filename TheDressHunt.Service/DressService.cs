using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;
using TheDressHunt.Models.TheDress;

namespace TheDressHunt.Service
{
    public class DressService
    {
        private readonly Guid _userId;

        public DressService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDress(CreateDress model)
        {
            var entity =
                new Dress()
                {
                    OwnerId = _userId,
                    DressSize = model.DressSize
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Dresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DressListItem> GetDresses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Dresses
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                       new DressListItem
                       {
                           DressId = e.DressId,
                           DressSize = e.DressSize
                       }
                    );
                return query.ToArray();
            }
        }

        public DressDetail GetDressByDressId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dresses
                    .Single(e => e.DressId == id && e.OwnerId == _userId);
                return
                    new DressDetail
                    {
                        DressId = entity.DressId,
                        DressSize = entity.DressSize
                    };
            }
        }

        public bool UpdateDress(EditDress model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dresses
                    .Single(e => e.DressId == model.DressId && e.OwnerId == _userId);

                entity.DressSize = model.DressSize;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDress(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Dresses
                    .Single(e => e.DressId == id && e.OwnerId == _userId);

                ctx.Dresses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
