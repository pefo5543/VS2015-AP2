using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_AVP2.Models.Avp2.GameModels.Tables
{
    public class EpisodeRarity
    {
        [Key]
        public int EpisodeRarityId { get; set; }
        public byte EpisodeId { get; set; }

        //rarity - what monsters that can appear in this episode
        [Required]
        public int MonsterRarity { get; set; }
        [ForeignKey("EpisodeId")]
        public virtual Episode Episode { get; set; }
    }
}