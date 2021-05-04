using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheTeamHunt
{
    public class CreateTeamHunt
    {
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
    }
}
