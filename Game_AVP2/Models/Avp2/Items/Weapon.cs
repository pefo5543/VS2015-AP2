using Game_AVP2.Models.Avp2.CharacterModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        //[ForeignKey("Item")]
        //public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string WeaponType { get; set; }

        [Required]
        public int Damage { get; set; }

        public int ExtraDamage { get; set; }

        [Required]
        public int Rarity { get; set; }

        [Required]
        public int Value { get; set; }

        //public virtual StaticCharacter StaticCharacter { get; set; }

        public Weapon()
        {
            this.CharacterWeapons = new HashSet<CharacterItem>();
        }

        public virtual ICollection<CharacterItem> CharacterWeapons { get; set; }
        public virtual WeaponPhoto Photo { get; set; }


    }
}