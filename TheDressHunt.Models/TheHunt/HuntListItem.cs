using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Models.TheHunt
{
    public class HuntListItem
    {
        public int HuntId { get; set; }
        public DateTime DateofHunt { get; set; }

        public int? TeamId { get; set; }
        public string TeamName { get; set; }
        public string TypeOfOccasion { get; set; }
    }
}
