using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.ModelViews
{
    public class MonsterShorthandViewModel
    {
        public MonsterShorthandViewModel()
        {
            this.Attribute = new AttributeViewModel();
        }
        public int MonsterId { get; set; }
        public AttributeViewModel Attribute { get; set; }
        public int EquippedWeaponId { get; set; }
        public int EquippedArmourId { get; set; }
        public int AbilityID { get; set; }
        public int ImageId { get; set; }
        public int Rarity { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        //public string ImageLink { get; set; }
    }
}