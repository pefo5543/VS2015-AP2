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
        public string EquippedWeaponLink { get; set; }
        public string EquippedArmourLink { get; set; }

        public StaticCharacterViewModel() :base()
        { 
        }
        public StaticCharacterViewModel (StaticCharacter s)
        {
            StaticCharacterId = s.StaticCharacterId;
            ImageLink = s.CharacterImage.ImageLink;
            ImageId = s.CharacterImage.CharacterImageId;
            Name = s.Name;
            Description = s.Description;
            Background = s.Background;
            Attribute.Strength = s.Attribute.Strength;
            Attribute.Dexterity = s.Attribute.Dexterity;
            Attribute.Health = s.Attribute.Health;
            Attribute.LuckModifier = s.Attribute.LuckModifier;
            Attribute.DefenceModifier = s.Attribute.DefenceModifier;
            Attribute.StrengthModifier = s.Attribute.StrengthModifier;
            EquippedArmourName = s.ArmourEquipped.Name;
            EquippedArmourId = s.ArmourEquipped.ArmourId;
            EquippedArmourLink = s.ArmourEquipped.ArmourImage.ImageLink;
            EquippedWeaponName = s.WeaponEquipped.Name;
            EquippedWeaponId = s.WeaponEquipped.WeaponId;
            EquippedWeaponLink = s.WeaponEquipped.WeaponImage.ImageLink;
            AbilityID = s.AbilityID;
        }
    }
}