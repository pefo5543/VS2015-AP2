using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class MonsterAttribute : AttributeBase
    {
        [Key, ForeignKey("Monster")]
        public int MonsterId { get; set; }

        public virtual Monster Monster { get; set; }
    }
}