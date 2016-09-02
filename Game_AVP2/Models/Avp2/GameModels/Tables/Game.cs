using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.GameModels.Tables
{
    public class Game
    {
        [Key, ForeignKey("Character")]
        public Int32 GameId { get; set; }
        public Game()
        {
            this.Battles = new HashSet<Battle>();
        }
        [Required]
        public int Progress { get; set; }
        [Required]
        public int BattleCount { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime LastPlayed { get; set; }

        public virtual Character Character { get; set; }

        public virtual ICollection<Battle> Battles { get; set; }
        //public virtual ICollection<CharacterArmour> CharacterArmours { get; set; }
        //public virtual ICollection<Ability> Abilities { get; set; }
    }
}