using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;
using TheDressHunt.Models.TheShop;

namespace TheDressHunt.Service
{
    public class ShopService
    {
        private readonly Guid _userId;

        public ShopService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShop(CreateShop model)
        {
            var entity =
                new Shop()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Location = model.Location,
                    HoursOfOperation = model.HoursOfOepration,
                    DressSizes = model.DressSizes

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShopListItem> GetShops()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shops
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ShopListItem
                        {
                            ShopId = e.ShopId,
                            Name = e.Name,
                            Location = e.Location,
                            HoursOfOperation = e.HoursOfOperation
                        }
                    );
                return query.ToArray();
            }
        }
        public ShopDetail GetShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shops
                    .Single(e => e.ShopId == id && e.OwnerId == _userId);
                return
                    new ShopDetail
                    {
                        ShopId = entity.ShopId,
                        Name = entity.Name,
                        Location = entity.Location,
                        HoursOfOperation = entity.HoursOfOperation,
                        DressSize = entity.DressSizes,
                        TypeOfOccasion = entity.TypeOfOccasion
                    };
            }
        }

        public bool UpdateShop(EditShop model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shops
                    .Single(e => e.ShopId == model.ShopId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.HoursOfOperation = model.HoursOfOperation;
                entity.DressSizes = model.DressSizeAvailable;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShop(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shops
                        .Single(e => e.ShopId == id && e.OwnerId == _userId);

                ctx.Shops.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
