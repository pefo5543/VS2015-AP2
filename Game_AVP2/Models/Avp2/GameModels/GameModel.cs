using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.GameModels.Tables;
using Game_AVP2.ModelViews.Game;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.ModelViews.CharacterModelViews;
using System.Collections;
using System.Security.Cryptography;

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
        //setup new game with first episode - if it exists
        internal void ConstructGameEpisode(Game game, int episodeId, ApplicationDbContext dbCurrent)
        {
            Episode e = dbCurrent.Episodes.Find(episodeId);
            if(e != null)
            {
                GameEpisode ge = new GameEpisode();
                ge.EpisodeId = e.EpisodeId;
                ge.GameId = game.GameId;
                ge.IsFinished = false;
                ge.Score = game.Score;
                ge.StartScore = 0;
                dbCurrent.GameEpisodes.Add(ge);
            }
            
        }

        internal int GetCurrentGameEpisodeId(int gameId, ApplicationDbContext dbCurrent)
        {
            throw new NotImplementedException();
        }

        internal GameEpisode GetCurrentGameEpisode(int gameId, ApplicationDbContext dbCurrent)
        {
            GameEpisode ge = (from ges in dbCurrent.GameEpisodes
                             where ges.GameId == gameId && ges.IsFinished == false
                             select ges).First();

            return ge;
        }

        internal Monster GenerateMonster(List<int> rarities, ApplicationDbContext dbCurrent)
        {
            Monster monster = new Monster();
            //get all monsters that has a rarity value that exists in rarities list
            List<Monster> monsters = (from m in dbCurrent.Monsters
                                               where rarities.Contains(m.Rarity)
                                            select m).ToList();
            int count = monsters.Count;
            if(count > 1)
            {
                int randNum = NextRan(monsters.Count);
                monster = monsters[randNum - 1];
            } else if(count == 1)
            {
                monster = monsters[0];
            }

            //IQueryable<Monster> monsters = dbCurrent.Monsters.SelectMany(m => m, mr => mr.);


            return monster;
        }

        public static int NextRan(int high, int low = 1)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            if (low >= high)
                throw new ArgumentException("low must be < hi");
            byte[] buf = new byte[8];
            Int32 generatedNum;

            //Generate a random Int32
            rng.GetBytes(buf);
            generatedNum = BitConverter.ToInt32(buf, 0);
            generatedNum = Math.Abs(generatedNum);
            int numOfPartitions = high - low;
            int sizeOfOnePartition = int.MaxValue / numOfPartitions;
            int selectedPartition = 0;
            int partitionStart = 0;
            int partitionEnd = partitionStart + sizeOfOnePartition;

            for (int i = 0; i < numOfPartitions; i++)
            {
                if (generatedNum >= partitionStart && generatedNum <= partitionEnd)
                {
                    selectedPartition = i;
                    break;
                }
                partitionStart = partitionEnd;
                partitionEnd = partitionEnd + sizeOfOnePartition;
            }

            //Int32 returnVal = num * (high - low) + low;//This is ____
            int returnValue = low + selectedPartition;
            return returnValue;
        }
    }
}