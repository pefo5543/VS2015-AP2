using Game_AVP2.Models.Avp2.GameModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class Monster
    {
        [Key]
        public int MonsterId { get; set; }

        public int AbilityID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Choose a shorter name of monster")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Choose a shorter description")]
        public string Description { get; set; }

        public string Background { get; set; }

        public int EquippedWeaponId { get; set; }

        public int EquippedArmourId { get; set; }

        public int ImageId { get; set; }

        public virtual ICollection<Battle> Battles { get; set; }

        public virtual MonsterAttribute MonsterAttribute { get; set; }

        [ForeignKey("EquippedWeaponId")]
        public virtual Weapon WeaponEquipped { get; set; }
        [ForeignKey("EquippedArmourId")]
        public virtual Armour ArmourEquipped { get; set; }
        [ForeignKey("ImageId")]
        public virtual MonsterImage MonsterImage { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }
    }
}