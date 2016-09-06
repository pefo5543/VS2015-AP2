using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Game_AVP2.ModelViews
{
    //used in StatichCharacter table and info
    public class MonsterViewModel : MonsterShorthandViewModel
    {
        //public AttributeViewModel Attribute { get; set;}
        public string ImageLink { get; set; }
        public string EquippedWeaponName { get; set; }
        public string EquippedArmourName { get; set; }
        public string EquippedWeaponLink { get; set; }
        public string EquippedArmourLink { get; set; }

        public MonsterViewModel() :base()
        { 
        }
        public MonsterViewModel (Monster s, bool forUi = false)
        {
            if(!forUi)
            {
                MonsterId = s.MonsterId;
                ImageId = s.MonsterImage.MonsterImageId;
                EquippedArmourId = s.ArmourEquipped.ArmourId;
                EquippedWeaponId = s.WeaponEquipped.WeaponId;
                AbilityID = s.AbilityID;
            }
            ImageLink = s.MonsterImage.ImageLink;
            Name = s.Name;
            Description = s.Description;
            Background = s.Background;
            Attribute.Strength = s.MonsterAttribute.Strength;
            Attribute.Dexterity = s.MonsterAttribute.Dexterity;
            Attribute.Health = s.MonsterAttribute.Health;
            Attribute.Luck = s.MonsterAttribute.Luck;
            Attribute.DefenceModifier = s.MonsterAttribute.DefenceModifier;
            Attribute.StrengthModifier = s.MonsterAttribute.StrengthModifier;
            EquippedArmourName = s.ArmourEquipped.Name;
            EquippedArmourLink = s.ArmourEquipped.ArmourImage.ImageLink;
            EquippedWeaponName = s.WeaponEquipped.Name;
            EquippedWeaponLink = s.WeaponEquipped.WeaponImage.ImageLink;
            Rarity = s.Rarity;
        }
    }
}