using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;

namespace Game_AVP2.Models.Avp2.GameModels.Tables
{
    public class Battle
    {
        [Key]
        public int BattleId { get; set;}
        public int GameId { get; set; } //same as characterid
        public int MonsterId { get; set; }
        public int Rounds { get; set; }
        public bool IsFinished { get; set; }

        [ForeignKey("GameId")]
        [Column(Order = 1)]
        public virtual Game Game { get; set; }

        [ForeignKey("MonsterId")]
        [Column(Order = 2)]
        public virtual Monster Monster { get; set; }
    }
}