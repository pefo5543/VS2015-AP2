using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace Game_AVP2.Controllers
{
    internal class ItemModel
    {
        public List<Misc> MiscList { get; set; }
        public List<Armour> ArmourList { get; set; }
        public List<Weapon> WeaponList { get; set; }

        public ItemModel()
        {
        }

        internal void RenderAllItems(ApplicationDbContext db)
        {
            MiscList = db.Misc.ToList();
            ArmourList = db.Armours.ToList();
            WeaponList = db.Weapons.ToList();

        }
        internal static int AddWeaponToDb(Weapon data, ApplicationDbContext dbCurrent)
        {
            int res = 0;
            try
            {
                dbCurrent.Weapons.Add(data);
            }
            catch (Exception e)
            {
                res = 0;
                Console.WriteLine(e.Message);
            }
            dbCurrent.SaveChanges();
            res = data.WeaponId;

            return res;
        }

        internal static void DeleteWeapon(int id, ApplicationDbContext dbCurrent)
        {
            Weapon w = dbCurrent.Weapons.Find(id);
            dbCurrent.Weapons.Remove(w);
            dbCurrent.SaveChanges();
        }

        internal static bool EditWeapon(Weapon updatedWeapon, ApplicationDbContext db)
        {
            //bool modified = false;
            bool noPropertyChanged = true;
            Weapon originalWeapon = new Weapon();
            try
            {
                originalWeapon = db.Weapons.Find(updatedWeapon.WeaponId);
                db.Weapons.Attach(originalWeapon);
            }
            catch (Exception)
            {
            }
            if (originalWeapon != null)
            {
                var entry = db.Entry(originalWeapon);

                entry.CurrentValues.SetValues(updatedWeapon);
                entry.OriginalValues.SetValues(originalWeapon);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    noPropertyChanged = false;
                }
            }
            return noPropertyChanged;
        }

        internal static byte[] GetWeaponImage(int id, ApplicationDbContext dbCurrent)
        {
            byte[] img = null;
            WeaponPhoto obj = dbCurrent.WeaponPhotoes.Find(id);
            if(obj != null && obj.Image != null)
            {
                img = obj.Image;
            } else {
                //No image found - return blank image
                img = null;
            }
            return img;
        }

        internal static void AddWeaponAndPhoto(WeaponViewModel data, ApplicationDbContext dbCurrent)
        {
            int newId = 0;
            Weapon weapon = RenderWeapon(data);
            newId = AddWeaponToDb(weapon, dbCurrent);
            if (data.Photo.ContentLength > 0)
            {
                var filename = Path.GetFileName(data.Photo.FileName);

                Image sourceimage =
                Image.FromStream(data.Photo.InputStream);
                AddWeaponPhoto(newId, sourceimage, dbCurrent);
            }            
        }

        private static Weapon RenderWeapon(WeaponViewModel data)
        {
            int Id = -1;
            if(data.WeaponId != 0 && data.WeaponId != -1)
            {
                Id = data.WeaponId;
            } 
            Weapon weapon = new Weapon()
            {
                WeaponId = Id,
                Name = data.Name,
                Description = data.Description,
                WeaponType = data.WeaponType,
                Damage = data.Damage,
                ExtraDamage = data.ExtraDamage,
                Rarity = data.Rarity,
                Value = data.Value
            };
                return weapon;
        }

        public static bool AddWeaponPhoto(int id, Image image, ApplicationDbContext db)
        {
            bool result = true;
            byte[] byteArray = ImageToByteArray(image);
            WeaponPhoto img = new WeaponPhoto();
            img.Image = byteArray;
            img.WeaponId = id;
            try
            {
                db.WeaponPhotoes.Add(img);
                db.SaveChanges();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //protected static void SetValue(object original, string theProperty, object theValue)
        //{
        //    try
        //    {
        //        PropertyInfo propertyInfo = original.GetType().GetProperty(theProperty);
        //        propertyInfo.SetValue(original, theValue, null);
        //        propertyInfo.GetType().GetProperties();

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //private static bool CheckPropertyModified(object original, object updated, bool nullCheck)
        //{
        //    bool modified = false;
        //    if (original != updated && nullCheck)
        //    {
        //        modified = true;

        //    }
        //    else
        //    {
        //        modified = false;
        //    }
        //    return modified;
        //}


        //modified = ItemModel.CheckPropertyModified(originalWeapon.Name, updatedWeapon.Name, (updatedWeapon.Name != null) ? true : false);
        //entry.Property(e => e.Name).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Name", updatedWeapon.Name);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.WeaponType, updatedWeapon.WeaponType, (updatedWeapon.WeaponType != null) ? true : false);
        //entry.Property(e => e.WeaponType).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "WeaponType", updatedWeapon.WeaponType);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Name, updatedWeapon.Name, (updatedWeapon.Name != null) ? true : false);
        //entry.Property(e => e.Name).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Description", updatedWeapon.Description);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Damage, updatedWeapon.Damage, (updatedWeapon.Damage != -1) ? true : false);
        //entry.Property(e => e.Damage).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Damage", updatedWeapon.Damage);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.ExtraDamage, updatedWeapon.ExtraDamage, (updatedWeapon.ExtraDamage != -1) ? true : false);
        //entry.Property(e => e.ExtraDamage).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "ExtraDamage", updatedWeapon.ExtraDamage);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Rarity, updatedWeapon.Rarity, (updatedWeapon.Rarity != -1) ? true : false);
        //entry.Property(e => e.Rarity).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Rarity", updatedWeapon.Rarity);
        //}
        //modified = ItemModel.CheckPropertyModified(originalWeapon.Value, updatedWeapon.Value, (updatedWeapon.Value != -1) ? true : false);
        //entry.Property(e => e.Value).IsModified = modified;
        //if (modified)
        //{
        //    noPropertyChanged = true;
        //    SetValue(originalWeapon, "Value", updatedWeapon.Value);
        //}
    }
}