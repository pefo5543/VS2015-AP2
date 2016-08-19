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




}