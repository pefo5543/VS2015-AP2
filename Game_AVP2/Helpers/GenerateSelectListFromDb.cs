using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.Helpers
{

    public class ImageSelect
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
    }
    public class WeaponSelect
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
    }
    public class ArmourSelect
    {
        public int ArmourId { get; set; }
        public string Name { get; set; }
    }

    public class WeaponImageSelectList
    {
        public List<ImageSelect> GetImages(ApplicationDbContext db)
        {
            List<ImageSelect> Images = new List<ImageSelect>();

            List<WeaponImage> imgList = db.WeaponImages.ToList();
            foreach (WeaponImage item in imgList)
            {
                ImageSelect c = new ImageSelect();
                c.ImageName = item.Name;
                c.ImageId = item.WeaponImageId;
                Images.Add(c);
            }
            return Images;
        }
    }

    public class ArmourImageSelectList
    {
        public List<ImageSelect> GetImages(ApplicationDbContext db)
        {
            List<ImageSelect> Images = new List<ImageSelect>();

            List<ArmourImage> imgList = db.ArmourImages.ToList();
            foreach (ArmourImage item in imgList)
            {
                ImageSelect c = new ImageSelect();
                c.ImageName = item.Name;
                c.ImageId = item.ArmourImageId;
                Images.Add(c);
            }
            return Images;
        }
    }

    public class CharacterImageSelectList
    {
        public List<ImageSelect> GetImages(ApplicationDbContext db)
        {
            List<ImageSelect> Images = new List<ImageSelect>();

            List<CharacterImage> imgList = db.CharacterImages.ToList();
            foreach (CharacterImage item in imgList)
            {
                ImageSelect c = new ImageSelect();
                c.ImageName = item.Name;
                c.ImageId = item.CharacterImageId;
                Images.Add(c);
            }
            return Images;
        }
    }

    public class MonsterImageSelectList
    {
        public List<ImageSelect> GetImages(ApplicationDbContext db)
        {
            List<ImageSelect> Images = new List<ImageSelect>();

            List<MonsterImage> imgList = db.MonsterImages.ToList();
            foreach (MonsterImage item in imgList)
            {
                ImageSelect c = new ImageSelect();
                c.ImageName = item.Name;
                c.ImageId = item.MonsterImageId;
                Images.Add(c);
            }
            return Images;
        }
    }

    public class WeaponSelectList
    {
        public List<WeaponSelect> GetWeapons(ApplicationDbContext db)
        {
            List<WeaponSelect> Weapons = new List<WeaponSelect>();

            List<Weapon> weaponList = db.Weapons.ToList();
            foreach (Weapon w in weaponList)
            {
                WeaponSelect s = new WeaponSelect();
                s.Name = w.Name;
                s.WeaponId = w.WeaponId;
                Weapons.Add(s);
            }
            return Weapons;
        }
    }
    public class ArmourSelectList
    {
        public List<ArmourSelect> GetArmours(ApplicationDbContext db)
        {
            List<ArmourSelect> Armours = new List<ArmourSelect>();

            List<Armour> armourList = db.Armours.ToList();
            foreach (Armour a in armourList)
            {
                ArmourSelect s = new ArmourSelect();
                s.Name = a.Name;
                s.ArmourId = a.ArmourId;
                Armours.Add(s);
            }
            return Armours;
        }
    }




}