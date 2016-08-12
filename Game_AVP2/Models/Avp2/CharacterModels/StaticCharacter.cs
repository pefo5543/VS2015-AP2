using Game_AVP2.Models.Avp2.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels
{
    public class StaticCharacter
    {
        public StaticCharacter()
        {
            this.Characters = new HashSet<Character>();
        }
        [Key]
        public int StaticCharacterId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Choose a shorter name of your character")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Choose a shorter description")]
        public string Description { get; set; }

        [Required]
        public int EquippedWeaponId { get; set; }

        [Required]
        public int EquippedArmourId { get; set; }

        public virtual ICollection<Character> Characters { get; set; }

        //[ForeignKey("Attributes")]
        //public int AttributesId { get; set; }
        public virtual Attribute Attribute { get; set; }

        //[ForeignKey("Ability")]
        public int? AbilityId { get; set; }
        public virtual Ability Ability { get; set; }

        //[ForeignKey("EquippedWeaponId")]
        //[Required]
        //public virtual CharacterItem EquippedWeapon { get; set; }
        //[ForeignKey("EquippedArmourId")]
        //[Required]
        //public virtual CharacterItem EquippedArmour { get; set; }


    }
}