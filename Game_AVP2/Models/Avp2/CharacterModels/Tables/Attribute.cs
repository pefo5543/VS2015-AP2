using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class Attribute : AttributeBase
    {
        [Key, ForeignKey("StaticCharacter")]
        public int StaticCharacterId { get; set; }

        public virtual StaticCharacter StaticCharacter { get; set; }

        public virtual ICollection<CharacterAttribute> CharacterAttributes { get; set; }
    }
}