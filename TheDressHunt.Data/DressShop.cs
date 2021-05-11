using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDressHunt.Data
{
    public class DressShop
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Shop))]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Dress))]
        public int DressId { get; set; }
        public virtual Dress Dress { get; set; }

        public string DressSize { get; set; }
    }
}
