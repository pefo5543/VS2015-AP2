using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.GameModels.Tables
{
    public class Episode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public byte EpisodeId { get; set; }
        public Episode()
        {
            this.Stories = new HashSet<Story>();
            this.MonsterRarities = new HashSet<EpisodeRarity>();
        }
        //Array of rarity - what monsters that can appear in this episode
        //[Required]
        //public List<int> MonsterRarities { get; set; }
        //public virtual Character Character { get; set; }

        public virtual ICollection<EpisodeRarity> MonsterRarities { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<GameEpisode> GameEpisodes { get; set; }
    }
}