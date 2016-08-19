using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class Attribute
    {
        public Attribute()
        {
            this.Characters = new HashSet<Character>();
        }

        [Key, ForeignKey("StaticCharacter")]
        public int StaticCharacterId { get; set; }

        public int CharacterId { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int LuckModifier { get; set; }
        public int DefenceModifier { get; set; }
        public int StrengthModifier { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        //[Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual StaticCharacter StaticCharacter { get; set; }
    }
}