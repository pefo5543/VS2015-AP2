using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        public Character()
        {
            this.Abilities = new HashSet<Ability>();
        }

        [Required]
        [StringLength(50, ErrorMessage = "Choose a shorter name of your character")]
        public string Name { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public int Credits { get; set; }


        //Relation to StaticCharacter
        [ForeignKey("StaticCharacter")]
        public int StaticCharacterId { get; set; }
        public virtual StaticCharacter StaticCharacter { get; set; }


        //Relation to AspNetUsers
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //1to1 relation to Attributes
        //[ForeignKey("Attributes")]
        public virtual CharacterAttribute CharacterAttribute { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }
    }

    public class Attribute {
        public Attribute()
        {
            this.CharacterAttributes = new HashSet<CharacterAttribute>();
        }

        [Key, ForeignKey("StaticCharacter")]
        public int StaticCharacterId { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int DefenceModifier { get; set; }
        public int StrengthModifier { get; set; }

        public virtual ICollection<CharacterAttribute> CharacterAttributes { get; set; }
        public virtual StaticCharacter StaticCharacter { get; set; }
    }

    public class CharacterAttribute
    {
        [Key]
        public int CharacterAttributeId { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int DefenceModifier { get; set; }
        public int StrengthModifier { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual Character Character { get; set; }
    }

    public class Ability
    {
        [Key]
        public int AbilityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Choose a shorter description")]
        public string Description { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual StaticCharacter StaticCharacter { get; set; }

    }

}