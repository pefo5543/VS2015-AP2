using Game_AVP2.Models.Avp2.Items.Tables;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;

namespace Game_AVP2.Models.Avp2.Items
{
    public class ArmourModel : ItemModel
    {
        internal static List<ArmourViewModel> RenderArmourSimpleList(List<Armour> list)
        {
            List<ArmourViewModel> l = new List<ArmourViewModel>();
            foreach (Armour a in list)
            {
                ArmourViewModel viewmodel = new ArmourViewModel();
                object o = SetViewModelProperties(viewmodel, a);
                viewmodel = (ArmourViewModel)o;
                l.Add(viewmodel);
            }
            return l;
        }

        internal static bool AddArmourToDb(Armour data)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            bool res = true;
            try
            {
                db.Armours.Add(data);
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }
            db.SaveChanges();

            return res;
        }

        internal static void DeleteArmour(int id, ApplicationDbContext dbCurrent)
        {
            Armour w = dbCurrent.Armours.Find(id);
            if (w != null)
            {
                dbCurrent.Armours.Remove(w);
            }

            dbCurrent.SaveChanges();
        }

        internal static bool EditArmour(Armour updatedArmour, ApplicationDbContext db)
        {
            //bool modified = false;
            bool noPropertyChanged = true;
            Armour originalArmour = new Armour();
            try
            {
                originalArmour = db.Armours.Find(updatedArmour.ArmourId);
                db.Armours.Attach(originalArmour);
            }
            catch (Exception)
            {
            }
            if (originalArmour != null)
            {
                noPropertyChanged = SetEditValues(db, originalArmour, updatedArmour);
            }
            return noPropertyChanged;
        }

        internal static string GetArmourImage(int id, ApplicationDbContext dbCurrent)
        {
            Armour w = dbCurrent.Armours.Find(id);
            ArmourImage wi = dbCurrent.ArmourImages.Find(w.ImageId);
            return wi.ImageLink;
        }

        internal static bool AddArmour(ArmourViewModel data, ApplicationDbContext db)
        {
            Armour armour = RenderArmour(data, db);
            bool result = AddArmourToDb(armour);
            return result;
        }

        private static Armour RenderArmour(ArmourViewModel data, ApplicationDbContext db)
        {
            int Id = -1;
            if (data.ArmourId != 0 && data.ArmourId != -1)
            {
                Id = data.ArmourId;
            }
            Armour armour = new Armour()
            {
                ArmourId = Id,
                Name = data.Name,
                Description = data.Description,
                ArmourType = data.ArmourType,
                Defense = data.Defense,
                ExtraDefense = data.ExtraDefense,
                Rarity = data.Rarity,
                Value = data.Value,
                ImageId = Int16.Parse(data.Image)

            };
            return armour;
        }
    }
}