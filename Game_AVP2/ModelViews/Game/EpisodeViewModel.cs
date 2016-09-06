using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.GameModels.Tables;

namespace Game_AVP2.ModelViews.Game
{
    public class EpisodeViewModel
    {
        public List<int> MonsterRarities { get; set; }
        public List<StoryViewModel> Stories { get; set; }

        public EpisodeViewModel(int gameId, GameEpisode gameEpisode, ApplicationDbContext dbCurrent)
        {
            MonsterRarities = new List<int>();
            Stories = new List<StoryViewModel>();

            IEnumerable<int> l = from mr in gameEpisode.Episode.MonsterRarities
                                 select mr.MonsterRarity;
            MonsterRarities = l.ToList();

            foreach(Story s in gameEpisode.Episode.Stories)
            {
                StoryViewModel storyview = new StoryViewModel(s);
                Stories.Add(storyview);

            }
        }
    }
}