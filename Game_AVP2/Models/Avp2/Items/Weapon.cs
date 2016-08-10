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
        public string WeaponType { get; set; }

        [Required]
        public int Damage { get; set; }

        public int ExtraDamage { get; set; }

        //public virtual StaticCharacter StaticCharacter { get; set; }
        public virtual Item Item { get; set; }


    }
}