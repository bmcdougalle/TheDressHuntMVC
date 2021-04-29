using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;
using TheDressHunt.Models;
using TheDressHunt.Models.HuntCreate;
using TheDressHunt.Models.TheHunt;

namespace TheDressHunt.Service
{
    public class HuntService
    {
        private readonly Guid _userId;

        public HuntService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatHunt(CreateHunt model)
        {
            var entity =
                new Hunt()
                {
                    OwnerId = _userId,
                    DateofHunt = model.DaTeOfHunt,
                    City = model.City,
                    ColorScheme = model.ColorScheme,
                    TypeOfOccasion = model.TypeOfOccasion,
                    DressType = model.DressType,



                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Hunts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HuntListItem> GetHunts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Hunts
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new HuntListItem
                        {

                        }
                    );
                return query.ToArray();
            }
        }

        public bool UpdateHunt(EditHunt model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hunts
                    .Single(e => e.HuntId == model.HuntId && e.OwnerId == _userId);

                entity.TypeOfOccasion = model.TypeOfOccasion;
                entity.ModifiedUtc = model.ModifiedUtc;
                entity.DateofHunt = model.DateOfHunt;
                entity.City = model.City;
                entity.ColorScheme = model.ColorScheme;
                entity.DressType = model.DressType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHunt(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Hunts
                    .Single(e => e.HuntId == id && e.OwnerId == _userId);

                ctx.Hunts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
