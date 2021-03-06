﻿using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class Character
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 CharacterId { get; set; }

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

        public int Level { get; set; }

        public string Description { get; set; }
        public string Background { get; set; }
        //Relation to StaticCharacter
        [Required]
        public int StaticCharacterId { get; set; }
        [ForeignKey("StaticCharacterId")]
        [Column(Order = 2)]
        public virtual StaticCharacter StaticCharacter { get; set; }
        //Relation to AspNetUsers   
        [Required] 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [Column(Order = 1)]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Tables.CharacterAttribute CharacterAttribute { get; set; }
        public virtual GameModels.Tables.Game Game { get; set; }

        public virtual ICollection<CharacterWeapon> CharacterWeapons { get; set; }
        public virtual ICollection<CharacterArmour> CharacterArmours { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }
    }

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
        public virtual ICollection<Monster> Monsters { get; set; }

    }

}