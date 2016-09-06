using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_AVP2.Models.Avp2.GameModels.Tables
{
    public class GameEpisode
    {
        [Key, ForeignKey("Game")]
        [Column(Order = 1)]
        public int GameId { get; set; }
        [Key, ForeignKey("Episode")]
        [Column(Order = 2)]
        public byte EpisodeId { get; set; }

        [Required]
        public int StartScore { get; set; }
        public int Score { get; set; }
        [Required]
        public bool IsFinished { get; set;}

        public virtual Game Game { get; set; }
        public virtual Episode Episode { get; set; }
    }
}