using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.Items.Tables
{
    public class CharacterItem
    {
        [Key]
        public int CharacterItemId { get; set; }

        public int CharacterId { get; set; }
        public int MiscId { get; set; }

        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

        [ForeignKey("MiscId")]
        public virtual Misc Misc { get; set; }
    }
}