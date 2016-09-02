using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.GameModels.Tables;
using Game_AVP2.ModelViews.Game;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.ModelViews.CharacterModelViews;

namespace Game_AVP2.Models.Avp2.GameModels
{
    public class GameModel : BaseModel
    {
        internal Game GetUserMostRecentGame(ICollection<Character> characters, ApplicationDbContext dbCurrent)
        {
            DateTime newest = DateTime.MinValue;
            Game newestGame = null;
            Game g = null;

            foreach(Character c in characters)
            {
               g = dbCurrent.Games.Find(c.CharacterId);
                if(g != null)
                {
                   int val = DateTime.Compare(newest, g.LastPlayed);
                    if(val < 0) //newest is older
                    {
                        newest = g.LastPlayed;
                        newestGame = g;
                    } else if(val > 0) //newest is newest
                    {
                        //do nothing
                    } else //two games are exactly the same age
                    {
                        //thats strange...
                    }
                }
            }
            return newestGame;
        }

        internal CharacterViewModel PopulateCharacterViewModel(int CharacterId, ApplicationDbContext dbCurrent)
        {
            Character c = dbCurrent.Characters.Find(CharacterId);
            //Find weaponid of characters equipped weapon
            int weaponid = (from wc in c.CharacterWeapons
                         where wc.Equipped == true
                         select wc.WeaponId).First();
            //Get weapon object from db
            Weapon weapon = dbCurrent.Weapons.Find(weaponid);
            //Find armourid of characters equipped armour
            int armourid = (from ac in c.CharacterArmours
                            where ac.Equipped == true
                            select ac.ArmourId).First();
            //Get armour object from db
            Armour armour = dbCurrent.Armours.Find(armourid);

            CharacterViewModel viewModel = new CharacterViewModel(c, weapon, armour);

            return viewModel;
        }
    }
}