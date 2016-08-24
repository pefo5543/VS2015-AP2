using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;
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

        //[Required]
        //public int CharacterAttributeId { get; set;}

        public Character()
        {
            this.Abilities = new HashSet<Ability>();
            this.CharacterWeapons = new HashSet<CharacterWeapon>();
            this.CharacterArmours = new HashSet<CharacterArmour>();
        }

        //public int ImageId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Choose a shorter name of your character")]
        public string Name { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public int Credits { get; set; }
        public string Background { get; set; }
        //Relation to StaticCharacter
        [Required]
        public int StaticCharacterId { get; set; }
        [ForeignKey("StaticCharacterId")]
        public virtual StaticCharacter StaticCharacter { get; set; }
        //Relation to AspNetUsers   
        [Required] 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Tables.CharacterAttribute CharacterAttribute { get; set; }

        public virtual ICollection<CharacterWeapon> CharacterWeapons { get; set; }
        public virtual ICollection<CharacterArmour> CharacterArmours { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }
    }

    //public class CharacterAttribute
    //{
    //    [Key, ForeignKey("Character")]
    //    public int CharacterId { get; set; }

    //    public int AttributeId { get; set; }

    //    public int Health { get; set; }
    //    public int Strength { get; set; }
    //    public int Dexterity { get; set; }
    //    public int LuckModifier { get; set; }
    //    public int DefenceModifier { get; set; }
    //    public int StrengthModifier { get; set; }
    //    [ForeignKey("AttributeId")]
    //    public virtual Attribute Attribute { get; set; }

    //    public virtual Character Character { get; set; }
    //}

    public class Ability
    {
        public Ability()
        {
            this.StaticCharacters = new HashSet<StaticCharacter>();
        }

        [Key]
        public int AbilityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Choose a shorter description")]
        public string Description { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<StaticCharacter> StaticCharacters { get; set; }

    }

}