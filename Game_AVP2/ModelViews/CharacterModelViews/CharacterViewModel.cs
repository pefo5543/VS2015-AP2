using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;

namespace Game_AVP2.ModelViews.CharacterModelViews
{
    public class CharacterViewModel : CharacterBaseViewModel
    {
        public int CharacterId { get; set; }

        public string ImageLink { get; set; }
        public string EquippedWeaponName { get; set; }
        public string EquippedArmourName { get; set; }
        public string EquippedWeaponLink { get; set; }
        public string EquippedArmourLink { get; set; }

        public int Experience { get; set; }
        public int Credits { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public int HealthLeft { get; set; }

        public CharacterViewModel() :base()
        {
        }
        public CharacterViewModel(Character s, Weapon w, Armour a)
        {
            CharacterId = s.CharacterId;
            ImageLink = s.StaticCharacter.CharacterImage.ImageLink;
            ImageId = s.StaticCharacter.CharacterImage.CharacterImageId;
            Name = s.Name;
            Description = s.Description;
            Background = s.Background;
            Experience = s.Experience;
            Credits = s.Credits;
            Score = s.Score;
            Level = s.Level;
            HealthLeft = s.CharacterAttribute.HealthLeft;
            Attribute.Strength = s.CharacterAttribute.Strength;
            Attribute.Dexterity = s.CharacterAttribute.Dexterity;
            Attribute.Health = s.CharacterAttribute.Health;
            Attribute.Luck = s.CharacterAttribute.Luck;
            Attribute.DefenceModifier = s.CharacterAttribute.DefenceModifier;
            Attribute.StrengthModifier = s.CharacterAttribute.StrengthModifier;
            EquippedArmourName = a.Name;
            EquippedArmourId = a.ArmourId;
            EquippedArmourLink = a.ArmourImage.ImageLink;
            EquippedWeaponName = w.Name;
            EquippedWeaponId = w.WeaponId;
            EquippedWeaponLink = w.WeaponImage.ImageLink;
        }
    }
}