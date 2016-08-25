using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.GameModels.Tables;

namespace Game_AVP2.Models.Avp2.GameModels
{
    public class GameModel
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
    }
}