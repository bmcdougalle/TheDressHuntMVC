using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class Dress
    {
        [Key]
        public int DressId { get; set; }
        public Guid OwnerId { get; set; }

        [Display(Name = "Dress Size")]
        public string DressSize { get; set; }

        //[ForeignKey(nameof(Shops))]
        //public int? ShopId { get; set; }
        public virtual ICollection<DressShop> Shops { get; set; } = new List<DressShop>();
    }
}
