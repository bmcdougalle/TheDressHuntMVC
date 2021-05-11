using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressHunt.Models.TheShop;

namespace TheDressHunt.Models.TheDress
{
    public class DressDetail
    {
        public int DressId { get; set; }
        [Display(Name = "Dress Size")]
        public string DressSize { get; set; }

        public List<ShopListItem> Shops { get; set; } = new List<ShopListItem>();
    }
}
