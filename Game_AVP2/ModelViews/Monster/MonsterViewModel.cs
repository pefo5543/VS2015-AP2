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
        public MonsterViewModel (Monster s)
        {
            MonsterId = s.MonsterId;
            ImageLink = s.MonsterImage.ImageLink;
            ImageId = s.MonsterImage.MonsterImageId;
            Name = s.Name;
            Description = s.Description;
            Background = s.Background;
            Attribute.Strength = s.MonsterAttribute.Strength;
            Attribute.Dexterity = s.MonsterAttribute.Dexterity;
            Attribute.Health = s.MonsterAttribute.Health;
            Attribute.LuckModifier = s.MonsterAttribute.LuckModifier;
            Attribute.DefenceModifier = s.MonsterAttribute.DefenceModifier;
            Attribute.StrengthModifier = s.MonsterAttribute.StrengthModifier;
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