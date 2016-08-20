using Game_AVP2.Helpers;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Models.Avp2
{
    public class CharacterModel : BaseModel
    {
        internal static List<StaticCharacterShorthandViewModel> RenderStaticSimpleList(List<StaticCharacter> list)
        {
            List<StaticCharacterShorthandViewModel> l = new List<StaticCharacterShorthandViewModel>();
            foreach (StaticCharacter c in list)
            {
                StaticCharacterShorthandViewModel viewmodel = new StaticCharacterShorthandViewModel();
                viewmodel.StaticCharacterId = c.StaticCharacterId;
                viewmodel.ImageId = c.ImageId;
                viewmodel.Name = c.Name;
                viewmodel.Strength = c.Attribute.Strength;
                viewmodel.Dexterity = c.Attribute.Dexterity;
                viewmodel.Health = c.Attribute.Health;
                viewmodel.LuckModifier = c.Attribute.LuckModifier;
                viewmodel.DefenceModifier = c.Attribute.DefenceModifier;
                viewmodel.StrengthModifier = c.Attribute.StrengthModifier;
                
                //object o = SetModelProperties(viewmodel, w);
                //viewmodel = (StaticCharacterShorthandViewModel)o;
                l.Add(viewmodel);
            }
            return l;
        }

        internal static StaticCharacterViewModel GetDetail(int id, ApplicationDbContext dbCurrent, string context)
        {
            StaticCharacterViewModel character = new StaticCharacterViewModel();
            StaticCharacter c = dbCurrent.StaticCharacters.Find(id);
            //get characterimage
            CharacterImage ci = c.CharacterImage;
            if(ci != null)
            {
                character.ImageLink = ci.ImageLink;
            }
            //get Equipped weapon
            if (c.WeaponEquipped != null)
            {
                character.EquippedWeaponName = c.WeaponEquipped.Name;
            }
            //get equipped armour name
            if (c.ArmourEquipped != null)
            {
                character.EquippedArmourName = c.ArmourEquipped.Name;
            }

            return character;
        }

        internal static bool EditStaticCharacter(StaticCharacter updated, ApplicationDbContext db)
        {
            bool noPropertyChanged = false;
            StaticCharacter original = new StaticCharacter();
            try
            {
                original = db.StaticCharacters.Find(updated.StaticCharacterId);
                db.StaticCharacters.Attach(original);
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

        internal static IEnumerable<SelectListItem> GetArmourSelectList(ApplicationDbContext dbCurrent)
        {
            var db = new ArmourSelectList();
            var armours = db
                        .GetArmours(dbCurrent)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ArmourId.ToString(),
                                    Text = x.Name
                                });
            return new SelectList(armours, "Value", "Text");
        }

        internal static IEnumerable<SelectListItem> GetImagesSelectList(ApplicationDbContext dbCurrent)
        {
            var db = new CharacterImageSelectList();
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

        internal static IEnumerable<SelectListItem> GetWeaponSelectList(ApplicationDbContext dbCurrent)
        {
            var db = new WeaponSelectList();
            var weapons = db
                        .GetWeapons(dbCurrent)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.WeaponId.ToString(),
                                    Text = x.Name
                                });
            return new SelectList(weapons, "Value", "Text");
        }

        //internal static List<WeaponViewModel> GetWeaponList(ApplicationDbContext dbCurrent)
        //{
        //    List<WeaponViewModel> l = new List<WeaponViewModel>();
        //    List<Weapon> list = dbCurrent.Weapons.ToList();
        //    foreach (Weapon w in list)
        //    {
        //        WeaponViewModel viewmodel = new WeaponViewModel();
        //        object o = SetModelProperties(viewmodel, w);
        //        viewmodel = (WeaponViewModel)o;
        //        l.Add(viewmodel);
        //    }
        //    return l;
        //}

        //internal static List<ArmourViewModel> GetArmourList(ApplicationDbContext dbCurrent)
        //{
        //    List<ArmourViewModel> l = new List<ArmourViewModel>();
        //    List<Armour> list = dbCurrent.Armours.ToList();
        //    foreach (Armour a in list)
        //    {
        //        ArmourViewModel viewmodel = new ArmourViewModel();
        //        object o = SetModelProperties(viewmodel, a);
        //        viewmodel = (ArmourViewModel)o;
        //        l.Add(viewmodel);
        //    }
        //    return l;
        //}

        internal static bool AddStaticCharacter(StaticCharacterViewModel data, ApplicationDbContext dbCurrent)
        {
            bool res = true;
            try
            {
                StaticCharacter sc = RenderStaticCharacter(data);
                int id = AddStaticCharacterToDb(sc, dbCurrent);
                CharacterModels.Tables.Attribute a = RenderAttribute(data.Attribute, id);
                res = AddAttributeToDb(a, dbCurrent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = false;
            }

            return res;
        }

        private static bool AddAttributeToDb(CharacterModels.Tables.Attribute a, ApplicationDbContext db)
        {
            bool res = true;
            try
            {
                db.Attributes.Add(a); 
            }
            catch (Exception e)
            {
                res = false;
                Console.WriteLine(e.Message);
            }
            db.SaveChanges();

            return res;
        }

        private static CharacterModels.Tables.Attribute RenderAttribute(AttributeViewModel attribute, int id)
        {
            attribute.StaticCharacterId = id;
            CharacterModels.Tables.Attribute a = new CharacterModels.Tables.Attribute();
            //Set properties auto
            a = (CharacterModels.Tables.Attribute)SetModelProperties(a, attribute);
            return a;
        }

        private static int AddStaticCharacterToDb(StaticCharacter sc, ApplicationDbContext db)
        {
            try
            {
                db.StaticCharacters.Add(sc); //Maybe not necessary
                //CharacterImage ci = db.CharacterImages.Find(sc.ImageId);
                //ci.StaticCharacters.Add(sc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            db.SaveChanges();

            return sc.StaticCharacterId;
        }

        internal static void DeleteCharacter(int id, ApplicationDbContext dbCurrent, string context)
        {
            switch (context)
            {

                case "staticC":
                    StaticCharacter s = dbCurrent.StaticCharacters.Find(id);
                    if (s != null)
                    {
                        dbCurrent.StaticCharacters.Remove(s);
                    }
                    break;
                case "playerC":
                    break;
                default:
                    break;

            }

            dbCurrent.SaveChanges();
        }

        private static StaticCharacter RenderStaticCharacter(StaticCharacterViewModel data)
        {
            if (data.StaticCharacterId == 0)
            {
                data.StaticCharacterId = -1;
            }

            StaticCharacterShorthandViewModel shortdata = data;
            StaticCharacter character = new StaticCharacter();
            //Set properties auto
            character = (StaticCharacter)SetModelProperties(character, shortdata);
            return character;
        }

        //private static CharacterModels.Attribute RenderAttributes(StaticCharacterViewModel data)
        //{
        //    Attribute = new StaticCharacter();
        //    //Set properties auto
        //    character = (StaticCharacter)SetModelProperties(character, shortdata);
        //    return character;
        //}
    }
}