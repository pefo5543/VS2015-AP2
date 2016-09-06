using Game_AVP2.ModelViews.CharacterModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_AVP2.ModelViews.Game
{
    public class GameViewModel
    {
        //same as characterid
        public int GameId { get; set; }
        //public StoryViewModel Story { get; set; }
        public CharacterViewModel Character { get; set; } 
        public EpisodeViewModel Episode { get; set; }

        public GameViewModel()
        {
        }

        public GameViewModel(int gameId)
        {
            GameId = gameId;
        }
        public GameViewModel(int gameId, CharacterViewModel c)
        {
            GameId = gameId;
            Character = c;
        }
        public GameViewModel(int gameId, CharacterViewModel c, EpisodeViewModel e)
        {
            GameId = gameId;
            Character = c;
            Episode = e;
        }
    }
}