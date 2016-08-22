using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class CharacterAttribute
    {
        [Key]
        public int CharacterAttributeId { get; set;}
        [Required]
        public int AttributeId { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int DefenceModifier { get; set; }
        public int StrengthModifier { get; set; }

        public virtual Character Character { get; set; }
        public virtual Tables.Attribute Attribute { get; set; }
    }
}