using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class Misc
    {
        [Key]
        public int MiscId { get; set; }

        //[ForeignKey("ItemId")]
        //public int ItemId { get; set; }

        [Required]
        public string MiscType { get; set; }

        public int HealthBonus { get; set; }

        public virtual Item Item { get; set; }
    }
}