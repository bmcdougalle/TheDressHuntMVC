using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Data;
using TheDressHunt.Models.TheHunt;
using TheDressHunt.Models.TheTeamHunt;

namespace TheDressHunt.Service
{
    public class TeamHuntService
    {
        private readonly Guid _userId;

        public TeamHuntService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeamHunt(CreateTeamHunt model)
        {
            var entity =
                new TeamHunt()
                {
                    TeamName = model.TeamName
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.TeamHunts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamHuntListItem> GetTeamHunts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .TeamHunts
                    .Select(
                        e =>
                        new TeamHuntListItem
                        {
                            TeamId = e.TeamId,
                            TeamName = e.TeamName
                        });
                return query.ToArray();
            }
        }
        public TeamHuntDetail GetTeamHUntById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeamHunts
                    .Single(e => e.TeamId == id);
                return new TeamHuntDetail
                {
                    TeamId = entity.TeamId,
                    TeamName = entity.TeamName,
                    Hunts = (List<HuntListItem>)entity.Hunts
                            .Select(e =>
                            new HuntListItem()
                            {
                                HuntId = e.HuntId,
                                DateofHunt = e.DateofHunt,
                                TypeOfOccasion = e.TypeOfOccasion,
                            }).ToList()
                };
            }
        }
        public bool UpdateTeamHunt(EditTeamHunt model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeamHunts
                    .Single(e => e.TeamId == model.TeamId);
                entity.TeamName = model.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeamHunt(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeamHunts
                    .Single(e => e.TeamId == id);

                ctx.TeamHunts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
