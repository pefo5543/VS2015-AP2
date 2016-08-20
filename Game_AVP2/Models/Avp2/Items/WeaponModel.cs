using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;

namespace Game_AVP2.Models.Avp2.Items
{
    public class WeaponModel : ItemModel
    {

        internal static List<WeaponViewModel> RenderWeaponSimpleList(List<Weapon> list)
        {
            List<WeaponViewModel> l = new List<WeaponViewModel>();
            foreach(Weapon w in list)
            {
                WeaponViewModel viewmodel = new WeaponViewModel();
                object o = SetModelProperties(viewmodel, w);
                viewmodel = (WeaponViewModel) o;
                l.Add(viewmodel);
            }
            return l;
        }

        internal static bool AddWeaponToDb(Weapon data)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            bool res = true;
            try
            {
                db.Weapons.Add(data);
                //WeaponImage wi = db.WeaponImages.Find(data.ImageId);
                //wi.Weapons.Add(data);
                
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }
            db.SaveChanges();

            return res;
        }

        internal static void DeleteWeapon(int id, ApplicationDbContext dbCurrent)
        {
            Weapon w = dbCurrent.Weapons.Find(id);
            if (w != null)
            {
                dbCurrent.Weapons.Remove(w);
            }
            //WeaponPhoto wp =dbCurrent.WeaponPhotoes.Find(id);
            //if(wp != null)
            //{
            //    dbCurrent.WeaponPhotoes.Remove(wp);
            //}

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
                noPropertyChanged = SetEditValues(db, originalWeapon, updatedWeapon);
            }
            return noPropertyChanged;
        }

        internal static string GetWeaponImage(int id, ApplicationDbContext dbCurrent)
        {
            string link = "";
            Weapon w = dbCurrent.Weapons.Find(id);
            if(w != null)
            {
                WeaponImage wi = dbCurrent.WeaponImages.Find(w.ImageId);
                link = wi.ImageLink;
            }
            return link;
        }

        internal static bool AddWeapon(WeaponViewModel data, ApplicationDbContext db)
        {
            Weapon weapon = RenderWeapon(data);
            bool result = AddWeaponToDb(weapon);
            return result;
        }

        private static Weapon RenderWeapon(WeaponViewModel data)
        {
            //int Id = -1;
            //if (data.WeaponId != 0 && data.WeaponId != -1)
            //{
            //    Id = data.WeaponId;
            //}
            ////WeaponImage im = db.WeaponImages.Find(Int16.Parse(data.Image));
            //Weapon weapon = new Weapon()
            //{
            //    WeaponId = Id,
            //    Name = data.Name,
            //    Description = data.Description,
            //    WeaponType = data.WeaponType,
            //    Damage = data.Damage,
            //    ExtraDamage = data.ExtraDamage,
            //    Rarity = data.Rarity,
            //    Value = data.Value,
            //    ImageId = Int16.Parse(data.Image)

            //};

            if (data.WeaponId == 0)
            {
                data.WeaponId = -1;
            }
            Weapon w = new Weapon();
            //Set properties auto
            w = (Weapon)SetModelProperties(w, data);
            w.ImageId = Int16.Parse(data.Image);

            return w;
        }
    }
}