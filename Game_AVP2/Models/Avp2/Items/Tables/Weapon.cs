using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    [Serializable]
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }

        [Required]
        public string Name { get; set; }
        [StringLength(200, ErrorMessage = "Too long")]
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

        public int ImageId { get; set; }

        public Weapon()
        {
            this.CharacterWeapons = new HashSet<CharacterWeapon>();
            this.StaticCharacters = new HashSet<StaticCharacter>();
            this.Monsters = new HashSet<Monster>();
        }

        public virtual ICollection<CharacterWeapon> CharacterWeapons { get; set; }

        [ForeignKey("ImageId")]
        public virtual WeaponImage WeaponImage { get; set; }
        public virtual ICollection<StaticCharacter> StaticCharacters { get; set; }
        public virtual ICollection<Monster> Monsters { get; set; }
    }
}