using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Models.TheHunt;

namespace TheDressHunt.Models.TheTeamHunt
{
    public class TeamHuntDetail
    {
        public int TeamId { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        public List<HuntListItem> Hunts { get; set; } = new List<HuntListItem>();
    }
}
