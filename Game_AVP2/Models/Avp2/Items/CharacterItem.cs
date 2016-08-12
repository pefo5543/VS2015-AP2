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

        public virtual Character Character { get; set; }
        public virtual StaticCharacter StaticCharacter { get; set; }
        public virtual Armour Armour { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual Misc Misc { get; set; }
    }
}