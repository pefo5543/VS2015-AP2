using Game_AVP2.Helpers;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Models.Avp2.CharacterModels
{
    public class MonsterModel : BaseModel
    {
        internal List<MonsterViewModel> RenderMonsterList(List<Monster> list, ApplicationDbContext db)
        {
            List<MonsterViewModel> l = new List<MonsterViewModel>();
            foreach (Monster c in list)
            {
                //CharacterModels.Tables.MonsterAttribute a = db.Attributes.Find(c.MonsterId);
                //c.Attribute = a;
                MonsterViewModel viewmodel = new MonsterViewModel(c);
                l.Add(viewmodel);
            }
            return l;
        }
        internal MonsterViewModel GetDetail(int id, ApplicationDbContext dbCurrent)
        {
            MonsterViewModel Monster = new MonsterViewModel();
            Monster c = dbCurrent.Monsters.Find(id);
            //get Monsterimage
            MonsterImage ci = c.MonsterImage;
            if (ci != null)
            {
                Monster.ImageLink = ci.ImageLink;
            }
            //get Equipped weapon
            if (c.WeaponEquipped != null)
            {
                Monster.EquippedWeaponName = c.WeaponEquipped.Name;
            }
            //get equipped armour name
            if (c.ArmourEquipped != null)
            {
                Monster.EquippedArmourName = c.ArmourEquipped.Name;
            }

            return Monster;
        }

        internal bool EditMonster(MonsterViewModel updated, ApplicationDbContext db)
        {
            bool noPropertyChanged = false;
            Monster original = new Monster();
            try
            {
                original = db.Monsters.Find(updated.MonsterId);
                db.Monsters.Attach(original);
            }
            catch (Exception)
            {
            }
            if (original != null)
            {
                noPropertyChanged = SetEditValues(db, original, updated);
            }

            return noPropertyChanged;
        }

        private void AddMonsterAttributes(int MonsterId, CharacterModels.Tables.MonsterAttribute a, ApplicationDbContext dbCurrent)
        {
            MonsterAttribute ca = new MonsterAttribute();

            ca.MonsterId = MonsterId;
            ca.DefenceModifier = a.DefenceModifier;
            ca.Dexterity = a.Dexterity;
            ca.Health = a.Health;
            ca.Luck = a.Luck;
            ca.Strength = a.Strength;
            ca.StrengthModifier = a.StrengthModifier;

            try
            {
                dbCurrent.MonsterAttributes.Add(ca);
            }
            catch { }
        }

        //internal IEnumerable<SelectListItem> GetArmourSelectList(ApplicationDbContext dbCurrent)
        //{
        //    var db = new ArmourSelectList();
        //    var armours = db
        //                .GetArmours(dbCurrent)
        //                .Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.ArmourId.ToString(),
        //                            Text = x.Name
        //                        });
        //    return new SelectList(armours, "Value", "Text");
        //}

        internal IEnumerable<SelectListItem> GetImagesSelectList(ApplicationDbContext dbCurrent)
        {
            var db = new MonsterImageSelectList();
            var images = db
                        .GetImages(dbCurrent)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ImageId.ToString(),
                                    Text = x.ImageName
                                });
            return new SelectList(images, "Value", "Text");
        }

        //internal IEnumerable<SelectListItem> GetWeaponSelectList(ApplicationDbContext dbCurrent)
        //{
        //    var db = new WeaponSelectList();
        //    var weapons = db
        //                .GetWeapons(dbCurrent)
        //                .Select(x =>
        //                        new SelectListItem
        //                        {
        //                            Value = x.WeaponId.ToString(),
        //                            Text = x.Name
        //                        });
        //    return new SelectList(weapons, "Value", "Text");
        //}

        internal bool AddMonster(MonsterShorthandViewModel data, ApplicationDbContext dbCurrent)
        {
            bool res = true;
            try
            {
                Monster sc = RenderMonster(data);
                int id = AddMonsterToDb(sc, dbCurrent);
                CharacterModels.Tables.MonsterAttribute a = RenderAttribute(data, id);
                res = AddAttributeToDb(a, dbCurrent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = false;
            }

            return res;
        }

        private bool AddAttributeToDb(CharacterModels.Tables.MonsterAttribute a, ApplicationDbContext db)
        {
            bool res = true;
            try
            {
                db.MonsterAttributes.Add(a);
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }
            db.SaveChanges();

            return res;
        }

        private CharacterModels.Tables.MonsterAttribute RenderAttribute(MonsterShorthandViewModel data, int id)
        {
            CharacterModels.Tables.MonsterAttribute a = new CharacterModels.Tables.MonsterAttribute();
            //Set properties auto
            a.Dexterity = data.Attribute.Dexterity;
            a.Strength = data.Attribute.Strength;
            a.Health = data.Attribute.Health;
            a.Luck = data.Attribute.Luck;
            a.StrengthModifier = data.Attribute.StrengthModifier;
            a.DefenceModifier = data.Attribute.DefenceModifier;
            a.MonsterId = id;
            return a;
        }

        private int AddMonsterToDb(Monster sc, ApplicationDbContext db)
        {
            try
            {
                db.Monsters.Add(sc); //Maybe not necessary
                //MonsterImage ci = db.MonsterImages.Find(sc.ImageId);
                //ci.Monsters.Add(sc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            db.SaveChanges();

            return sc.MonsterId;
        }

        internal bool DeleteMonster(int id, ApplicationDbContext dbCurrent)
        {
            bool res = false;
            Monster s = dbCurrent.Monsters.Find(id);
            if (s != null)
            {
                dbCurrent.Monsters.Remove(s);
            }
            try
            {
                dbCurrent.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = false;
            }
            return res;
        }

        private Monster RenderMonster(MonsterShorthandViewModel data)
        {
            if (data.MonsterId == 0)
            {
                data.MonsterId = -1;
            }

            MonsterShorthandViewModel shortdata = data;
            Monster Monster = new Monster();
            //Set properties auto
            Monster = (Monster)SetModelProperties(Monster, shortdata);
            return Monster;
        }
    }
}