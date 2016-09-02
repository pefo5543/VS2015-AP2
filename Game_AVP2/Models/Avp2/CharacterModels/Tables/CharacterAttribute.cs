using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class CharacterAttribute : AttributeBase
    {
        [Key, ForeignKey("Character")]
        public int CharacterId { get; set;}
        [Required]
        public int AttributeId { get; set; }

        public int HealthLeft { get; set; }
        public int StaminaLeft { get; set; }

        public virtual Character Character { get; set; }
        [ForeignKey("AttributeId")]
        public virtual Tables.Attribute Attribute { get; set; }
    }
}