using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheTeamHunt
{
    public class TeamHuntListItem
    {
        public int TeamId { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
    }
}
