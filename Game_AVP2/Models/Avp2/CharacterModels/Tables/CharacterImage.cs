using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_AVP2.Models.Avp2.CharacterModels.Tables
{
    public class CharacterImage
    {
        public CharacterImage()
        {
            this.StaticCharacters = new HashSet<StaticCharacter>();
            //this.Characters = new HashSet<Character>();
        }
        [Key]
        public int CharacterImageId { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FileName { get; set; }
        public string ThumbnailLink { get; set; }

        public virtual ICollection<StaticCharacter> StaticCharacters { get; set; }
        //public virtual ICollection<Character> Characters { get; set; }
    }
}