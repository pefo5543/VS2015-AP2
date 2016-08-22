using Game_AVP2.Models.Avp2.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Game_AVP2.ModelViews
{
    //used in StatichCharacter table and info
    public class StaticCharacterViewModel : StaticCharacterShorthandViewModel
    {
        //public AttributeViewModel Attribute { get; set;}
        public string ImageLink { get; set; }
        public string EquippedWeaponName { get; set; }
        public string EquippedArmourName { get; set; }

        public StaticCharacterViewModel()
        {
        }
        public StaticCharacterViewModel (StaticCharacter s)
        {
            StaticCharacterId = s.StaticCharacterId;
            ImageLink = s.CharacterImage.ImageLink;
            ImageId = s.CharacterImage.CharacterImageId;
            Name = s.Name;
            Description = s.Description;
            Strength = s.Attribute.Strength;
            Dexterity = s.Attribute.Dexterity;
            Health = s.Attribute.Health;
            LuckModifier = s.Attribute.LuckModifier;
            DefenceModifier = s.Attribute.DefenceModifier;
            StrengthModifier = s.Attribute.StrengthModifier;
            EquippedArmourName = s.ArmourEquipped.Name;
            EquippedArmourId = s.ArmourEquipped.ArmourId;
            EquippedWeaponName = s.WeaponEquipped.Name;
            EquippedWeaponId = s.WeaponEquipped.WeaponId;
            AbilityID = s.AbilityID;
        }
    }
}