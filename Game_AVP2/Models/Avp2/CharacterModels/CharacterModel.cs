using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2
{
    public class CharacterModel : BaseModel
    {
        internal static List<StaticCharacterShorthandViewModel> RenderStaticSimpleList(List<StaticCharacter> list)
        {
            List<StaticCharacterShorthandViewModel> l = new List<StaticCharacterShorthandViewModel>();
            foreach (StaticCharacter w in list)
            {
                StaticCharacterShorthandViewModel viewmodel = new StaticCharacterShorthandViewModel();
                object o = SetViewModelProperties(viewmodel, w);
                viewmodel = (StaticCharacterShorthandViewModel)o;
                l.Add(viewmodel);
            }
            return l;
        }

        internal static string GetImage(int id, ApplicationDbContext dbCurrent, string context)
        {
            string ImageLink = "";
            switch (context)
            {
               
                case "staticC":
                    //staticcharacter
                    StaticCharacter c = dbCurrent.StaticCharacters.Find(id);
                    CharacterImage ci = dbCurrent.CharacterImages.Find(c.ImageId);
                    ImageLink = ci.ImageLink;
                    break;
                case "playerC":
                    break;
                default:
                    break;

            }
            return ImageLink;
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

        internal static bool AddStaticCharacter(StaticCharacterViewModel data, ApplicationDbContext dbCurrent)
        {
            StaticCharacter sc = RenderStaticCharacter(data, dbCurrent);
            bool result = AddStaticCharacterToDb(sc);
            return result;
        }

        private static bool AddStaticCharacterToDb(StaticCharacter sc)
        {
            throw new NotImplementedException();
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
                case"playerC":
                    break;
                default:
                    break;

            }

            dbCurrent.SaveChanges();
        }

        private static StaticCharacter RenderStaticCharacter(StaticCharacterViewModel data, ApplicationDbContext db)
        {
            int Id = -1;
            if (data.StaticCharacterId != 0 && data.StaticCharacterId != -1)
            {
                Id = data.StaticCharacterId;
            }

            StaticCharacter character = new StaticCharacter()
            {
                //WeaponId = Id,
                //Name = data.Name,
                //Description = data.Description,
                //WeaponType = data.WeaponType,
                //Damage = data.Damage,
                //ExtraDamage = data.ExtraDamage,
                //Rarity = data.Rarity,
                //Value = data.Value,
                //ImageId = Int16.Parse(data.Image)

            };
            return character;
        }
    }
}