using Game_AVP2.Helpers;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;
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
        internal List<StaticCharacterViewModel> RenderStaticCharacterList(List<StaticCharacter> list, ApplicationDbContext db)
        {
            List<StaticCharacterViewModel> l = new List<StaticCharacterViewModel>();
            foreach (StaticCharacter c in list)
            {
                //CharacterModels.Tables.Attribute a = db.Attributes.Find(c.StaticCharacterId);
                //c.Attribute = a;
                StaticCharacterViewModel viewmodel = new StaticCharacterViewModel(c);
                l.Add(viewmodel);
            }
            return l;
        }
        internal StaticCharacterViewModel GetDetail(int id, ApplicationDbContext dbCurrent, string context)
        {
            StaticCharacterViewModel character = new StaticCharacterViewModel();
            StaticCharacter c = dbCurrent.StaticCharacters.Find(id);
            //get characterimage
            CharacterImage ci = c.CharacterImage;
            if (ci != null)
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

        internal bool EditStaticCharacter(StaticCharacterViewModel updated, ApplicationDbContext db)
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

        internal bool CreateUserCharacter(int staticCharacterId, string userId, ApplicationDbContext dbCurrent)
        {
            bool result = true;
            StaticCharacter c = dbCurrent.StaticCharacters.Find(staticCharacterId);
            Character s = new Character();
            CharacterModels.Tables.Attribute a = c.Attribute;
            Weapon w = c.WeaponEquipped;
            Armour armour = c.ArmourEquipped;
            s.Name = c.Name;
            s.Background = c.Background;
            s.StaticCharacterId = c.StaticCharacterId;
            s.UserId = userId;
            s.CharacterId = -1;

            try
            {
                s = dbCurrent.Characters.Add(s);
            }
            catch (Exception e)
            {
                result = false;
                Console.WriteLine(e.Message);
            }
            try
            {
                dbCurrent.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                AddCharacterArmour(s.CharacterId, armour, dbCurrent);
                AddCharacterWeapon(s.CharacterId, w, dbCurrent);
                AddCharacterAttributes(s.CharacterId, a, dbCurrent);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                result = false;
            }

            try {
                dbCurrent.SaveChanges();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                    }
            return result;
        }

        private void AddCharacterAttributes(int characterId, CharacterModels.Tables.Attribute a, ApplicationDbContext dbCurrent)
        {
            CharacterAttribute ca = new CharacterAttribute();
            
            ca.AttributeId = a.StaticCharacterId;
            ca.CharacterId = characterId;
            ca.DefenceModifier = a.DefenceModifier;
            ca.Dexterity = a.Dexterity;
            ca.Health = a.Health;
            ca.LuckModifier = a.LuckModifier;
            ca.Strength = a.Strength;
            ca.StrengthModifier = a.StrengthModifier;

            try
            {
                dbCurrent.CharacterAttributes.Add(ca);
                }
            catch { }
        }

        private void AddCharacterWeapon(int characterId, Weapon w, ApplicationDbContext dbCurrent)
        {
            CharacterWeapon cw = new CharacterWeapon();
            cw.CharacterId = characterId;
            cw.WeaponId = w.WeaponId;
            cw.Equipped = true;
            try
            {
                dbCurrent.CharacterWeapons.Add(cw);
            }
            catch { }
        }

        private void AddCharacterArmour(int characterId, Armour armour, ApplicationDbContext dbCurrent)
        {
            CharacterArmour ca = new CharacterArmour();
            ca.CharacterId = characterId;
            ca.ArmourId = armour.ArmourId;
            ca.Equipped = true;
            try
            {
                dbCurrent.CharacterArmours.Add(ca);
            }
            catch { }
        }

        internal IEnumerable<SelectListItem> GetArmourSelectList(ApplicationDbContext dbCurrent)
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

        internal IEnumerable<SelectListItem> GetImagesSelectList(ApplicationDbContext dbCurrent)
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

        internal IEnumerable<SelectListItem> GetWeaponSelectList(ApplicationDbContext dbCurrent)
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

        internal bool AddStaticCharacter(StaticCharacterShorthandViewModel data, ApplicationDbContext dbCurrent)
        {
            bool res = true;
            try
            {
                StaticCharacter sc = RenderStaticCharacter(data);
                int id = AddStaticCharacterToDb(sc, dbCurrent);
                CharacterModels.Tables.Attribute a = RenderAttribute(data, id);
                res = AddAttributeToDb(a, dbCurrent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = false;
            }

            return res;
        }

        private bool AddAttributeToDb(CharacterModels.Tables.Attribute a, ApplicationDbContext db)
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

        private CharacterModels.Tables.Attribute RenderAttribute(StaticCharacterShorthandViewModel data, int id)
        {
            CharacterModels.Tables.Attribute a = new CharacterModels.Tables.Attribute();
            //Set properties auto
            a.Dexterity = data.Attribute.Dexterity;
            a.Strength = data.Attribute.Strength;
            a.Health = data.Attribute.Health;
            a.LuckModifier = data.Attribute.LuckModifier;
            a.StrengthModifier = data.Attribute.StrengthModifier;
            a.DefenceModifier = data.Attribute.DefenceModifier;
            a.StaticCharacterId = id;
            return a;
        }

        private int AddStaticCharacterToDb(StaticCharacter sc, ApplicationDbContext db)
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

        internal bool DeleteCharacter(int id, ApplicationDbContext dbCurrent)
        {
            bool res = false;
            StaticCharacter s = dbCurrent.StaticCharacters.Find(id);
            if (s != null)
            {
                dbCurrent.StaticCharacters.Remove(s);
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

        private StaticCharacter RenderStaticCharacter(StaticCharacterShorthandViewModel data)
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