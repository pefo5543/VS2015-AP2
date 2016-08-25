using Game_AVP2.Models.Avp2.CharacterModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items.Tables
{
    public class CharacterArmour
    {
        [Key]
        public int CharacterArmourId { get; set; }

        public int CharacterId { get; set; }
        public int ArmourId { get; set; }

        [Required]
        public bool Equipped { get; set; }
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }
        [ForeignKey("ArmourId")]
        public virtual Armour Armour { get; set; }
    }
}