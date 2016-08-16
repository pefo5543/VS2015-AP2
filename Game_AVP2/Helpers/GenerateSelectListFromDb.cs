using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.Helpers
{

    public class ImageSelect
    {
        public int WeaponImageId { get; set; }
        public string ImageName { get; set; }
    }

    public class ImageSelectList
    {
        public List<ImageSelect> GetImages(ApplicationDbContext db)
        {
            List<ImageSelect> Images = new List<ImageSelect>();

            List<WeaponImage> imgList = db.WeaponImages.ToList();
            foreach (WeaponImage item in imgList)
            {
                ImageSelect c = new ImageSelect();
                c.ImageName = item.Name;
                c.WeaponImageId = item.WeaponImageId;
                Images.Add(c);
            }
            return Images;
        }
    }




}