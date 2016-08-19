using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Game_AVP2.ModelViews
{
    public class StaticCharacterViewModel : StaticCharacterShorthandViewModel
    {
        public AttributeViewModel Attribute { get; set;}
        public string ImageLink { get; set; }
        public string EquippedWeaponName { get; set; }
        public string EquippedArmourName { get; set; }
    }
}