using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using System.Collections.Generic;
using System.Linq;

namespace Game_AVP2.Controllers
{
    internal class ItemModel
    {
        public List<MiscViewModel> MiscList { get; set; }
        public List<ArmourViewModel> ArmourList { get; set; }
        public List<WeaponViewModel> WeaponList { get; set; }

        public ItemModel()
        {


        }

        internal void RenderItemsList(List<Item> items, ApplicationDbContext db)
        {
            List<MiscViewModel> miscList = new List<MiscViewModel>();
            List<ArmourViewModel> armourList = new List<ArmourViewModel>();
            List<WeaponViewModel> weaponList = new List<WeaponViewModel>();
            foreach (Item i in items)
            {
                if(i.Type== "Weapon")
                {
                    Weapon w = db.Weapons.Find(i.ItemId);
                    WeaponViewModel wm = new WeaponViewModel(i, w);
                    weaponList.Add(wm);
                }else if(i.Type == "Armour")
                {
                    Armour a = db.Armours.Find(i.ItemId);
                    ArmourViewModel am = new ArmourViewModel(i, a);
                    armourList.Add(am);
                } else
                {
                    Misc m = db.Misc.Find(i.ItemId);
                    MiscViewModel mm = new MiscViewModel(i, m);
                    miscList.Add(mm);
                }
                //ItemViewModel p = new ItemViewModel(i, db);
                //list.Add(p);
            }
            WeaponList = weaponList;
            ArmourList = armourList;
            MiscList = miscList;
            //IQueryable<WeaponViewModel> listQ = list.AsQueryable();

        }
    }
}