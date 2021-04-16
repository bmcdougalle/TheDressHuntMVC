using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class Hunt
    {
        [Key]
        public int HuntId { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Shop))]
        public int? ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        public string Area { get; set; }
        public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
