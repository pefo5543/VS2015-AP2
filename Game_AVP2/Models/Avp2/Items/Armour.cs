using Game_AVP2.Models.Avp2.CharacterModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class Armour
    {
        [Key]
        public int ArmourId { get; set; }

        //[ForeignKey("Item")]
        //public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string ArmourType { get; set; }

        [Required]
        public int Defense { get; set; }

        public int ExtraDefense { get; set; }

        [Required]
        public int Rarity { get; set; }

        [Required]
        public int Value { get; set; }

        //public virtual StaticCharacter StaticCharacter { get; set; }

        public Armour()
        {
            this.CharacterItems = new HashSet<CharacterItem>();
        }
        public virtual ICollection<CharacterItem> CharacterItems { get; set; }
    }
}