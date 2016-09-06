using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.GameModels.Tables;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Game_AVP2.Models
{
    public class BaseModel
    {
        private void SetValue(object original, string theProperty, object theValue)
        {
            try
            {
                PropertyInfo propertyInfo = original.GetType().GetProperty(theProperty);
                propertyInfo.SetValue(original, theValue, null);
                propertyInfo.GetType().GetProperties();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected object SetModelProperties(object targetModel, object valuemodel)
        {
            PropertyInfo[] propertyInfos = valuemodel.GetType().GetProperties();
            PropertyInfo[] thisInfos = targetModel.GetType().GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                int pos = 0;
                foreach (PropertyInfo t in thisInfos)
                {
                    if (p.PropertyType == t.PropertyType && p.Name == t.Name)
                    {
                        thisInfos[pos].SetValue(targetModel, p.GetValue(valuemodel), null);
                        break;
                    }
                    pos++;
                }
            }

            return targetModel;
        }

        protected bool SetEditValues(ApplicationDbContext db, object original, object updated)
        {
            var entry = db.Entry(original);
            bool noPropertyChanged = true;
            entry.CurrentValues.SetValues(updated);
            entry.OriginalValues.SetValues(original);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                noPropertyChanged = false;
            }

            return noPropertyChanged;
        }

        internal Game CreateNewGame(int characterId, ApplicationDbContext dbCurrent)
        {
            Game newGame = new Game();
            newGame.GameId = characterId;
            newGame.BattleCount = 0;
            newGame.Progress = 0;
            newGame.Start = DateTime.Now;
            newGame.LastPlayed = DateTime.Now;
            try
            {

                dbCurrent.Games.Add(newGame);
                dbCurrent.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return newGame;
        }
    }
}