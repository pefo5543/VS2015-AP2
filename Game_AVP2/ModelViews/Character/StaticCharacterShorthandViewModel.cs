using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.ModelViews
{
    public class StaticCharacterShorthandViewModel : CharacterBaseViewModel
    {
        public int StaticCharacterId { get; set; }

        public int EquippedWeaponId { get; set; }
        public int EquippedArmourId { get; set; }
        public int AbilityID { get; set; }
        public int ImageId { get; set; }
        //public string ImageLink { get; set; }
    }
}