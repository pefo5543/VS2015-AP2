using Game_AVP2.Models.Avp2.Items.Tables;
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

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string MiscType { get; set; }

        public int HealthBonus { get; set; }

        [Required]
        public int Rarity { get; set; }

        [Required]
        public int Value { get; set; }

        public Misc()
        {
            this.CharacterItems = new HashSet<CharacterItem>();
        }
        
        public virtual ICollection<CharacterItem> CharacterItems { get; set; }
    }
}