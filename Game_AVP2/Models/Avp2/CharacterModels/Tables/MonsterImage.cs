using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class MonsterImage : TableImageBase
    {
        public MonsterImage()
        {
            this.Monsters = new HashSet<Monster>();
            //this.Characters = new HashSet<Character>();
        }
        [Key]
        public int MonsterImageId { get; set; }

        public virtual ICollection<Monster> Monsters { get; set; }
    }
}