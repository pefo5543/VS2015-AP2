using Game_AVP2.Models.Avp2.CharacterModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items
{
    public class CharacterItem
    {
        [Key]
        public int CharacterItemId { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual Character Character { get; set; }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual StaticCharacter StaticCharacter { get; set; }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual Armour Armour { get; set; }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual Weapon Weapon { get; set; }
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual Misc Misc { get; set; }
    }
}